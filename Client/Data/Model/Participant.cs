using System;
using System.Collections.Generic;

#nullable disable

namespace Client.Data.Model
{
    public partial class Participant
    {
        public int TrainingId { get; set; }
        public int UserId { get; set; }

        public virtual Training Training { get; set; }
        public virtual User User { get; set; }
    }
}
