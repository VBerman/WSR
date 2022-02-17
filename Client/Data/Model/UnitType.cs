using System;
using System.Collections.Generic;

#nullable disable

namespace Client.Data.Model
{
    public partial class UnitType
    {
        public UnitType()
        {
            Expenses = new HashSet<Expense>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Expense> Expenses { get; set; }
    }
}
