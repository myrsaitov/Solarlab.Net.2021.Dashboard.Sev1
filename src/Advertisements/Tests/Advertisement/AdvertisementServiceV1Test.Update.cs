using Sev1.Advertisements.Application.Contracts.Advertisement;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using AutoFixture.Xunit2;
using System.Linq.Expressions;
using System;
using Sev1.Advertisements.Application.Exceptions;
using Sev1.Advertisements.Domain.Exceptions;

namespace Sev1.Advertisements.Tests.Advertisement
{
    public partial class AdvertisementServiceV1Test
    {
        [Theory]
        [AutoData]
        public async Task Update_Returns_Response_Success(
            AdvertisementUpdateDto request,
            CancellationToken cancellationToken,
            int userId,
            int contentId,
            int categoryId)
        {
            // Arrange
            var category = new Domain.Category()
            {
                Id = categoryId
            };

            var content = new Domain.Advertisement()
            {
                Id = contentId,

                CategoryId = categoryId
            };

            int tagId = 1;

            _advertisementRepositoryMock
                .Setup(_ => _.FindByIdWithUserAndCategoryAndTags(
                    It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(content)
                .Callback((int _advertisementId, CancellationToken ct) => content.Id = _advertisementId)
                .Verifiable();


            _categoryRepositoryMock
                .Setup(_ => _.FindById(
                    It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(category)
                .Callback((int _categoryId, CancellationToken ct) => category.Id = _categoryId)
                .Verifiable();


            _categoryRepositoryMock
                .Setup(_ => _.FindById(
                    It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(category)
                .Callback(() => category.Id = categoryId)
                .Verifiable();

            _tagRepositoryMock
                .Setup(_ => _.FindWhere(
                    It.IsAny<Expression<Func<Domain.Tag, bool>>>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(() => new Domain.Tag()
                {
                    Id = tagId,
                    Body = request.TagBodies[tagId++ - 1]
                })
                .Verifiable();

            _tagRepositoryMock
                .Setup(_ => _.Save(
                    It.IsAny<Domain.Tag>(),
                    It.IsAny<CancellationToken>()));

            _advertisementRepositoryMock
                .Setup(_ => _.Save(
                    It.IsAny<Domain.Advertisement>(),
                    It.IsAny<CancellationToken>()))
                .Callback((Domain.Advertisement content, CancellationToken ct) => content.Id = contentId);

            // Act
            var response = await _advertisementServiceV1.Update(
                request, 
                cancellationToken);

            // Assert
            _advertisementRepositoryMock.Verify();
            _categoryRepositoryMock.Verify();
            _tagRepositoryMock.Verify();
            Assert.NotNull(response);
            Assert.NotEqual(default, response);
        }
        [Theory]
        [AutoData]
        public async Task Update_Throws_Exception_When_Category_is_Null(
            AdvertisementUpdateDto request,
            CancellationToken cancellationToken,
            int userId,
            int contentId)
        {
            // Arrange
            var content = new Domain.Advertisement()
            {
                Id = contentId,

            };

            _advertisementRepositoryMock
                .Setup(_ => _.FindByIdWithUserAndCategoryAndTags(
                    It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(content)
                .Callback((int _advertisementId, CancellationToken ct) => content.Id = _advertisementId);


            // Act
            await Assert.ThrowsAsync<CategoryNotFoundException>(
                async () => await _advertisementServiceV1.Update(
                    request,
                    cancellationToken));
        }
        [Theory]
        [AutoData]
        public async Task Update_Throws_Exception_When_No_Rights(
            AdvertisementUpdateDto request,
            CancellationToken cancellationToken,
            int userId,
            int contentId)
        {
            // Arrange
            var content = new Domain.Advertisement()
            {
                Id = contentId,

            };

            _advertisementRepositoryMock
                .Setup(_ => _.FindByIdWithUserAndCategoryAndTags(
                    It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(content)
                .Callback((int _advertisementId, CancellationToken ct) => content.Id = _advertisementId);


            // Act
            await Assert.ThrowsAsync<NoRightsException>(
                async () => await _advertisementServiceV1.Update(
                    request,
                    cancellationToken));
        }
        [Theory]
        [AutoData]
        public async Task Update_Throws_Exception_When_Advertisement_Is_Null(
            AdvertisementUpdateDto request,
            CancellationToken cancellationToken)
        {
            // Act
            await Assert.ThrowsAsync<AdvertisementNotFoundException>(
                async () => await _advertisementServiceV1.Update(
                    request,
                    cancellationToken));
        }
        [Theory]
        [InlineAutoData(null)]
        public async Task Update_Throws_Exception_When_Request_Is_Null(
            AdvertisementUpdateDto request,
            CancellationToken cancellationToken)
        {
            // Act
            await Assert.ThrowsAsync<ArgumentNullException>(
                async () => await _advertisementServiceV1.Update(
                    request, 
                    cancellationToken));
        }
    }
}
