using Comments.Contracts;
using Comments.Services;
using Microsoft.AspNetCore.SignalR;
using Sev1.Accounts.Contracts.Authorization;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Comments.API.Hubs
{
    /// <summary>
    /// Использование signalR для чатов
    /// </summary>
    [Authorize]
    public class ChatHub : Hub
    {
        private readonly ICommentsService _service;

        public ChatHub(ICommentsService service)
        {
            _service = service;
        }
        /// <summary>
        /// Метод, принимающий созданное сообщение пользователем.
        /// Сохранение сообщения в БД
        /// Отправка сообщения другим пользователям, подключенным к чату.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task SendMessage(CommentDtoRequestCreate dto)
        {
            var commentId = await _service.AddCommentAsync(dto, default);

            var commentResponce = _service.GetCommentAsync(commentId, default);

            await Clients.Group(dto.AdvertisementId + dto.ConsumerId.ToString()).SendAsync("ReceiveMessage", commentResponce);
        }
        /// <summary>
        /// Добавить пользователя в группу чата для приема сообещний.
        /// </summary>
        /// <param name="GroupId"></param>
        /// <returns></returns>
        public async Task AddToGroup(string GroupId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, GroupId);
        }
    }
}