using System;
using System.Collections.Generic;

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
        public string Name { get; set; }
        public string Description { get; set; }
        public string AttachmentPath { get; set; }
        public int SubSkilId { get; set; }
        public int AuthorId { get; set; }
        public int TestProjectId { get; set; }
        public byte MaxScore { get; set; }

        public virtual User Author { get; set; }
        public virtual SubSkill SubSkill { get; set; }
        public virtual TestProject TestProject { get; set; }
        public virtual ICollection<SubSkillTaskResolving> SubSkillTaskResolvings { get; set; }
    }
}
