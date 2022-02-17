using System;
using System.Collections.Generic;

#nullable disable

namespace Client.Data.Model
{
    public partial class TrainingPlace
    {
        public TrainingPlace()
        {
            training = new HashSet<Training>();
        }

        public int Id { get; set; }
        public int CityId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Training> training { get; set; }
    }
}
