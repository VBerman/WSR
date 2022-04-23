using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Client.Data.Model
{
    public partial class SubSkill
    {
        public SubSkill()
        {
            InverseParentSubSkill = new HashSet<SubSkill>();
            SubSkillMarks = new HashSet<SubSkillMark>();
            SubSkillTasks = new HashSet<SubSkillTask>();
            SubSkillCriteria = new HashSet<SubSkillCriterion>();
        }

        public int Id { get; set; }
        public int? ParentSubSkillId { get; set; }
        public int? WSOSId { get; set; }
        [Required(ErrorMessage = "Name required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Theory required")]
        public string Theory { get; set; }
        public int? Importance { get; set; }

        public virtual SubSkill ParentSubSkill { get; set; }
        public virtual WSOS WSOS { get; set; }
        public virtual ICollection<SubSkill> InverseParentSubSkill { get; set; }
        public virtual ICollection<SubSkillMark> SubSkillMarks { get; set; }
        public virtual ICollection<SubSkillTask> SubSkillTasks { get; set; }

        public virtual ICollection<SubSkillCriterion> SubSkillCriteria { get; set; }
    }
}
