using System;
using System.Collections.Generic;

#nullable disable

namespace Client.Data.Model
{
    public partial class UserTrainingDay
    {
        public int Id { get; set; }
        public int TrainingDayId { get; set; }
        public int UserId { get; set; }
        public int Hours { get; set; }
        public string Description { get; set; }

        public virtual TrainingDay TrainingDay { get; set; }
        public virtual User User { get; set; }
    }
}
