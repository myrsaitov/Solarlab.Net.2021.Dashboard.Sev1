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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <param name="userId"></param>
        /// <param name="advertisementTitle"></param>
        /// <param name="advertisementBody"></param>
        /// <param name="tagBodies"></param>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        [Theory]
        [AutoData]
        public async Task GetPaged_Returns_Response_Success(
            GetPagedAdvertisementRequest request, 
            CancellationToken cancellationToken, 
            int userId,
            string advertisementTitle,
            string advertisementBody,
            string[] tagBodies,
            int categoryId)
        {
            // Arrange
            int advertisementCount = 3;

            var responce = new List<Domain.Advertisement>();

            for (int advertisementId = 1; advertisementId <= advertisementCount; advertisementId++)
            {
                var advertisement = new Domain.Advertisement()
                {
                    Id = advertisementId,
                    Title = advertisementTitle,
                    Body = advertisementBody,
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
                    advertisement.Tags.Add(tag);
                }
                responce.Add(advertisement);
            }

            _advertisementRepositoryMock
                .Setup(_ => _.Count(It.IsAny<CancellationToken>())) // проверяет, что параметр имеет указанный тип <>
                .ReturnsAsync(advertisementCount) // в результате выполнения возвращает объект
                .Verifiable(); // Verify all verifiable expectations on all mocks created through the repository

            _advertisementRepositoryMock
                .Setup(_ => _.GetPagedWithTagsAndCategoryInclude(
                    It.IsAny<int>(), // проверяет, что параметр имеет указанный тип <>
                    It.IsAny<int>(), // проверяет, что параметр имеет указанный тип <>
                    It.IsAny<CancellationToken>())) // проверяет, что параметр имеет указанный тип <>
                .ReturnsAsync(responce) // в результате выполнения возвращает объект
                .Verifiable(); // Verify all verifiable expectations on all mocks created through the repository

            // Act
            var response = await _advertisementServiceV1.GetPaged(
                request, 
                cancellationToken);

            // Assert
            _advertisementRepositoryMock.Verify(); // Вызывался ли данный мок?
            Assert.NotNull(response);
            Assert.Equal(advertisementCount, response.Total);
            Assert.Equal(advertisementCount, response.Items.Count());
            Assert.IsType<GetPagedResponse<AdvertisementPagedDto>>(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Theory]
        [AutoData]
        public async Task GetPaged_Returns_Response_Success_Total_eq_0(
            GetPagedAdvertisementRequest request,
            CancellationToken cancellationToken)
        {
            // Arrange
            int advertisementCount = 0;

            var responce = new List<Domain.Advertisement>();

            _advertisementRepositoryMock
                .Setup(_ => _.Count(It.IsAny<CancellationToken>())) // проверяет, что параметр имеет указанный тип <>
                .ReturnsAsync(0) // в результате выполнения возвращает объект
                .Verifiable(); // Verify all verifiable expectations on all mocks created through the repository

            _advertisementRepositoryMock
                .Setup(_ => _.GetPagedWithTagsAndCategoryInclude(
                    It.IsAny<int>(), // проверяет, что параметр имеет указанный тип <>
                    It.IsAny<int>(), // проверяет, что параметр имеет указанный тип <>
                    It.IsAny<CancellationToken>())) // проверяет, что параметр имеет указанный тип <>
                .ReturnsAsync(responce); // в результате выполнения возвращает объект

            // Act
            var response = await _advertisementServiceV1.GetPaged(
                request,
                cancellationToken);

            // Assert
            _advertisementRepositoryMock.Verify(); // Вызывался ли данный мок?
            Assert.NotNull(response);
            Assert.Equal(advertisementCount, response.Total);
            Assert.Equal(advertisementCount, response.Items.Count());
            Assert.IsType<GetPagedResponse<AdvertisementPagedDto>>(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
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