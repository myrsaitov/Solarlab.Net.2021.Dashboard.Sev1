﻿using Sev1.Accounts.Domain.Base;
using System.Collections.Generic;

namespace Sev1.Accounts.Domain
{
    /// <summary>
    /// Доменный пользователь
    /// </summary>
    public class User : EntityMutable<string>
    {
        /// <summary>
        /// Никнейм пользователя
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Отчество пользователя
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Телефон пользователя
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Телефон пользователя
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Путь к фото пользователя
        /// </summary>
        public string UserPicPath { get; set; }

        /// <summary>
        /// "Избранное"
        /// </summary>
        public ICollection<FavoriteAdvertisement> FavoriteAdvertisements { get; set; }

        /// <summary>
        /// "Друзья"
        /// </summary>
        public ICollection<User> FriendUsers { get; set; }

        /// <summary>
        /// "В игноре"
        /// </summary>
        public ICollection<User> IgnoredUsers { get; set; }
    }
}