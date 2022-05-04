using Client.Data.Model;
using Client.Data.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Data.ViewModel
{
    public class TaskAssignmentModel
    {

        public HashSet<User> AllUsers { get; set; } = new HashSet<User>();
        [EnumerableNotEmpty(ErrorMessage = "Select users")]
        public HashSet<User> SelectedUsers { get; set; } = new HashSet<User>();
        public HashSet<SubSkillTask> AllSubSkillTasks { get; set; } = new HashSet<SubSkillTask>();
        [EnumerableNotEmpty(ErrorMessage = "Select tasks")]
        public HashSet<SubSkillTask> SelectedSubSkillTasks { get; set; } = new HashSet<SubSkillTask>();

    }
}
