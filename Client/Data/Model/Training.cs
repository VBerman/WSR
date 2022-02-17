using System;
using System.Collections.Generic;

#nullable disable

namespace Client.Data.Model
{
    public partial class Training
    {
        public Training()
        {
            Expenses = new HashSet<Expense>();
            Participants = new HashSet<Participant>();
            Requests = new HashSet<Request>();
            TrainingDays = new HashSet<TrainingDay>();
        }

        public int Id { get; set; }
        public int SkillCode { get; set; }
        public int TrainingPlaceId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual Skill SkillCodeNavigation { get; set; }
        public virtual TrainingPlace TrainingPlace { get; set; }
        public virtual ICollection<Expense> Expenses { get; set; }
        public virtual ICollection<Participant> Participants { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
        public virtual ICollection<TrainingDay> TrainingDays { get; set; }
    }
}
