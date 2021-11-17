using Comments.Domain.Entities;
using Comments.Domain.Exceptions;
using Comments.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Comments.Repository.Persistance
{
    /// <inheritdoc/>
    public class CommentsRepository : ICommentsRepository

    //: ICommentsRepository
    {
        private readonly CommentDBContext _context;

        /// <inheritdoc/>
        public CommentsRepository(CommentDBContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public async Task<List<Chat>> GetUserChatsPages(Guid userId, int pageSize, int pageNumber, int pagesQuantity, CancellationToken token)
        {
            pageNumber = pageNumber > pagesQuantity ? pagesQuantity : pageNumber;

            var chats = await _context.Chat_Table
                .Where(c => c.ConsumerId == userId || c.SellerId == userId)
                .Skip(pageSize * pageNumber)
                .Take(pageSize)
                .ToListAsync(token);

            return chats;
        }

        /// <inheritdoc/>
        public async Task<List<Chat>> LoadLastMessageInChat(List<Chat> chats, CancellationToken token)
        {
            foreach (Chat chat in chats)
            {
                chat.Messages.Add(await _context.Comment_Table.OrderBy(m => m.CreationTime).LastOrDefaultAsync(m => m.ChatId == chat.ChatId));
            }

            return chats;
        }

        /// <inheritdoc/>
        public async Task<Chat> GetChatPagedAsync(Expression<Func<Chat, bool>> predicate, int pageSize, int pageNumber, int pagesQuantity, CancellationToken token)
        {
            pageNumber = pageNumber > pagesQuantity ? pagesQuantity : pageNumber;

            var chat = await _context.Chat_Table
                .Where(predicate)
                .FirstOrDefaultAsync(predicate, token);

            chat.Messages = await _context.Comment_Table
                .Where(msg => msg.ChatId == chat.ChatId)
                .Skip(pageSize * pageNumber)
                .Take(pageSize)
                .ToListAsync();

            return chat;
        }

        /// <inheritdoc/>
        public async Task<int> CountPagesChatsAsync(Expression<Func<Chat, bool>> predicate, int pageSize, CancellationToken token)
        {
            var numberOfItems = await _context.Chat_Table.CountAsync(predicate);
            var numberOfPages = (int)Math.Ceiling(numberOfItems / (double)pageSize);

            return numberOfPages;
        }

        /// <inheritdoc/>
        public async Task<int> CountPagesMessagesAsync(Guid chatId, int pageSize, CancellationToken token)
        {
            var numberOfItems = await _context.Comment_Table.CountAsync(c => c.ChatId == chatId, token);
            var numberOfPages = (int)Math.Ceiling(numberOfItems / (double)pageSize);

            return numberOfPages;
        }

        /// <inheritdoc/>
        public async Task RemoveChatAsync(Expression<Func<Chat, bool>> predicate, CancellationToken token)
        {
            var chat = await _context.Chat_Table.FirstOrDefaultAsync(predicate, token);
            if (chat == null)
            {
                throw new NotFoundException(predicate.ToString());
            }
            _context.Remove(chat);

            await _context.SaveChangesAsync(token);
        }

        /// <inheritdoc/>
        public async Task<Guid> AddCommentAsync(Comment comment, CancellationToken token)
        {
            await _context.Comment_Table.AddAsync(comment, token);
            await _context.SaveChangesAsync(token);

            return comment.Id;
        }

        /// <inheritdoc/>
        public async Task<Guid> GetChatId(Expression<Func<Chat, bool>> predicate, CancellationToken token)
        {
            var chat = await _context.Chat_Table.FirstOrDefaultAsync(predicate, token);
            if (chat == null)
            {
                throw new NotFoundException(predicate.ToString());
            }

            return chat.ChatId;
        }

        /// <inheritdoc/>
        public async Task<Guid> AddChat(Chat chat, CancellationToken token)
        {
            await _context.Chat_Table.AddAsync(chat, token);
            await _context.SaveChangesAsync(token);

            return chat.ChatId;
        }

        /// <inheritdoc/>
        public async Task<Guid> UpdateCommentAsync(Comment comment, CancellationToken token)
        {
            _context.Comment_Table.Update(comment);
            await _context.SaveChangesAsync(token);
            return comment.Id;
        }

        /// <inheritdoc/>
        public async Task<Comment> GetCommentAsync(Guid id, CancellationToken token)
        {
            var result = await _context.Comment_Table.FirstOrDefaultAsync(c => c.Id == id, token);

            if (result == null)
            {
                throw new NotFoundException(id.ToString());
            }
            return result;
        }

        /// <inheritdoc/>
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