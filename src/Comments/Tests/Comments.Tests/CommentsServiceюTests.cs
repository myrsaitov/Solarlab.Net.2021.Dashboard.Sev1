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
using System.Linq.Expressions;
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
        public async Task GetCommentsByChatIdAsync_Shuld_Return_Comments(Guid id, int pageSize, int pageNumber, int pagesQuantity, CancellationToken token)
        {
            //Arrange
            var messages = _fixture
                .Build<Comment>()
                .CreateMany(10)
                .ToList();

            var chat = _fixture
                .Build<Chat>()
                .Create();

            chat.Messages = messages;

            _repository
                .Setup(r => r.CountPagesChatsAsync(It.IsAny<Expression<Func<Chat, bool>>>(), pageSize, token))
                .ReturnsAsync(pagesQuantity)
                .Verifiable();

            _repository
                .Setup(r => r.GetChatPagedAsync(It.IsAny<Expression<Func<Chat, bool>>>(), pageSize, pageNumber, token))
                .ReturnsAsync(chat)
                .Verifiable();

            var commentDto = new CommentDtoRequestGetChatPaged {AdvertisementId = id, Type = Contracts.Enums.ChatType.AdvertisementChat, PageSize = pageSize, PageNumber = pageNumber};

            //Act
            var result = await _commentService.GetChatPagedAsync(commentDto, token);


            //Assert
            _repository.Verify();
            _repository.Verify(_ => _.GetChatPagedAsync(It.IsAny<Expression<Func<Chat, bool>>>(), 
                                                                It.IsAny<int>(),
                                                                It.IsAny<int>(),
                                                                It.IsAny<CancellationToken>()), 
                                                                Times.Once);
            Assert.NotNull(result);
        }

        [Theory]
        [AutoData]
        public async Task DeleteCommentsByChatIdAsync_Shuld_Call_DeleteCommentsByChatIdAsync(Guid id, CancellationToken token)
        {
            //Arrange 
            Expression<Func<Chat, bool>> predicate = c => c.ChatId == id;

            _repository.Setup(r => r.RemoveChatAsync(predicate, token))
                .Verifiable();

            var dto = new CommentDtoRequestDeleteChat { AdvertisementId = new Guid(), Type = Contracts.Enums.ChatType.AdvertisementChat };
            //Act
            await _commentService.DeleteChatAsync(dto, token);

            //Assert
            _repository.Verify(_ => _.RemoveChatAsync(It.IsAny<Expression<Func<Chat, bool>>>(), It.IsAny<CancellationToken>()), Times.Once);
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
                It.Is<Comment>(c => (c.Message == commentDto.Message) && (c.IsUpdated == true)),
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
