using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using AutoFixture.Xunit2;
using System;
using Sev1.Advertisements.Domain.Exceptions;
using Sev1.Advertisements.Application.Exceptions.Advertisement;
using Advertisements.Contracts;

namespace Sev1.Advertisements.Tests.Advertisement
{
    public partial class AdvertisementServiceV1Test
    {
        /// <summary>
        /// Проверка удачного удаления объявления пользователем-owner
        /// </summary>
        /// <param name="accessToken">JWT Token, который пришел с запросом</param>
        /// <param name="id">Id объявления</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Theory]
        [AutoData]
        public async Task Delete_ByOwner_Returns_Response_Success(
            string accessToken,
            int id, 
            CancellationToken cancellationToken)
        {
            // Arrange

            // Чтобы пройти проверку на авторизацию
            var autorizedStatus = new GetAutorizedStatusResponse()
            {
                UserId = "24cb4b25-c819-45ab-8755-d95120fbb868",
                Role = "user"
            };
            _userRepositoryMock
                .Setup(_ => _.GetAutorizedStatus(
                It.IsAny<string>(), // проверяет, что параметр имеет указанный тип <>
                It.IsAny<CancellationToken>())) // проверяет, что параметр имеет указанный тип <>
                .ReturnsAsync(autorizedStatus) // в результате выполнения возвращает объект
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
            await _advertisementServiceV1.Delete(
                accessToken,
                id, 
                cancellationToken);

            // Assert
            _userRepositoryMock.Verify(); // Вызывался ли данный мок?
            _advertisementRepositoryMock.Verify(); // Вызывался ли данный мок?
        }

        /// <summary>
        /// Проверка удачного удаления объявления модератором
        /// </summary>
        /// <param name="accessToken">JWT Token, который пришел с запросом</param>
        /// <param name="id">Id объявления</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Theory]
        [AutoData]
        public async Task Delete_ByModerator_Returns_Response_Success(
            string accessToken,
            int id,
            CancellationToken cancellationToken)
        {
            // Arrange

            // Чтобы пройти проверку на авторизацию
            var autorizedStatus = new GetAutorizedStatusResponse()
            {
                UserId = "98ac3d19-c5f2-4bc9-b296-287c1477239c",
                Role = "moderator"
            };
            _userRepositoryMock
                .Setup(_ => _.GetAutorizedStatus(
                It.IsAny<string>(), // проверяет, что параметр имеет указанный тип <>
                It.IsAny<CancellationToken>())) // проверяет, что параметр имеет указанный тип <>
                .ReturnsAsync(autorizedStatus) // в результате выполнения возвращает объект
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
            await _advertisementServiceV1.Delete(
                accessToken,
                id,
                cancellationToken);

            // Assert
            _userRepositoryMock.Verify(); // Вызывался ли данный мок?
            _advertisementRepositoryMock.Verify(); // Вызывался ли данный мок?
        }

        /// <summary>
        /// Проверка удачного удаления объявления админом
        /// </summary>
        /// <param name="accessToken">JWT Token, который пришел с запросом</param>
        /// <param name="id">Id объявления</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Theory]
        [AutoData]
        public async Task Delete_ByAdmin_Returns_Response_Success(
            string accessToken,
            int id,
            CancellationToken cancellationToken)
        {
            // Arrange

            // Чтобы пройти проверку на авторизацию
            var autorizedStatus = new GetAutorizedStatusResponse()
            {
                UserId = "361852d8-3ffd-4113-a7ce-cdb2561fa837",
                Role = "admin"
            };
            _userRepositoryMock
                .Setup(_ => _.GetAutorizedStatus(
                It.IsAny<string>(), // проверяет, что параметр имеет указанный тип <>
                It.IsAny<CancellationToken>())) // проверяет, что параметр имеет указанный тип <>
                .ReturnsAsync(autorizedStatus) // в результате выполнения возвращает объект
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
                    CancellationToken ct) => advertisement.Id = id)
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
            await _advertisementServiceV1.Delete(
                accessToken,
                id,
                cancellationToken);

