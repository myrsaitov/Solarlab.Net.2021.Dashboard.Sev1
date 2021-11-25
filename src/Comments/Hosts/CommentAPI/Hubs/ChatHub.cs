using Comments.Contracts;
using Comments.Services;
using Microsoft.AspNetCore.SignalR;
using Sev1.Accounts.Contracts.Authorization;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Comments.API.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        private readonly ICommentsService _service;

        public ChatHub(ICommentsService service)
        {
            _service = service;
        }
        public async Task SendMessage(CommentDtoRequestCreate dto)
        {
            var commentId = await _service.AddCommentAsync(dto, default);

            var commentResponce = _service.GetCommentAsync(commentId, default);

            await Clients.Group(dto.AdvertisementId + dto.ConsumerId.ToString()).SendAsync("ReceiveMessage", commentResponce);
        }
        public async Task AddToGroup(string GroupId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, GroupId);
        }
    }
}