using AutoFixture;
using AutoFixture.Xunit2;
using AutoMapper;
using Comments.Contracts;
using Comments.Domain.Entities;
using Comments.Mapper;
using Comments.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Comments.Tests
{
    public class CommentsServiceюTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICommentsRepository> _repository;
        private readonly Fixture _fixture;

        private readonly ICommentsService _commentService;


        public CommentsServiceюTests()
        {
            var config = new MapperConfiguration(mc => mc.AddProfile(new CommentMapperProfile()));
            _repository = new Mock<ICommentsRepository>();
            _mapper = config.CreateMapper();
            _commentService = new CommentsService(_repository.Object, _mapper);
            _fixture = new Fixture();
        }

        [Theory]
        [AutoData]
        public async Task GetCommentsByChatIdAsync_Shuld_Return_Comments(Guid id, int pageSize, int pageNumber, CancellationToken token)
        {
            //Arrange
            var comments = _fixture
                .Build<Comment>()
                .CreateMany(10)
                .ToList();

            _repository
                .Setup(r => r.GetCommentsByChatIdAsync(id, pageSize, pageNumber, token))
                .ReturnsAsync(comments)
                .Verifiable();

            var commentDto = new CommentDtoRequestGetChatPaged {Id = id, PageSize = pageSize, PageNumber = pageNumber};

            //Act
            var result = await _commentService.GetCommentsByChatIdAsync(commentDto, token);


            //Assert
            _repository.Verify();
            _repository.Verify(_ => _.GetCommentsByChatIdAsync(It.IsAny<Guid>(), 
                                                                It.IsAny<int>(), 
                                                                It.IsAny<int>(), 
                                                                It.IsAny<CancellationToken>()), 
                                                                Times.Once);
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Theory]
        [AutoData]
        public async Task DeleteCommentsByChatIdAsync_Shuld_Call_DeleteCommentsByChatIdAsync(Guid id, CancellationToken token)
        {
            //Arrange 
            _repository.Setup(r => r.DeleteCommentsByChatIdAsync(id, token))
                .Verifiable();

            //Act
            await _commentService.DeleteCommentsByChatIdAsync(id, token);

            //Assert
            _repository.Verify(_ => _.DeleteCommentsByChatIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task AddCommentAsync_Should_Return_ID_And_Call_AddCommentAsync()
        {
            //Arrange
            var commentDto = _fixture
                .Build<CommentDtoRequestCreate>()
                .Create();
            CancellationToken token = default;

            _repository.Setup(r => r.AddCommentAsync(It.IsAny<Comment>(), token))
                .ReturnsAsync(new Guid())
                .Verifiable();

            //Act
            var result = await _commentService.AddCommentAsync(commentDto, token);

            //Assert
            _repository.Verify();
            _repository.Verify(_ => _.AddCommentAsync(
                It.Is<Comment>(c => c.CreationTime != default(DateTime)),
                It.IsAny<CancellationToken>()),
                Times.Once);
        }

        [Fact]
        public async Task UpdateCommentAsync_Should_Return_ID_And_Call_UpdateCommentAsync()
        {
            //Arrange
            var commentDto = _fixture
                .Build<CommentDtoRequestUpdate>()
                .Create();

            var comment = _fixture
                .Build<Comment>()
                .With(comment => comment.CommentStatus, Contracts.Enums.CommentStatus.New)
                .Create();

            CancellationToken token = default;

            _repository.Setup(r => r.GetCommentAsync(It.IsAny<Guid>(), token))
                .ReturnsAsync(comment)
                .Verifiable();

            _repository.Setup(r => r.UpdateCommentAsync(It.IsAny<Comment>(), token))
                .ReturnsAsync(comment.Id)
                .Verifiable();

            //Act
            var result = await _commentService.UpdateCommentAsync(commentDto, token);

            //Assert
            _repository.Verify();
            _repository.Verify(_ => _.UpdateCommentAsync(
                It.Is<Comment>(c => (c.Message == commentDto.Message) && (c.CommentStatus == Contracts.Enums.CommentStatus.Changed)),
                It.IsAny<CancellationToken>()),
                Times.Once);
        }

        [Theory]
        [AutoData]
        public async Task DeleteCommentAsync_Should_Call_DeleteCommentAsync(CommentDtoRequestDelete dto, CancellationToken token)
        {
            //Arrange
            var dtoId = dto.Id.ToString();
            _repository.Setup(r => r.DeleteCommentAsync(It.IsAny<Guid>(), token))
                .Verifiable();

            //Act
            await _commentService.DeleteCommentAsync(dto, token);

            //Assert
            _repository.Verify(_ => _.DeleteCommentAsync(
                It.Is<Guid>(id => id.ToString() == dtoId),
                It.IsAny<CancellationToken>()),
                Times.Once);
        }
    }
}
