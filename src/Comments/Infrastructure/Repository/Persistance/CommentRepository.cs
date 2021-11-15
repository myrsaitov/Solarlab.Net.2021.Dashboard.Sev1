using Comments.Domain.Entities;
using Comments.Domain.Exceptions;
using Comments.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Comments.Repository.Persistance
{
    /// <inheritdoc/>
    public class CommentRepository : ICommentRepository
    //: ICommentsRepository
    {
        private readonly CommentDBContext _context;

        /// <inheritdoc/>
        public CommentRepository(CommentDBContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public async Task<Guid> GetChatId(AdvertisementIdChatId advertisementIdChatId, CancellationToken token)
        {
            advertisementIdChatId = await _context.AdvertisementIdChatId_Table.
                FirstOrDefaultAsync(_ => _.AdvertisementId == advertisementIdChatId.AdvertisementId, token);
            if (advertisementIdChatId == null)
            {
                throw new NotFoundException(advertisementIdChatId.ToString());
            }

            return advertisementIdChatId.ChatId;
        }

        /// <inheritdoc/>
        public async Task<Guid> AddAdvertisementIdChatId(AdvertisementIdChatId advertisementIdChatId, CancellationToken token)
        {
            advertisementIdChatId.ChatId = new Guid();
            await _context.AdvertisementIdChatId_Table.AddAsync(advertisementIdChatId, token);

            return advertisementIdChatId.ChatId;
        }

        /// <inheritdoc/>
        public async Task<Guid> AddAdvertisementIdConsumerIdChatId(AdvertisementIdConsumerIdChatId advertisementIdConsumerIdChatId, CancellationToken token)
        {
            advertisementIdConsumerIdChatId.ChatId = new Guid();
            await _context.AdvertisementIdConsumerIdChatId_Table.AddAsync(advertisementIdConsumerIdChatId, token);

            return advertisementIdConsumerIdChatId.ChatId;
        }

        /// <inheritdoc/>
        public async Task<Guid> AddChat(Chat chat, CancellationToken token)
        {
            await _context.Chat_Table.AddAsync(chat, token);
            return chat.ChatId;
        }

        /// <inheritdoc/>
        public async Task<Guid> GetChatId(AdvertisementIdConsumerIdChatId advertisementIdConsumerIdChatId, CancellationToken token)
        {
            advertisementIdConsumerIdChatId = await _context.AdvertisementIdConsumerIdChatId_Table.
                 FirstOrDefaultAsync(_ => _.AdvertisementId == advertisementIdConsumerIdChatId.AdvertisementId
                 && _.ConsumerId == advertisementIdConsumerIdChatId.ConsumerId, token);
            if (advertisementIdConsumerIdChatId == null)
            {
                throw new NotFoundException(advertisementIdConsumerIdChatId.ToString());
            }

            return advertisementIdConsumerIdChatId.ChatId;
        }

        /// <inheritdoc/>
        public async Task<Chat> GetChatPagedByChatIdAsync(Guid id, int PageSize, int PageNumber, CancellationToken token)
        {
            var chat = await _context.Chat_Table
                .Include(c => c.Messages)
                .Skip(PageSize * PageNumber)
                .Take(PageSize)
                .FirstOrDefaultAsync(c => c.ChatId == id);

            //var comments = await _dbSet.Where(c => c.ChatId == id).Skip(PageSize * PageNumber).Take(PageSize).OrderBy(c => c.CreationTime).ToListAsync(token);
            return chat;
        }

        /// <inheritdoc/>
        public async Task<int> CountPagesByChatIdAsync(Guid id, int PageSize, CancellationToken token)
        {
            var totalComments = await _context.Comment_Table.CountAsync(c => c.ChatId == id, token);
            return (int)Math.Ceiling(totalComments / (double)PageSize);
        }

        /// <inheritdoc/>
        public async Task RemoveChatAsync(Guid id, CancellationToken token)
        {
            var advIdChatId = _context.AdvertisementIdChatId_Table.FirstOrDefault(_ => _.ChatId == id);
            if (advIdChatId != null)
            {
                _context.AdvertisementIdChatId_Table.Remove(advIdChatId);
            }

            var advIdConsumerIdChatId = _context.AdvertisementIdConsumerIdChatId_Table.FirstOrDefault(_ => _.ChatId == id);
            if (advIdConsumerIdChatId != null)
            {
                _context.AdvertisementIdConsumerIdChatId_Table.Remove(advIdConsumerIdChatId);
            }

            var chat = await _context.Chat_Table.FindAsync(id, token);
            _context.Remove(chat);

            await _context.SaveChangesAsync(token);
        }

        ///+ <inheritdoc/> 
        public async Task<Guid> AddCommentAsync(Comment comment, CancellationToken token)
        {
            await _context.Comment_Table.AddAsync(comment, token);
            await _context.SaveChangesAsync(token);
            return comment.Id;
        }

        ///+ <inheritdoc/>
        public async Task<Guid> UpdateCommentAsync(Comment comment, CancellationToken token)
        {
            _context.Comment_Table.Update(comment);
            await _context.SaveChangesAsync(token);
            return comment.Id;
        }

        ///+ <inheritdoc/>
        public async Task DeleteCommentAsync(Guid id, CancellationToken token)
        {
            var comment = await _context.Comment_Table.FirstOrDefaultAsync(c => c.Id == id, token);
            if (comment == null)
            {
                throw new NotFoundException(id.ToString());
            }
            _context.Comment_Table.Remove(comment);
            await _context.SaveChangesAsync();
        }
    }
}