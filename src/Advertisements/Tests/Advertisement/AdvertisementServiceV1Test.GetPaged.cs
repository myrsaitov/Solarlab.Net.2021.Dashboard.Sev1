using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using AutoFixture.Xunit2;
using System.Collections.Generic;
using Sev1.Advertisements.Application.Contracts.GetPaged;
using Sev1.Advertisements.Application.Contracts.Advertisement;
using System.Linq;
using System;

namespace Sev1.Advertisements.Tests.Advertisement
{
    public partial class AdvertisementServiceV1Test
    {
        [Theory]
        [AutoData]
        public async Task GetPaged_Returns_Response_Success(
            GetPagedAdvertisementRequest request, 
            CancellationToken cancellationToken, 
            int userId,
            string contentTitle,
            string contentBody,
            string[] tagBodies,
            int categoryId)
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
                responce.Add(content);
            }

            _advertisementRepositoryMock
                .Setup(_ => _.Count(It.IsAny<CancellationToken>()))
                .ReturnsAsync(contentCount)
                .Verifiable();

            _advertisementRepositoryMock
                .Setup(_ => _.GetPagedWithTagsAndOwnerAndCategoryInclude(
                    It.IsAny<int>(),
                    It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(responce)
                .Verifiable();

            // Act
            var response = await _advertisementServiceV1.GetPaged(
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
        public async Task GetPaged_Returns_Response_Success_Total_eq_0(
            GetPagedAdvertisementRequest request,
            CancellationToken cancellationToken)
        {
            // Arrange
            int contentCount = 0;

            var responce = new List<Domain.Advertisement>();

            _advertisementRepositoryMock
                .Setup(_ => _.Count(It.IsAny<CancellationToken>()))
                .ReturnsAsync(0)
                .Verifiable();

            _advertisementRepositoryMock
                .Setup(_ => _.GetPagedWithTagsAndOwnerAndCategoryInclude(
                    It.IsAny<int>(),
                    It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(responce);

            // Act
            var response = await _advertisementServiceV1.GetPaged(
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
        public async Task GetPaged_Throws_Exception_When_Request_Is_Null(
            GetPagedAdvertisementRequest request, 
            CancellationToken cancellationToken)
        {
            // Act
            await Assert.ThrowsAsync<ArgumentNullException>(
                async () => await _advertisementServiceV1.GetPaged(
                    request, 
                    cancellationToken));
        }
    }
}
