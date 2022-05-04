using Client.Data.Enums;
using Client.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Client.Data.Model
{
    public partial class SubSkillTaskResolving
    {
        private SubSkillTaskResolving()
        {

        }
        public SubSkillTaskResolving(SubSkillTask subSkillTask, int competitorId, int appointingUserId)
        {
            SubSkillTask = subSkillTask;
            CompetitorId = competitorId;
            AppointingUserId = appointingUserId;
            Status = ResolvingStatus.Appointed;
        }
        public int Id { get; set; }
        [Required]
        public int SubSkillTaskId { get; set; }
        [Required]
        public int CompetitorId { get; set; }
        [Required]
        public int AppointingUserId { get; set; }

        [NotMapped]
        public string ResolvingDuration => (EndSolvingTime - StartSolvingTime).ToCorrectString();


        public byte? Score
        { get; set; }
        public string SolutionPath { get; set; }
        public DateTime AppointedTime { get; set; }

        public DateTime? StartReadingTime { get; set; }
        public DateTime? EndReadingTime { get; set; }

        public DateTime? StartSolvingTime { get; set; }

        public DateTime? EndSolvingTime { get; set; }

        public DateTime? StartCheckingTime { get; set; }
        public DateTime? EndCheckingTime { get; set; }
        public string Comment { get; set; }
        public bool? IsFullResolving { get; set; }



#pragma warning disable IDE1006 // Naming Styles
        private ResolvingStatus status;
#pragma warning restore IDE1006 // Naming Styles


        public ResolvingStatus Status
        {
            get { return status; }
            set
            {
                switch (value)
                {
                    case ResolvingStatus.Appointed:
                        AppointedTime = DateTime.Now;
                        break;
                    case ResolvingStatus.Reading:
                        StartReadingTime = DateTime.Now;
                        break;
                    case ResolvingStatus.Solving:
                        EndReadingTime = DateTime.Now;
                        StartSolvingTime = EndReadingTime;
                        break;
                    case ResolvingStatus.Solved:
                        EndSolvingTime = DateTime.Now;
                        break;
                    case ResolvingStatus.Checking:
                        StartCheckingTime = DateTime.Now;
                        break;
                    case ResolvingStatus.Checked:
                        EndCheckingTime = DateTime.Now;
                        break;

                }
                status = value;
            }
        }
        public virtual User AppointingUser { get; set; }
        public virtual User Competitor { get; set; }
        public virtual SubSkillTask SubSkillTask { get; set; }
    }
}
