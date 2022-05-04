using Client.Data.Enums;
using Client.Data.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Data.DTO
{


    public class ReadingTaskResolvingDto
    {
        public int Id { get; set; }
        [Required]
        public int SubSkillTaskId { get; set; }
        [Required]
        public int CompetitorId { get; set; }
        [Required]
        public int AppointingUserId { get; set; }
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
        [TrueFalseBool(ErrorMessage = "Set IsFullResolving")]
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
    }
}
