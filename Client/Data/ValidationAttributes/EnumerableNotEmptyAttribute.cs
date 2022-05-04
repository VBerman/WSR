using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Data.ValidationAttributes
{
    public class EnumerableNotEmptyAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var enumerable = value as IEnumerable;
            if (enumerable != null)
            {
                return enumerable.GetEnumerator().MoveNext();
            }
            return false;
        }
    }
}
