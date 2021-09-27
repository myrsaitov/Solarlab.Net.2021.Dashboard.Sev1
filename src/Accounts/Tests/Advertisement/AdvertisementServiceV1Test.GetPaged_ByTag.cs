using Sev1.Accounts.Application.Contracts.Advertisement;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using AutoFixture.Xunit2;
using System.Collections.Generic;
using System;
using System.Linq.Expressions;
using System.Linq;
using Sev1.Accounts.Application.Contracts.GetPaged;

namespace Sev1.Accounts.Tests.Advertisement
{
    public partial class AdvertisementServiceV1Test
    {
        [Theory]
        [AutoData]
        public async Task GetPaged_ByTag_Returns_Response_Success(
            GetPagedAdvertisementRequest request,
            CancellationToken cancellationToken,
            int userId,
            string contentTitle,
            string contentBody,
            string[] tagBodies,
            int categoryId,
            string tagSearch)
        {
            // Arrange
            int contentCount = 3;

            var responce = new List<Domain.Advertisement>();

            for (int contentId = 1; contentId <= contentCount; contentId++)
            {
                var content = new Domain.Advertisement()
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

                content.Tags.Add(new Domain.Tag()
                {
                    Id = tagId,
                    Body = tagSearch
                });

                responce.Add(content);
            }

            _advertisementRepositoryMock
                .Setup(_ => _.Count(
                    It.IsAny<Expression<Func<Domain.Advertisement, bool>>>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(contentCount)
                .Verifiable();

            _advertisementRepositoryMock
                .Setup(_ => _.GetPagedWithTagsAndOwnerAndCategoryInclude(
                    It.IsAny<Expression<Func<Domain.Advertisement, bool>>>(),
                    It.IsAny<int>(),
                    It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(responce)
                .Verifiable();

            // Act
            var response = await _advertisementServiceV1.GetPaged(
                a => a.Tags.Any(t => t.Body == tagSearch), 
                request, 
                cancellationToken);

            // Assert
            _advertisementRepositoryMock.Verify();
            Assert.NotNull(response);
            Assert.Equal(contentCount, response.Total);
            Assert.Equal(contentCount, response.Items.Count());
            Assert.IsType<GetPagedResponse<AdvertisementPagedDto>>(response);
        }
        [Theory]
        [AutoData]
        public async Task GetPaged_ByTag_Returns_Response_Success_Total_eq_0(
            GetPagedAdvertisementRequest request,
            CancellationToken cancellationToken,
            Expression<Func<Domain.Advertisement, bool>> predicate)
        {
            // Arrange
            int contentCount = 0;

            var responce = new List<Domain.Advertisement>();

            _advertisementRepositoryMock
                .Setup(_ => _.Count(
                    It.IsAny<Expression<Func<Domain.Advertisement, bool>>>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(contentCount)
                .Verifiable();

            // Act
            var response = await _advertisementServiceV1.GetPaged(
                predicate,
                request,
                cancellationToken);

            // Assert
            _advertisementRepositoryMock.Verify();
            Assert.NotNull(response);
            Assert.Equal(contentCount, response.Total);
            Assert.Equal(contentCount, response.Items.Count());
            Assert.IsType<GetPagedResponse<AdvertisementPagedDto>>(response);
        }
        [Theory]
        [InlineAutoData(null)]
        public async Task GetPaged_ByTag_Throws_Exception_When_Request_Is_Null(
            GetPagedAdvertisementRequest request,
            CancellationToken cancellationToken,
            Expression<Func<Domain.Advertisement, bool>> predicate)
        {
            // Act
            await Assert.ThrowsAsync<ArgumentNullException>(
                async () => await _advertisementServiceV1.GetPaged(
                    predicate, 
                    request, 
                    cancellationToken));
        }
    }
}
