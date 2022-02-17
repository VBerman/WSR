using System;
using System.Collections.Generic;

#nullable disable

namespace Client.Data.Model
{
    public partial class SubSkillMark
    {
        public int Id { get; set; }
        public int SubSkillId { get; set; }
        public int CompetitorId { get; set; }
        public byte Mark { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Comment { get; set; }

        public virtual User Competitor { get; set; }
        public virtual SubSkill SubSkill { get; set; }
    }
}
