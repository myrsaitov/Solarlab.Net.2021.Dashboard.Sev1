﻿using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using AutoFixture.Xunit2;
using Sev1.Advertisements.Application.Exceptions.Domain;
using Sev1.Advertisements.Application.Exceptions.Advertisement;

namespace Sev1.Advertisements.Tests.Advertisement
{
    public partial class AdvertisementServiceV1Test
    {
        /// <summary>
        /// Проверка удачного удаления объявления пользователем-owner
        /// </summary>
        /// <param name="id">Идентификатор объявления</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Theory]
        [AutoData]
        public async Task Restore_ByOwner_Returns_Response_Success(
            int id,
            CancellationToken cancellationToken)
        {
            // Arrange

            // "Возвращаем" польователя, который "восстанавливает" это объявление
            _userProviderMock
                .Setup(_ => _.GetUserId())
                .Returns("24cb4b25-c819-45ab-8755-d95120fbb868") // возвращает в результате выполнения
                .Verifiable(); // Verify all verifiable expectations on all mocks created through the repository

            // "Достаем" объявление из базы
            var advertisement = new Domain.Advertisement()
            {
                OwnerId = "24cb4b25-c819-45ab-8755-d95120fbb868"
            };
            _advertisementRepositoryMock
                .Setup(_ => _.FindByIdWithTagsInclude(
                    It.IsAny<int>(), // проверяет, что параметр имеет указанный тип <>
                    It.IsAny<CancellationToken>())) // проверяет, что параметр имеет указанный тип <>
                .ReturnsAsync(advertisement) // в результате выполнения возвращает объект
                .Callback(( // Используем передаваемые в мок аргументы для имитации логики
                    int _advertisementId,
                    CancellationToken ct) => advertisement.Id = _advertisementId)
                .Verifiable(); // Verify all verifiable expectations on all mocks created through the repository

            // "Сохраняем" объявление в базу
            _advertisementRepositoryMock
                .Setup(_ => _.Save(
                    It.IsAny<Domain.Advertisement>(), // проверяет, что параметр имеет указанный тип <>
                    It.IsAny<CancellationToken>())) // проверяет, что параметр имеет указанный тип <>
                .Callback(( // Используем передаваемые в мок аргументы для имитации логики
                    Domain.Advertisement advertisement,
                    CancellationToken ct) => advertisement.Id = id);

            // Act
            await _advertisementServiceV1.Restore(
                id,
                cancellationToken);

            // Assert
            _userProviderMock.Verify(); // Вызывался ли данный мок?
            _advertisementRepositoryMock.Verify(); // Вызывался ли данный мок?
        }

        /// <summary>
        /// Проверка исключения, если пользователь 
        /// не имеет права удалить объявление
        /// </summary>
        /// <param name="id">Идентификатор объявления</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Theory]
        [AutoData]
        public async Task Restore_Throws_Exception_When_No_Rights(
            int id,
            CancellationToken cancellationToken)
        {
            // Arrange

            // "Возвращаем" польователя, который "восстанавливает" это объявление
            _userProviderMock
                .Setup(_ => _.GetUserId())
                .Returns("dd1de902-f2e1-4248-8481-b3b0e3d76837") // возвращает в результате выполнения
                .Verifiable(); // Verify all verifiable expectations on all mocks created through the repository

            // "Возвращаем" объявление из базы
            var advertisement = new Domain.Advertisement()
            {
                OwnerId = "24cb4b25-c819-45ab-8755-d95120fbb868"
            };
            _advertisementRepositoryMock
                .Setup(_ => _.FindByIdWithTagsInclude(
                    It.IsAny<int>(), // проверяет, что параметр имеет указанный тип <>
                    It.IsAny<CancellationToken>())) // проверяет, что параметр имеет указанный тип <>
                .ReturnsAsync(advertisement) // в результате выполнения возвращает объект
                .Callback(( // Используем передаваемые в мок аргументы для имитации логики
                    int _advertisementId,
                    CancellationToken ct) => advertisement.Id = _advertisementId);

            // "Сохраняем" объявление в базу
            _advertisementRepositoryMock
                .Setup(_ => _.Save(
                    It.IsAny<Domain.Advertisement>(), // проверяет, что параметр имеет указанный тип <>
                    It.IsAny<CancellationToken>())) // проверяет, что параметр имеет указанный тип <>
                .Callback(( // Используем передаваемые в мок аргументы для имитации логики
                    Domain.Advertisement advertisement,
                    CancellationToken ct) => advertisement.Id = id);

            // Act
            await Assert.ThrowsAsync<NoRightsException>(
                async () => await _advertisementServiceV1.Restore(
                    id,
                    cancellationToken));
        }

        /// <summary>
        /// Проверка исключения, если в базе нет объявления с таким Id
        /// </summary>
        /// <param name="id">Идентификатор объявления</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Theory]
        [AutoData]
        public async Task Restore_Throws_Exception_When_Advertisement_Is_Null(
            int id,
            CancellationToken cancellationToken)
        {
            // Arrange

            // "Достаем" объявление из базы
            Domain.Advertisement advertisement = null;
            _advertisementRepositoryMock
                .Setup(_ => _.FindByIdWithTagsInclude(
                    It.IsAny<int>(), // проверяет, что параметр имеет указанный тип <>
                    It.IsAny<CancellationToken>())) // проверяет, что параметр имеет указанный тип <>
                .ReturnsAsync(advertisement); // в результате выполнения возвращает объект

            // Act
            await Assert.ThrowsAsync<AdvertisementNotFoundException>(
                async () => await _advertisementServiceV1.Restore(
                    id,
                    cancellationToken));
        }

        /// <summary>
        /// Проверка исключения, если не прошли валидацию Id
        /// </summary>
        /// <param name="id">Идентификатор объявления</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Theory]
        [InlineAutoData(null, null)]
        public async Task Restore_Throws_Exception_When_Id_Is_Not_Valid(
            int id,
            CancellationToken cancellationToken)
        {
            // Act
            await Assert.ThrowsAsync<AdvertisementIdNotValidException>(
                async () => await _advertisementServiceV1.Restore(
                    id,
                    cancellationToken));
        }
    }
}