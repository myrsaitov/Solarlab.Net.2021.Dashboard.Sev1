using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comments.Contracts.ValidationAttributes
{
    /// <summary>
    /// Атрибут: больше чем число (int)
    /// </summary>
    public class GreaterThan : ValidationAttribute
    {
        private readonly int _numb;

        /// <summary>
        /// Больше чем
        /// </summary>
        /// <param name="value">int</param>
        public GreaterThan(int value)
        {
            _numb = value;
        }

        public override bool IsValid(object value)
        {
            if (value == null) 
                return false;
            return (int)value > _numb;
        }
    }
}
