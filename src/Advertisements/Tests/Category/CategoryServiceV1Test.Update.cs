﻿using Sev1.Advertisements.Application.Contracts.Category;
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
        /// <param name="request">DTO-модель</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <param name="userId"></param>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        [Theory]
        [AutoData]
        public async Task Update_Returns_Response_Success(
            string accessToken,
            CategoryUpdateDto request,
            CancellationToken cancellationToken,
            int userId,
            int categoryId)
        {
            // Arrange
            var category = new Domain.Category()
            {
                Id = categoryId
            };

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
                .Setup(_ => _.FindById(
                    It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(category)
                .Callback((
                    int _categoryId,
                    CancellationToken ct) => category.Id = _categoryId)
                .Verifiable();

            _categoryRepositoryMock
                .Setup(_ => _.FindById(
                    It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(category)
                .Callback(() => category.Id = categoryId)
                .Verifiable();

            _categoryRepositoryMock
                .Setup(_ => _.Save(
                    It.IsAny<Domain.Category>(),
                    It.IsAny<CancellationToken>()))
                .Callback((
                    Domain.Category category,
                    CancellationToken ct) => category.Id = categoryId);

            // Act
            var response = await _categoryServiceV1.Update(
                accessToken,
                request, 
                cancellationToken);

            // Assert
            _categoryRepositoryMock.Verify(); // Вызывался ли данный мок?
            Assert.NotNull(response);
            Assert.NotEqual(default, response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessToken">JWT Token, который пришел с запросом</param>
        /// <param name="request">DTO-модель</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        [Theory]
        [AutoData]
        public async Task Update_Throws_Exception_When_No_Rights(
            string accessToken,
            CategoryUpdateDto request,
            CancellationToken cancellationToken,
            int categoryId)
        {
            // Arrange
            var category = new Domain.Category()
            {
                Id = categoryId
            };

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
                async () => await _categoryServiceV1.Update(
                    accessToken,
                    request,
                    cancellationToken));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessToken">JWT Token, который пришел с запросом</param>
        /// <param name="request">DTO-модель</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Theory]
        [AutoData]
        public async Task Update_Throws_Exception_When_Category_Is_Null(
            string accessToken,
            CategoryUpdateDto request,
            CancellationToken cancellationToken)
        {
            // Act
            await Assert.ThrowsAsync<CategoryNotFoundException>(
                async () => await _categoryServiceV1.Update(
                    accessToken,
                    request,
                    cancellationToken));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessToken">JWT Token, который пришел с запросом</param>
        /// <param name="request">DTO-модель</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Theory]
        [InlineAutoData(null)]
        public async Task Update_Throws_Exception_When_Request_Is_Null(
            string accessToken,
            CategoryUpdateDto request,
            CancellationToken cancellationToken)
        {
            // Act
            await Assert.ThrowsAsync<ArgumentNullException>(
                async () => await _categoryServiceV1.Update(
                    accessToken,
                    request, 
                    cancellationToken));
        }
    }
}