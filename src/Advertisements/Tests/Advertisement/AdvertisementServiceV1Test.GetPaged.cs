using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using AutoFixture.Xunit2;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Linq.Expressions;
using Sev1.Advertisements.Contracts.Contracts.GetPaged.Requests;
using Sev1.Advertisements.Contracts.Contracts.GetPaged.Responses;
using Sev1.Advertisements.AppServices.Services.Advertisement.Exceptions;

namespace Sev1.Advertisements.Tests.Advertisement
{
    public partial class AdvertisementServiceV1Test
    {
        private async Task GetPaged_Returns_Response_Success(
            AdvertisementGetPagedRequest request,
            CancellationToken cancellationToken,
            string advertisementTitle, // Сгенерированный заголовок объявления
            string advertisementBody,  // Сгенерированный текст объявления
            string[] tagBodies)
        {
            // Генерируем список объявлений (3 шт)
            var advertisementCount = 3; // Количество сгенерированных объявлений
            var UserId = "24cb4b25-c819-45ab-8755-d95120fbb868";
            var categoryId = 1;
            var response = new List<Domain.Advertisement>();
            for (int? advertisementId = 1; advertisementId <= advertisementCount; advertisementId++)
            {
                // Создаем новое объявление
                var advertisement = new Domain.Advertisement()
                {
                    Id = advertisementId,
                    Title = advertisementTitle,
                    Body = advertisementBody,
                    OwnerId = UserId,
                    Category = new Domain.Category()
                    {
                        Id = categoryId++
                    },
                    Tags = new List<Domain.Tag>()
                };

                // Заполняем таги
                int? tagId = 1;
                foreach (string body in tagBodies)
                {
                    var tag = new Domain.Tag()
                    {
                        Id = tagId++,
                        Body = body
                    };
                    advertisement.Tags.Add(tag);
                }
                response.Add(advertisement);
            }

            // "Подсчёт" количества объявлений с заданным критерием в базе
            _advertisementRepositoryMock
                .Setup(_ => _.CountActive(
                    It.IsAny<Expression<Func<Domain.Advertisement, bool>>>(), // проверяет, что параметр имеет указанный тип <>
                    It.IsAny<CancellationToken>())) // проверяет, что параметр имеет указанный тип <>
                .ReturnsAsync(advertisementCount) // в результате выполнения возвращает объект
                .Verifiable(); // Verify all verifiable expectations on all mocks created through the repository

            _advertisementRepositoryMock
                .Setup(_ => _.GetPagedWithTagsAndCategoryInclude(
                    It.IsAny<Expression<Func<Domain.Advertisement, bool>>>(), // проверяет, что параметр имеет указанный тип <>
                    It.IsAny<int>(), // проверяет, что параметр имеет указанный тип <>
                    It.IsAny<int>(), // проверяет, что параметр имеет указанный тип <>
                    It.IsAny<CancellationToken>())) // проверяет, что параметр имеет указанный тип <>
                .ReturnsAsync(response) // в результате выполнения возвращает объект
                .Verifiable(); // Verify all verifiable expectations on all mocks created through the repository

            // Act
            var res = await _advertisementServiceV1.GetPaged(
                request,
                cancellationToken);

            // Assert
            _advertisementRepositoryMock.Verify(); // Вызывался ли данный мок?
            Assert.NotNull(res);
            Assert.Equal(advertisementCount, res.Total);
            Assert.Equal(advertisementCount, res.Items.Count());
            Assert.IsType<AdvertisementGetPagedResponse>(res);
        }

        /// <summary>
        /// Проверка удачного запроса объявлений с пагинацией
        /// </summary>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <param name="advertisementTitle">Заголовок объявления</param>
        /// <param name="advertisementBody">Текст объявления</param>
        /// <param name="tagBodies">Таги</param>
        /// <returns></returns>
        [Theory]
        [AutoData]
        public async Task GetPaged_NoFilter_Returns_Response_Success(
            CancellationToken cancellationToken,
            string advertisementTitle, // Сгенерированный заголовок объявления
            string advertisementBody,  // Сгенерированный текст объявления
            string[] tagBodies)        // Сгенерированные таги
        {
            // Параметры поиска:
            var request = new AdvertisementGetPagedRequest()
            {
                Page = 0,
                PageSize = 10,
                SearchStr = null,
                CategoryId = null,
                Tag = null,
                OwnerId = null
            };

            await GetPaged_Returns_Response_Success(
                request,
                cancellationToken,
                advertisementTitle,
                advertisementBody,
                tagBodies);
        }

