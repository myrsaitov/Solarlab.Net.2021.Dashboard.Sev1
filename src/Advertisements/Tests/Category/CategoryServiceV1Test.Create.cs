﻿using Sev1.Advertisements.Application.Contracts.Category;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using AutoFixture.Xunit2;
using System;
using Sev1.Advertisements.Domain.Exceptions;

namespace Sev1.Advertisements.Tests.Category
{
    public partial class CategoryServiceV1Test
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="userId"></param>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        [Theory]
        [AutoData]
        public async Task Create_Returns_Response_Success(
            string accessToken,
            CategoryCreateDto request,
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
            var response = await _categoryServiceV1.Create(
                accessToken,
                request,
                cancellationToken);

            // Assert
            _categoryRepositoryMock.Verify();
            Assert.NotNull(response);
            Assert.NotEqual(default, response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [Theory]
        [AutoData]
        public async Task Create_Throws_Exception_When_No_Rights(
            string accessToken,
            CategoryCreateDto request,
            CancellationToken cancellationToken)
        {
            // Arrange
            var category = new Domain.Category();

            // Act
            await Assert.ThrowsAsync<NoRightsException>(
                async () => await _categoryServiceV1.Create(
                    accessToken,
                    request,
                    cancellationToken));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [Theory]
        [InlineAutoData(null)]
        public async Task Create_Throws_Exception_When_Request_Is_Null(
            string accessToken,
            CategoryCreateDto request, 
            CancellationToken cancellationToken)
        {
            // Act
            await Assert.ThrowsAsync<ArgumentNullException>(
                async () => await _categoryServiceV1.Create(
                    accessToken,
                    request,
                    cancellationToken));
        }
    }
}