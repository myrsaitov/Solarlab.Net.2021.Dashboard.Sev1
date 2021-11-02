﻿using Comments.Contracts.Base;
using Comments.Contracts.Enums;
using System;

namespace Comments.Contracts
{
    public class CommentDtoResponce : BaseDto
    {
        /// <summary>
        /// Текст сообщения
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreationTime { get; set; }

        /// <summary>
        /// Статус сообщения : Обычное, Изменённое, Новое
        /// </summary>
        public CommentStatus CommentStatus { get; set; }

        /// <summary>
        /// Id объявления, к которому прикреплён коментарий
        /// </summary>
        public Guid ChatId { get; set; }

        /// <summary>
        /// Id автора
        /// </summary>
        public string AuthorName { get; set; }
    }
}