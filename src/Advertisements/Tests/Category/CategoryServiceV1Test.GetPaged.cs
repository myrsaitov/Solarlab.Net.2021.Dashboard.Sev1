using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using AutoFixture.Xunit2;
using System.Collections.Generic;
using Sev1.Advertisements.Application.Contracts.Category;
using System.Linq;
using System;
using Sev1.Advertisements.Application.Contracts.GetPaged;

namespace Sev1.Advertisements.Tests.Category
{
    public partial class CategoryServiceV1Test
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [Theory]
        [AutoData]
        public async Task GetPaged_Returns_Response_Success(
            GetPagedRequest request, 
            CancellationToken cancellationToken)
        {
            // Arrange
            int categoryCount = 3;

            var responce = new List<Domain.Category>();

            for (int categoryId = 1; categoryId <= categoryCount; categoryId++)
            {
                var category = new Domain.Category()
                {
                    Id = categoryId,
                };

                responce.Add(category);
            }

            _categoryRepositoryMock
                .Setup(_ => _.Count(It.IsAny<CancellationToken>()))
                .ReturnsAsync(categoryCount)
                .Verifiable();

            _categoryRepositoryMock
                .Setup(_ => _.GetPaged(
                    It.IsAny<int>(),
                    It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(responce)
                .Verifiable();

            // Act
            var response = await _categoryServiceV1.GetPaged(
                request, 
                cancellationToken);

            // Assert
            _categoryRepositoryMock.Verify();
            Assert.NotNull(response);
            Assert.Equal(categoryCount, response.Total);
            Assert.Equal(categoryCount, response.Items.Count());
            Assert.IsType<GetPagedResponse<CategoryDto>>(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [Theory]
        [AutoData]
        public async Task GetPaged_Returns_Response_Success_Total_eq_0(
            GetPagedRequest request,
            CancellationToken cancellationToken)
        {
            // Arrange
            int categoryCount = 0;

            var responce = new List<Domain.Category>();

            _categoryRepositoryMock
                .Setup(_ => _.Count(It.IsAny<CancellationToken>()))
                .ReturnsAsync(categoryCount)
                .Verifiable();

            // Act
            var response = await _categoryServiceV1.GetPaged(
                request,
                cancellationToken);

            // Assert
            _categoryRepositoryMock.Verify();
            Assert.NotNull(response);
            Assert.Equal(categoryCount, response.Total);
            Assert.Equal(categoryCount, response.Items.Count());
            Assert.IsType<GetPagedResponse<CategoryDto>>(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [Theory]
        [InlineAutoData(null)]
        public async Task GetPaged_Throws_Exception_When_Request_Is_Null(
            GetPagedRequest request, 
            CancellationToken cancellationToken)
        {
            // Act
            await Assert.ThrowsAsync<ArgumentNullException>(
                async () => await _categoryServiceV1.GetPaged(
                    request, 
                    cancellationToken));
        }
    }
}