        /// <summary>
        /// Проверка удачного запроса объявлений с пагинацией c поиском по SearchStr
        /// </summary>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <param name="advertisementTitle">Заголовок объявления</param>
        /// <param name="advertisementBody">Текст объявления</param>
        /// <param name="tagBodies">Таги</param>
        /// <returns></returns>
        [Theory]
        [AutoData]
        public async Task GetPaged_BySearchStr_Returns_Response_Success(
            CancellationToken cancellationToken,
            string advertisementTitle, // Сгенерированный заголовок объявления
            string advertisementBody,  // Сгенерированный текст объявления
            string[] tagBodies)        // Сгенерированные таги
        {
            // Параметры поиска:
            var request = new AdvertisementGetPagedRequest()
            {
                Page = 0,
                PageSize = 10,
                SearchStr = "search_str",
                CategoryId = null,
                Tag = null,
                OwnerId = null
            };

            await GetPaged_Returns_Response_Success(
               request,
               cancellationToken,
               advertisementTitle,
               advertisementBody,
               tagBodies);
        }

        /// <summary>
        /// Проверка удачного запроса объявлений с пагинацией с поиском по CategoryId
        /// </summary>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <param name="advertisementTitle">Заголовок объявления</param>
        /// <param name="advertisementBody">Текст объявления</param>
        /// <param name="tagBodies">Таги</param>
        /// <returns></returns>
        [Theory]
        [AutoData]
        public async Task GetPaged_ByCategoryId_Returns_Response_Success(
            CancellationToken cancellationToken,
            string advertisementTitle, // Сгенерированный заголовок объявления
            string advertisementBody,  // Сгенерированный текст объявления
            string[] tagBodies)        // Сгенерированные таги
        {
            // Параметр поиска:
            var request = new AdvertisementGetPagedRequest()
            {
                Page = 0,
                PageSize = 10,
                SearchStr = null,
                CategoryId = 3,
                Tag = null,
                OwnerId = null
            };

            await GetPaged_Returns_Response_Success(
                request,
                cancellationToken,
                advertisementTitle,
                advertisementBody,
                tagBodies);
        }

        /// <summary>
        /// Проверка удачного запроса объявлений с пагинацией с поиском по Tag
        /// </summary>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <param name="advertisementTitle">Заголовок объявления</param>
        /// <param name="advertisementBody">Текст объявления</param>
        /// <param name="tagBodies">Таги</param>
        /// <returns></returns>
        [Theory]
        [AutoData]
        public async Task GetPaged_ByTag_Returns_Response_Success(
            CancellationToken cancellationToken,
            string advertisementTitle, // Сгенерированный заголовок объявления
            string advertisementBody,  // Сгенерированный текст объявления
            string[] tagBodies)        // Сгенерированные таги
        {
            // Параметры поиска:
            var request = new AdvertisementGetPagedRequest()
            {
                Page = 0,
                PageSize = 10,
                SearchStr = null,
                CategoryId = null,
                Tag = "tag",
                OwnerId = null
            };

            await GetPaged_Returns_Response_Success(
                request,
                cancellationToken,
                advertisementTitle,
                advertisementBody,
                tagBodies);
        }

        /// <summary>
        /// Проверка удачного запроса объявлений с пагинацией с поиском по Tag
        /// </summary>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <param name="advertisementTitle">Заголовок объявления</param>
        /// <param name="advertisementBody">Текст объявления</param>
        /// <param name="tagBodies">Таги</param>
        /// <returns></returns>
        [Theory]
        [AutoData]
        public async Task GetPaged_ByUserId_Returns_Response_Success(
            CancellationToken cancellationToken,
            string advertisementTitle, // Сгенерированный заголовок объявления
            string advertisementBody,  // Сгенерированный текст объявления
            string[] tagBodies)        // Сгенерированные таги
        {
            // Параметры поиска:
            var request = new AdvertisementGetPagedRequest()
            {
                Page = 0,
                PageSize = 10,
                SearchStr = null,
                CategoryId = null,
                Tag = null,
                OwnerId = "24cb4b25-c819-45ab-8755-d95120fbb868"
            };

            await GetPaged_Returns_Response_Success(
                request,
                cancellationToken,
                advertisementTitle,
                advertisementBody,
                tagBodies);
        }

        /// <summary>
        /// Проверка исключения, если аргумент не проходит валидацию
        /// </summary>
        /// <param name="id">Идентификатор объявления</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Theory]
        [InlineAutoData(null, null)]
        public async Task GetPaged_Throws_Exception_When_Request_Is_Null(
            AdvertisementGetPagedRequest request,
            CancellationToken cancellationToken)
        {
            // Act
            await Assert.ThrowsAsync<AdvertisementGetPagedRequestNotValidException>(
                async () => await _advertisementServiceV1.GetPaged(
                request,
                cancellationToken)); ;
        }
    }
}