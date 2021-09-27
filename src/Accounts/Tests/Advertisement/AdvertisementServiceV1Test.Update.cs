using Sev1.Accounts.Application.Contracts.Account;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using AutoFixture.Xunit2;
using System.Linq.Expressions;
using System;
using Sev1.Accounts.Application.Exceptions;
using Sev1.Accounts.Domain.Exceptions;
using Sev1.Accounts.Application.Exceptions.Category;
using Sev1.Accounts.Application.Exceptions.Account;

namespace Sev1.Accounts.Tests.Account
{
    public partial class AccountServiceV1Test
    {
        [Theory]
        [AutoData]
        public async Task Update_Returns_Response_Success(
            AccountUpdateDto request,
            CancellationToken cancellationToken,
            int userId,
            int contentId,
            int categoryId)
        {
            // Arrange
            var category = new Domain.Category()
            {
                Id = categoryId
            };

            var content = new Domain.Account()
            {
                Id = contentId,

                CategoryId = categoryId
            };

            int tagId = 1;

            _accountRepositoryMock
                .Setup(_ => _.FindByIdWithUserAndCategoryAndTags(
                    It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(content)
                .Callback((int _accountId, CancellationToken ct) => content.Id = _accountId)
                .Verifiable();


            _categoryRepositoryMock
                .Setup(_ => _.FindById(
                    It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(category)
                .Callback((int _categoryId, CancellationToken ct) => category.Id = _categoryId)
                .Verifiable();


            _categoryRepositoryMock
                .Setup(_ => _.FindById(
                    It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(category)
                .Callback(() => category.Id = categoryId)
                .Verifiable();

            _tagRepositoryMock
                .Setup(_ => _.FindWhere(
                    It.IsAny<Expression<Func<Domain.Tag, bool>>>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(() => new Domain.Tag()
                {
                    Id = tagId,
                    Body = request.TagBodies[tagId++ - 1]
                })
                .Verifiable();

            _tagRepositoryMock
                .Setup(_ => _.Save(
                    It.IsAny<Domain.Tag>(),
                    It.IsAny<CancellationToken>()));

            _accountRepositoryMock
                .Setup(_ => _.Save(
                    It.IsAny<Domain.Account>(),
                    It.IsAny<CancellationToken>()))
                .Callback((Domain.Account content, CancellationToken ct) => content.Id = contentId);

            // Act
            var response = await _accountServiceV1.Update(
                request, 
                cancellationToken);

            // Assert
            _accountRepositoryMock.Verify();
            _categoryRepositoryMock.Verify();
            _tagRepositoryMock.Verify();
            Assert.NotNull(response);
            Assert.NotEqual(default, response);
        }
        [Theory]
        [AutoData]
        public async Task Update_Throws_Exception_When_Category_is_Null(
            AccountUpdateDto request,
            CancellationToken cancellationToken,
            int userId,
            int contentId)
        {
            // Arrange
            var content = new Domain.Account()
            {
                Id = contentId,

            };

            _accountRepositoryMock
                .Setup(_ => _.FindByIdWithUserAndCategoryAndTags(
                    It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(content)
                .Callback((int _accountId, CancellationToken ct) => content.Id = _accountId);


            // Act
            await Assert.ThrowsAsync<CategoryNotFoundException>(
                async () => await _accountServiceV1.Update(
                    request,
                    cancellationToken));
        }
        [Theory]
        [AutoData]
        public async Task Update_Throws_Exception_When_No_Rights(
            AccountUpdateDto request,
            CancellationToken cancellationToken,
            int userId,
            int contentId)
        {
            // Arrange
            var content = new Domain.Account()
            {
                Id = contentId,

            };

            _accountRepositoryMock
                .Setup(_ => _.FindByIdWithUserAndCategoryAndTags(
                    It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(content)
                .Callback((int _accountId, CancellationToken ct) => content.Id = _accountId);


            // Act
            await Assert.ThrowsAsync<NoRightsException>(
                async () => await _accountServiceV1.Update(
                    request,
                    cancellationToken));
        }
        [Theory]
        [AutoData]
        public async Task Update_Throws_Exception_When_Account_Is_Null(
            AccountUpdateDto request,
            CancellationToken cancellationToken)
        {
            // Act
            await Assert.ThrowsAsync<AccountNotFoundException>(
                async () => await _accountServiceV1.Update(
                    request,
                    cancellationToken));
        }
        [Theory]
        [InlineAutoData(null)]
        public async Task Update_Throws_Exception_When_Request_Is_Null(
            AccountUpdateDto request,
            CancellationToken cancellationToken)
        {
            // Act
            await Assert.ThrowsAsync<ArgumentNullException>(
                async () => await _accountServiceV1.Update(
                    request, 
                    cancellationToken));
        }
    }
}
