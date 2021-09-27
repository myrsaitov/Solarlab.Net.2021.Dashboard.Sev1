using Sev1.Accounts.Application.Exceptions;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using AutoFixture.Xunit2;
using System.Collections.Generic;
using System;
using Sev1.Accounts.Application.Exceptions.Account;

namespace Sev1.Accounts.Tests.Account
{
    public partial class AccountServiceV1Test
    {
        [Theory]
        [AutoData]
        public async Task GetById_Returns_Response_Success(
            int id, 
            CancellationToken cancellationToken, 
            int userId,
            string contentTitle,
            string contentBody,
            string[] tagBodies,
            int categoryId)
        {
            // Arrange
            var content = new Domain.Account()
            {
                Title = contentTitle,
                Body = contentBody,
                //OwnerId = userId.ToString(),
                Category = new Domain.Category()
                {
                    Id = categoryId
                },
                Tags = new List<Domain.Tag>()
            };

            int tagId = 1;
            foreach (string body in tagBodies)
            {
                var tag = new Domain.Tag()
                {
                    Id = tagId++,
                    Body = body
                };
                content.Tags.Add(tag);
            }

            _advertisementRepositoryMock
                .Setup(_ => _.FindByIdWithUserAndCategoryAndTags(
                    It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(content)
                .Callback((int _advertisementId, CancellationToken ct) => content.Id = _advertisementId)
                .Verifiable();

            // Act
            var response = await _advertisementServiceV1.GetById(
                id, 
                cancellationToken);

            // Assert
            _advertisementRepositoryMock.Verify();
            Assert.NotNull(response);
            Assert.NotEqual(default, response.Id);
        }
        [Theory]
        [AutoData]
        public async Task GetById_Throws_Exception_When_Account_Is_Null(
            int id,
            CancellationToken cancellationToken)
        {
            // Act
            await Assert.ThrowsAsync<AccountNotFoundException>(
                async () => await _advertisementServiceV1.GetById(
                    id,
                    cancellationToken));
        }
        [Theory]
        [InlineAutoData(null)]
        public async Task GetById_Throws_Exception_When_Request_Is_Null(
            int id, 
            CancellationToken cancellationToken)
        {
            // Act
            await Assert.ThrowsAsync<ArgumentNullException>(
                async () => await _advertisementServiceV1.GetById(
                    id, 
                    cancellationToken));
        }
    }
}
