using System;
using System.Collections.Generic;

#nullable disable

namespace Client.Data.Model
{
    public partial class WSOS
    {
        public WSOS()
        {
            SubSkills = new HashSet<SubSkill>();
        }

        public int Id { get; set; }
        public byte SectionNumber { get; set; }
        public string SectionName { get; set; }
        public int? SkillCode { get; set; }

        public virtual Skill SkillCodeNavigation { get; set; }
        public virtual ICollection<SubSkill> SubSkills { get; set; }
    }
}
