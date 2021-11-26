using AutoFixture;
using AutoFixture.Xunit2;
using AutoMapper;
using Comments.Contracts;
using Comments.Contracts.Enums;
using Comments.Domain.Entities;
using Comments.Mapper;
using Comments.Services;
using Moq;
using sev1.Accounts.Contracts.UserProvider;
using Sev1.Accounts.Contracts.ApiClients.User;
using Sev1.Accounts.Contracts.Contracts.User.Responses;
using Sev1.Advertisements.Contracts.Contracts.Advertisement.Responses;
using Sev1.Avdertisements.Contracts.ApiClients.AdvertisementValidate;
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
        private readonly Mock<IUserValidateApiClient> _userApiClient;
        private readonly Mock<IAdvertisementValidateApiClient> _advertisementValidateApiClient;
        private readonly Mock<IUserProvider> _userProvider;

        private readonly Fixture _fixture;

        private readonly ICommentsService _commentService;
        

        public CommentsServiceюTests()
        {
            var config = new MapperConfiguration(mc => mc.AddProfile(new CommentMapperProfile()));
            _repository = new Mock<ICommentsRepository>();
            _userApiClient = new Mock<IUserValidateApiClient>();
            _advertisementValidateApiClient = new Mock<IAdvertisementValidateApiClient>();
            _userProvider = new Mock<IUserProvider>();
            _mapper = config.CreateMapper();
            _commentService = new CommentsService(_repository.Object, _mapper, _userApiClient.Object, _advertisementValidateApiClient.Object, _userProvider.Object);
            _fixture = new Fixture();
        }

        [Theory]
        [AutoData]
        public async Task GetChatPagedAsync_Shuld_Return_CommentDtoResponceChatWithUsers(int id, int pageSize, int pageNumber, int pagesQuantity, int totalPages, CancellationToken token)
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

            _repository
                .Setup(r => r.CountPagesMessagesAsync(It.IsAny<Guid>(), pageSize, token))
                .ReturnsAsync(totalPages)
                .Verifiable();


            var usersId = messages.Select(m => m.AuthorId.ToString()).ToList();
            var userInfoResponce = new Dictionary<string, UserGetResponse>();
            foreach(var strId in usersId)
            {
                userInfoResponce.Add(strId, _fixture.Build<UserGetResponse>().Create());
            }

            _userApiClient
                .Setup(r => r.GetUsersByListId(It.IsAny<List<string>>()))
                .ReturnsAsync(userInfoResponce);

            var commentDto = new CommentDtoRequestGetChatPaged {AdvertisementId = id, Type = Contracts.Enums.ChatType.AdvertisementChat, PageSize = pageSize, PageNumber = pageNumber};

            //Act
            var result = await _commentService.GetChatPagedAsync(commentDto, token);


            //Assert
            //_repository.Verify();
            _repository.Verify(_ => _.GetChatPagedAsync(It.IsAny<Expression<Func<Chat, bool>>>(), 
                                                                It.IsAny<int>(),
                                                                It.IsAny<int>(),
                                                                It.IsAny<CancellationToken>()), 
                                                                Times.Once);
            Assert.NotNull(result);
            Assert.DoesNotContain(null, result.Messages.Select(m => m.Author).ToList());
            Assert.Equal(result.TotalPages, totalPages);
        }

        [Theory]
        [AutoData]
        public async Task DeleteChatAsync_Shuld_Call_DeleteCommentsByChatIdAsync(CancellationToken token)
        {
            //Arrange 

            var dto = _fixture
                .Build<CommentDtoRequestDeleteChat>()
                .Create();

            _repository.Setup(r => r.RemoveChatAsync(It.IsAny<Expression<Func<Chat, bool>>>(), token))
                .Verifiable();

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

            _repository.Setup(r => r.GetChatId(It.IsAny<Expression<Func<Chat, bool>>>(), token))
                .ReturnsAsync(new Guid())
                .Verifiable();

            _repository.Setup(r => r.AddCommentAsync(It.IsAny<Comment>(), token))
                .ReturnsAsync(new Guid())
                .Verifiable();

            var advDto = _fixture
                .Build<AdvertisementGetResponse>()
                .Create();

            _advertisementValidateApiClient
                .Setup(a => a.GetAdvertisementById(commentDto.AdvertisementId))
                .ReturnsAsync(advDto);

            _userProvider
                .Setup(u => u.GetUserId())
                .Returns(new Guid().ToString());

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
