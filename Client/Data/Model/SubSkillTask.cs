using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Client.Data.Model
{
    public partial class SubSkillTask 
    {
        public SubSkillTask()
        {
            SubSkillTaskResolvings = new HashSet<SubSkillTaskResolving>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Name field required")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string AttachmentPath { get; set; }
        public int SubSkilId { get; set; }
        public int AuthorId { get; set; }
        
        [Range(1, 1000)]
        public byte MaxScore { get; set; }

        public virtual User Author { get; set; }
        [Required(ErrorMessage = "SubSkill required")]
        public virtual SubSkill SubSkill { get; set; }

        public virtual ICollection<SubSkillTaskResolving> SubSkillTaskResolvings { get; set; }
    }
}
