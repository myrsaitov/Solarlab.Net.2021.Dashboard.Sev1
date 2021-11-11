using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using AutoFixture.Xunit2;
using System.Collections.Generic;
using System.Linq;
using Sev1.Advertisements.Application.Exceptions.Advertisement;
using Sev1.Advertisements.Contracts.Contracts.GetPaged.Requests;
using Sev1.Advertisements.Application.Contracts.Tag;

namespace Sev1.Advertisements.Tests.Tag
{
    public partial class TagServiceV1Test
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request">DTO-модель</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Theory]
        [AutoData]
        public async Task GetPaged_Returns_Response_Success(
            GetPagedRequest request, 
            CancellationToken cancellationToken)
        {
            // Arrange
            int tagCount = 3;
            var responce = new List<Domain.Tag>();
            for (int tagId = 1; tagId <= tagCount; tagId++)
            {
                var tag = new Domain.Tag()
                {
                    Id = tagId,
                };
                responce.Add(tag);
            }

            _tagRepositoryMock
                .Setup(_ => _.Count(It.IsAny<CancellationToken>())) // проверяет, что параметр имеет указанный тип <>
                .ReturnsAsync(tagCount) // в результате выполнения возвращает объект
                .Verifiable(); // Verify all verifiable expectations on all mocks created through the repository

            _tagRepositoryMock
                .Setup(_ => _.GetPaged(
                    It.IsAny<int>(), // проверяет, что параметр имеет указанный тип <>
                    It.IsAny<int>(), // проверяет, что параметр имеет указанный тип <>
                    It.IsAny<CancellationToken>())) // проверяет, что параметр имеет указанный тип <>
                .ReturnsAsync(responce) // в результате выполнения возвращает объект
                .Verifiable(); // Verify all verifiable expectations on all mocks created through the repository

            // Act
            var response = await _tagServiceV1.GetPaged(
                request, 
                cancellationToken);

            // Assert
            _tagRepositoryMock.Verify(); // Вызывался ли данный мок?
            Assert.NotNull(response);
            Assert.Equal(tagCount, response.Total);
            Assert.Equal(tagCount, response.Items.Count());
            Assert.IsType<GetPagedTagDto>(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request">DTO-модель</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Theory]
        [AutoData]
        public async Task GetPaged_Returns_Response_Success_Total_eq_0(
            GetPagedRequest request,
            CancellationToken cancellationToken)
        {
            // Arrange
            var tagCount = 0;

            _tagRepositoryMock
                .Setup(_ => _.Count(It.IsAny<CancellationToken>())) // проверяет, что параметр имеет указанный тип <>
                .ReturnsAsync(tagCount) // в результате выполнения возвращает объект
                .Verifiable(); // Verify all verifiable expectations on all mocks created through the repository

            // Act
            var response = await _tagServiceV1.GetPaged(
                request,
                cancellationToken);

            // Assert
            _tagRepositoryMock.Verify(); // Вызывался ли данный мок?
            Assert.NotNull(response);
            Assert.Equal(
                tagCount,
                response.Total);
            Assert.Equal(
                tagCount,
                response.Items.Count());
            Assert.IsType<GetPagedTagDto>(response);
        }

        /// <summary>
        /// Проверка исключения при пустом запросе
        /// </summary>
        /// <param name="request">DTO-модель</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Theory]
        [InlineAutoData(null)]
        public async Task GetPaged_Throws_Exception_When_Request_Is_Null(
            GetPagedRequest request, 
            CancellationToken cancellationToken)
        {
            // Act
            await Assert.ThrowsAsync<GetPagedRequestNotValidException>(
                async () => await _tagServiceV1.GetPaged(
                    request, 
                    cancellationToken));
        }
    }
}