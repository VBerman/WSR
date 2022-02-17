using System;
using System.Collections.Generic;

#nullable disable

namespace Client.Data.Model
{
    public partial class TrainingDay
    {
        public TrainingDay()
        {
            UserTrainingDays = new HashSet<UserTrainingDay>();
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int TrainingId { get; set; }

        public virtual Training Training { get; set; }
        public virtual ICollection<UserTrainingDay> UserTrainingDays { get; set; }
    }
}
