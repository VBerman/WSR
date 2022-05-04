using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Client.Data.Model
{
    public partial class SubSkillCriterion
    {
        public SubSkillCriterion()
        {
            
        }

        public int Id { get; set; }
        [Required, MaxLength(100, ErrorMessage = "Max length 100 symbols")]
        public string Name { get; set; }


        public string Description { get; set; }
        [Required]
        [Column(TypeName = "decimal(5, 2)")]
        public decimal MaxMark { get; set; }
        public int SubSkillId { get; set; }
            
        public virtual SubSkill SubSkill { get; set; }
    }
}
