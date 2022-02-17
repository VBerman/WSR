using System;
using System.Collections.Generic;

#nullable disable

namespace Client.Data.Model
{
    public partial class Ticket
    {
        public int Id { get; set; }
        public int DepartureCityId { get; set; }
        public int ArrivalCityId { get; set; }
        public int RequestId { get; set; }
        public int Order { get; set; }
        public bool IsToTraining { get; set; }
        public bool IsRefund { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public DateTime ArrivalDateTim { get; set; }
        public string BaggageInfo { get; set; }
        public int ExpensiveId { get; set; }

        public virtual City ArrivalCity { get; set; }
        public virtual City DepartureCity { get; set; }
        public virtual Expense Expensive { get; set; }
        public virtual Request Request { get; set; }
    }
}
