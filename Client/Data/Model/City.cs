using System;
using System.Collections.Generic;

#nullable disable

namespace Client.Data.Model
{
    public partial class City
    {
        public City()
        {
            TicketArrivalCities = new HashSet<Ticket>();
            TicketDepartureCities = new HashSet<Ticket>();
            TrainingPlaces = new HashSet<TrainingPlace>();
        }

        public int Id { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Ticket> TicketArrivalCities { get; set; }
        public virtual ICollection<Ticket> TicketDepartureCities { get; set; }
        public virtual ICollection<TrainingPlace> TrainingPlaces { get; set; }
    }
}
