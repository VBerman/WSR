using System;
using System.Collections.Generic;

#nullable disable

namespace Client.Data.Model
{
    public partial class Skill
    {
        public Skill()
        {
            WSOS = new HashSet<WSOS>();
            training = new HashSet<Training>();
        }

        public int Code { get; set; }
        public int InternationalExpertId { get; set; }
        public string Name { get; set; }

        public virtual User InternationalExpert { get; set; }
        public virtual ICollection<WSOS> WSOS { get; set; }
        public virtual ICollection<Training> training { get; set; }
    }
}
