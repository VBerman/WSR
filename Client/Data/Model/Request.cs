using System;
using System.Collections.Generic;

#nullable disable

namespace Client.Data.Model
{
    public partial class Request
    {
        public Request()
        {
            RequestHotels = new HashSet<RequestHotel>();
            Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public int TrainingId { get; set; }
        public int OwnerId { get; set; }
        public decimal HotelPrice { get; set; }
        public DateTime? EarlyCheckInDateTime { get; set; }
        public DateTime? LateCheckOutDateTime { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public int UserDocumentId { get; set; }

        public virtual User Owner { get; set; }
        public virtual Training Training { get; set; }
        public virtual UserDocument UserDocument { get; set; }
        public virtual ICollection<RequestHotel> RequestHotels { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
