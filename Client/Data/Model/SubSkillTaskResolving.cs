using System;
using System.Collections.Generic;

#nullable disable

namespace Client.Data.Model
{
    public partial class SubSkillTaskResolving
    {
        public int Id { get; set; }
        public int SubSkillTaskId { get; set; }
        public int CompetitorId { get; set; }
        public TimeSpan? ResolvingDuration { get; set; }
        public byte? Score { get; set; }
        public string SolutionPath { get; set; }
        public DateTime? EndTime { get; set; }
        public DateTime StartTime { get; set; }
        public string Comment { get; set; }
        public bool IsFullResolving { get; set; }

        public virtual User Competitor { get; set; }
        public virtual SubSkillTask SubSkillTask { get; set; }
    }
}
