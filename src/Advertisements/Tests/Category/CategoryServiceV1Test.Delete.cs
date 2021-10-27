using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using AutoFixture.Xunit2;
using System;
using Sev1.Advertisements.Domain.Exceptions;
using Sev1.Advertisements.Application.Exceptions.Category;

namespace Sev1.Advertisements.Tests.Category
{
    public partial class CategoryServiceV1Test
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessToken">JWT Token, который пришел с запросом</param>
        /// <param name="id"></param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <param name="userId"></param>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        [Theory]
        [AutoData]
        public async Task Delete_Returns_Response_Success(
            string accessToken,
            int id, 
            CancellationToken cancellationToken, 
            int userId,
            int categoryId)
        {
            // Arrange
            var category = new Domain.Category();

            _categoryRepositoryMock
                .Setup(_ => _.FindById(
                    It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(category)
                .Callback((
                    int _categoryId,
                    CancellationToken ct) => category.Id = _categoryId)
                .Verifiable();

            _categoryRepositoryMock
                .Setup(_ => _.Save(
                    It.IsAny<Domain.Category>(),
                    It.IsAny<CancellationToken>()))
                .Callback((
                    Domain.Category category,
                    CancellationToken ct) => category.Id = categoryId);

            // Act
            await _categoryServiceV1.Delete(
                accessToken,
                id, 
                cancellationToken);

            // Assert
            _categoryRepositoryMock.Verify(); // Вызывался ли данный мок?
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessToken">JWT Token, который пришел с запросом</param>
        /// <param name="id"></param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Theory]
        [AutoData]
        public async Task Delete_Throws_Exception_When_No_Rights(
            string accessToken,
            int id,
            CancellationToken cancellationToken)
        {
            // Arrange
            var category = new Domain.Category();

            _categoryRepositoryMock
                .Setup(_ => _.FindById(
                    It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(category)
                .Callback((
                    int _categoryId,
                    CancellationToken ct) => category.Id = _categoryId);

            // Act
            await Assert.ThrowsAsync<NoRightsException>(
                async () => await _categoryServiceV1.Delete(
                    accessToken,
                    id,
                    cancellationToken));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessToken">JWT Token, который пришел с запросом</param>
        /// <param name="id"></param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Theory]
        [AutoData]
        public async Task Delete_Throws_Exception_When_Category_Is_Null(
            string accessToken,
            int id,
            CancellationToken cancellationToken)
        {
            // Act
            await Assert.ThrowsAsync<CategoryNotFoundException>(
                async () => await _categoryServiceV1.Delete(
                    accessToken,
                    id,
                    cancellationToken));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessToken">JWT Token, который пришел с запросом</param>
        /// <param name="id"></param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Theory]
        [InlineAutoData(null)]
        public async Task Delete_Throws_Exception_When_Request_Is_Null(
            string accessToken,
            int id, 
            CancellationToken cancellationToken)
        {
            // Act
            await Assert.ThrowsAsync<ArgumentNullException>(
                async () => await _categoryServiceV1.Delete(
                    accessToken,
                    id, 
                    cancellationToken));
        }
    }
}