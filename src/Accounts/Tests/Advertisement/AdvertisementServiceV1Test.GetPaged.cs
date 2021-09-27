using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using AutoFixture.Xunit2;
using System.Collections.Generic;
using Sev1.Accounts.Application.Contracts.GetPaged;
using Sev1.Accounts.Application.Contracts.Account;
using System.Linq;
using System;

namespace Sev1.Accounts.Tests.Account
{
    public partial class AccountServiceV1Test
    {
        [Theory]
        [AutoData]
        public async Task GetPaged_Returns_Response_Success(
            GetPagedAccountRequest request, 
            CancellationToken cancellationToken, 
            int userId,
            string contentTitle,
            string contentBody,
            string[] tagBodies,
            int categoryId)
        {
            // Arrange
            int contentCount = 3;

            var responce = new List<Domain.Account>();

            for (int contentId = 1; contentId <= contentCount; contentId++)
            {
                var content = new Domain.Account()
                {
                    Id = contentId,
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
                responce.Add(content);
            }

            _accountRepositoryMock
                .Setup(_ => _.Count(It.IsAny<CancellationToken>()))
                .ReturnsAsync(contentCount)
                .Verifiable();

            _accountRepositoryMock
                .Setup(_ => _.GetPagedWithTagsAndOwnerAndCategoryInclude(
                    It.IsAny<int>(),
                    It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(responce)
                .Verifiable();

            // Act
            var response = await _accountServiceV1.GetPaged(
                request, 
                cancellationToken);

            // Assert
            _accountRepositoryMock.Verify();
            Assert.NotNull(response);
            Assert.Equal(contentCount, response.Total);
            Assert.Equal(contentCount, response.Items.Count());
            Assert.IsType<GetPagedResponse<AccountPagedDto>>(response);
        }
        [Theory]
        [AutoData]
        public async Task GetPaged_Returns_Response_Success_Total_eq_0(
            GetPagedAccountRequest request,
            CancellationToken cancellationToken)
        {
            // Arrange
            int contentCount = 0;

            var responce = new List<Domain.Account>();

            _accountRepositoryMock
                .Setup(_ => _.Count(It.IsAny<CancellationToken>()))
                .ReturnsAsync(0)
                .Verifiable();

            _accountRepositoryMock
                .Setup(_ => _.GetPagedWithTagsAndOwnerAndCategoryInclude(
                    It.IsAny<int>(),
                    It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(responce);

            // Act
            var response = await _accountServiceV1.GetPaged(
                request,
                cancellationToken);

            // Assert
            _accountRepositoryMock.Verify();
            Assert.NotNull(response);
            Assert.Equal(contentCount, response.Total);
            Assert.Equal(contentCount, response.Items.Count());
            Assert.IsType<GetPagedResponse<AccountPagedDto>>(response);
        }
        [Theory]
        [InlineAutoData(null)]
        public async Task GetPaged_Throws_Exception_When_Request_Is_Null(
            GetPagedAccountRequest request, 
            CancellationToken cancellationToken)
        {
            // Act
            await Assert.ThrowsAsync<ArgumentNullException>(
                async () => await _accountServiceV1.GetPaged(
                    request, 
                    cancellationToken));
        }
    }
}
