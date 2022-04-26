using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Required, Range(0, byte.MaxValue, ErrorMessage = "Min 0")]
        public byte SectionNumber { get; set; }
        [Required]
        public string SectionName { get; set; }
        public int? SkillCode { get; set; }

        [Required]
        public virtual Skill SkillCodeNavigation { get; set; }
        public virtual ICollection<SubSkill> SubSkills { get; set; }
    }
}
