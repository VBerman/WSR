﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        [Required]
        public bool IsMeas { get; set; }
        
        public string? Description { get; set; }
        [Required]
        public decimal MaxMark { get; set; }
        public int SubSkillId { get; set; }
            
        public virtual SubSkill SubSkill { get; set; }
    }
}