            // Assert
            _userRepositoryMock.Verify(); // Вызывался ли данный мок?
            _advertisementRepositoryMock.Verify(); // Вызывался ли данный мок?
        }

        /// <summary>
        /// Проверка исключения, если пользователь 
        /// не имеет права удалить объявление
        /// </summary>
        /// <param name="accessToken">JWT Token, который пришел с запросом</param>
        /// <param name="id">Id объявления</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <param name="userId"></param>
        /// <param name="advertisementId"></param>
        /// <returns></returns>
        [Theory]
        [AutoData]
        public async Task Delete_Throws_Exception_When_No_Rights(
            string accessToken,
            int id,
            CancellationToken cancellationToken)
        {
            // Arrange

            // Чтобы пройти проверку на авторизацию
            var autorizedStatus = new GetAutorizedStatusResponse()
            {
                UserId = "361852d8-3ffd-4113-a7ce-cdb2561fa837",
                Role = "user"
            };
            _userRepositoryMock
                .Setup(_ => _.GetAutorizedStatus(
                It.IsAny<string>(), // проверяет, что параметр имеет указанный тип <>
                It.IsAny<CancellationToken>())) // проверяет, что параметр имеет указанный тип <>
                .ReturnsAsync(autorizedStatus); // в результате выполнения возвращает объект

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

            _advertisementRepositoryMock
                .Setup(_ => _.Save(
                    It.IsAny<Domain.Advertisement>(), // проверяет, что параметр имеет указанный тип <>
                    It.IsAny<CancellationToken>())) // проверяет, что параметр имеет указанный тип <>
                .Callback(( // Используем передаваемые в мок аргументы для имитации логики
                    Domain.Advertisement advertisement,
                    CancellationToken ct) => advertisement.Id = id);

            // Act
            await Assert.ThrowsAsync<NoRightsException>(
                async () => await _advertisementServiceV1.Delete(
                    accessToken,
                    id, 
                    cancellationToken));
        }

        /// <summary>
        /// Проверка исключения, если в базе нет объявления с таким Id
        /// </summary>
        /// <param name="accessToken">JWT Token, который пришел с запросом</param>
        /// <param name="id">Id объявления</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Theory]
        [AutoData]
        public async Task Delete_Throws_Exception_When_Advertisement_Is_Null(
            string accessToken,
            int id,
            CancellationToken cancellationToken)
        {
            // Arrange

            // Чтобы пройти проверку на авторизацию
            var autorizedStatus = new GetAutorizedStatusResponse()
            {
                UserId = "24cb4b25-c819-45ab-8755-d95120fbb868",
                Role = "user"
            };
            _userRepositoryMock
                .Setup(_ => _.GetAutorizedStatus(
                It.IsAny<string>(), // проверяет, что параметр имеет указанный тип <>
                It.IsAny<CancellationToken>())) // проверяет, что параметр имеет указанный тип <>
                .ReturnsAsync(autorizedStatus); // в результате выполнения возвращает объект

            // "Достаем" объявление из базы
            Domain.Advertisement advertisement = null;
            _advertisementRepositoryMock
                .Setup(_ => _.FindByIdWithTagsInclude(
                    It.IsAny<int>(), // проверяет, что параметр имеет указанный тип <>
                    It.IsAny<CancellationToken>())) // проверяет, что параметр имеет указанный тип <>
                .ReturnsAsync(advertisement); // в результате выполнения возвращает объект

            // Act
            await Assert.ThrowsAsync<AdvertisementNotFoundException>(
                async () => await _advertisementServiceV1.Delete(
                    accessToken,
                    id, 
                    cancellationToken));
        }

        /// <summary>
        /// Проверка исключения, если не прошли валидацию Id
        /// </summary>
        /// <param name="accessToken">JWT Token, который пришел с запросом</param>
        /// <param name="id">Id объявления</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        [Theory]
        [InlineAutoData(null, null, null)]
        public async Task Delete_Throws_Exception_When_Id_Is_Not_Valid(
            string accessToken,
            int id,
            CancellationToken cancellationToken)
        {
            // Arrange

            // Чтобы пройти проверку на авторизацию
            accessToken = "token";
            var autorizedStatus = new GetAutorizedStatusResponse()
            {
                UserId = "24cb4b25-c819-45ab-8755-d95120fbb868",
                Role = "user"
            };
            _userRepositoryMock
                .Setup(_ => _.GetAutorizedStatus(
                It.IsAny<string>(), // проверяет, что параметр имеет указанный тип <>
                It.IsAny<CancellationToken>())) // проверяет, что параметр имеет указанный тип <>
                .ReturnsAsync(autorizedStatus); // в результате выполнения возвращает объект

            // Act
            await Assert.ThrowsAsync<AdvertisementIdNotValidException>(
                async () => await _advertisementServiceV1.Delete(
                    accessToken,
                    id,
                    cancellationToken));
        }
    }
}