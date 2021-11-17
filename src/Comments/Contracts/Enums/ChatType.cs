﻿
namespace Comments.Contracts.Enums
{
    /// <summary>
    /// Тип чата: Приватный чат(vежду продавцом и покупателем) или чат объявления
    /// </summary>
    public enum ChatType
    {
        /// <summary>
        /// Чат между продавцом и покупателем
        /// </summary>
        SellerConsumerChat,

        /// <summary>
        /// Чат объявления
        /// </summary>
        AdvertisementChat
    }
}
