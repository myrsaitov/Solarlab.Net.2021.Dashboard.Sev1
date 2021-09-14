using Sev1.Advertisements.Application.Contracts.Category;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using AutoFixture.Xunit2;
using System;
using Sev1.Advertisements.Application.Exceptions;
using Sev1.Advertisements.Domain.Exceptions;

namespace Sev1.Advertisements.Tests.Category
{
    public partial class CategoryServiceV1Test
    {
        [Theory]
        [AutoData]
        public async Task Restore_Returns_Response_Success(
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
                .Callback((int _categoryId, CancellationToken ct) => category.Id = _categoryId)
                .Verifiable();



            _categoryRepositoryMock
                .Setup(_ => _.Save(
                    It.IsAny<Domain.Category>(),
                    It.IsAny<CancellationToken>()))
                .Callback((Domain.Category category, CancellationToken ct) => category.Id = categoryId);

            // Act
            await _categoryServiceV1.Restore(
                id, 
                cancellationToken);

            // Assert
            _categoryRepositoryMock.Verify();
        }
        [Theory]
        [AutoData]
        public async Task Restore_Throws_Exception_When_No_Rights(
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
                .Callback((int _categoryId, CancellationToken ct) => category.Id = _categoryId)
                .Verifiable();



            // Act
            await Assert.ThrowsAsync<NoRightsException>(
                async () => await _categoryServiceV1.Restore(
                    id,
                    cancellationToken));
        }
        [Theory]
        [AutoData]
        public async Task Restore_Throws_Exception_When_Category_Is_Null(
            int id,
            CancellationToken cancellationToken)
        {
            // Act
            await Assert.ThrowsAsync<CategoryNotFoundException>(
                async () => await _categoryServiceV1.Restore(
                    id,
                    cancellationToken));
        }
        [Theory]
        [InlineAutoData(null)]
        public async Task Restore_Throws_Exception_When_Request_Is_Null(
            int id, 
            CancellationToken cancellationToken)
        {
            // Act
            await Assert.ThrowsAsync<ArgumentNullException>(
                async () => await _categoryServiceV1.Restore(
                    id, 
                    cancellationToken));
        }
    }
}
