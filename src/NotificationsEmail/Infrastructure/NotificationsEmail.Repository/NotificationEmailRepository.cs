using Microsoft.EntityFrameworkCore;
using NotificationsEmail.Domain.Entities;
using NotificationsEmail.Domain.Enums;
using NotificationsEmail.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NotificationsEmail.Repository
{
    /// <inheritdoc/>
    public class NotificationEmailRepository : INotificationEmailRepository
    {
        private readonly NotificationEmailDBContext _context;
        private readonly DbSet<Letter> _dbSet;
        public NotificationEmailRepository(NotificationEmailDBContext context)
        {
            _context = context;
            _dbSet = _context.Set<Letter>();
        }

        /// <inheritdoc/>
        public async Task<Guid> AddLetterAsync(Letter letter)
        {
            await _dbSet.AddAsync(letter);
            await _context.SaveChangesAsync();
            return letter.LetterId;
        }

        /// <inheritdoc/>
        public async Task<Guid> UpdateLetterAsync(Letter letter)
        {
            _dbSet.Update(letter);
            await _context.SaveChangesAsync();
            return letter.LetterId;
        }

        /// <inheritdoc/>
        public async Task<List<Letter>> GetNotSendedLettersForLastDay()
        {
            var letters = await _dbSet.Where(letter => (letter.Status == LetterStatus.New || letter.Status == LetterStatus.Trying)
                                            && letter.SendRequesDate > DateTime.Now.AddHours(-24)).ToListAsync();
            return letters;
        }
    }
}
