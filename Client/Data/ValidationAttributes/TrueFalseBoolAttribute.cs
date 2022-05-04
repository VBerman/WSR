using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Data.ValidationAttributes
{
    public class TrueFalseBoolAttribute : ValidationAttribute
    {
        public override bool IsValid(Object value)
        {
            return value is bool;
        }
    }
}
