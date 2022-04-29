using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Data.DTO
{

    public class UpdateSubSkillDto
    {


        public int Id { get; set; }
        public int? ParentSubSkillId { get; set; }
        public int? WSOSId { get; set; }
        [Required(ErrorMessage = "Name required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Theory required", AllowEmptyStrings = false)]
        public string Theory { get; set; }
        [Range(0, 5)]
        public int? Importance { get; set; }
    }

}
