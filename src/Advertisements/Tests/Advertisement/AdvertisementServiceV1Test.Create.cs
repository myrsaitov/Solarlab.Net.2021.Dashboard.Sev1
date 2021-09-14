using Sev1.Advertisements.Application.Contracts.Advertisement;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using AutoFixture.Xunit2;
using System.Linq.Expressions;
using System;
using Sev1.Advertisements.Application.Exceptions;

namespace Sev1.Advertisements.Tests.Advertisement
{
    public partial class AdvertisementServiceV1Test
    {
        [Theory]
        [AutoData]
        public async Task Create_Returns_Response_Success(
            Create.Request request, 
            CancellationToken cancellationToken, 
            int userId, 
            int contentId)
        {
            // Arrange
            var category = new Domain.Category();

            int tagId = 1;



            _categoryRepositoryMock
                .Setup(_ => _.FindById(
                    It.IsAny<int>(), 
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(category)
                .Callback((int _categoryId, CancellationToken ct) => category.Id = _categoryId)
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
            var response = await _advertisementServiceV1.Create(
                request, 
                cancellationToken);

            // Assert
            _advertisementRepositoryMock.Verify();
            _categoryRepositoryMock.Verify();
            _tagRepositoryMock.Verify();
            Assert.NotNull(response);
            Assert.NotEqual(default, response.Id);
        }
        [Theory]
        [AutoData]
        public async Task Create_Throws_Exception_When_Category_Is_Null(
        Create.Request request,
            CancellationToken cancellationToken)
        {
            // Act
            await Assert.ThrowsAsync<CategoryNotFoundException>(
                async () => await _advertisementServiceV1.Create(
                    request,
                    cancellationToken));
        }
        [Theory]
        [InlineAutoData(null)]
        public async Task Create_Throws_Exception_When_Request_Is_Null(
            Create.Request request, 
            CancellationToken cancellationToken)
        {
            // Act
            await Assert.ThrowsAsync<ArgumentNullException>(
                async () => await _advertisementServiceV1.Create(
                    request, 
                    cancellationToken));
        }
    }
}
