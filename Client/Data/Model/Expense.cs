using System;
using System.Collections.Generic;

#nullable disable

namespace Client.Data.Model
{
    public partial class Expense
    {
        public Expense()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public int ExpenseTypeId { get; set; }
        public int UnitTypeId { get; set; }
        public int TrainingId { get; set; }
        public int Count { get; set; }
        public int CostPerUnit { get; set; }
        public decimal Cost { get; set; }

        public virtual ExpenseType ExpenseType { get; set; }
        public virtual Training Training { get; set; }
        public virtual UnitType UnitType { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
