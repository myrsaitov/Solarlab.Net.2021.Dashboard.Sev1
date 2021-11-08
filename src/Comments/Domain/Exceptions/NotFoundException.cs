using System;

namespace Comments.Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(String Message) : base(String.Format(Message))
        {
        }
    }
}