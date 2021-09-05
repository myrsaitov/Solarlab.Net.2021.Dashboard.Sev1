using Contracts.Base;
using System;

namespace Contracts
{
    public class CommentDtoRequestUpdate : CommentDtoRequestBase
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }
    }
}