using System;
using System.Collections.Generic;

#nullable disable

namespace Client.Data.Model
{
    public partial class User
    {
        public User()
        {
            Catalogs = new HashSet<Catalog>();
            Participants = new HashSet<Participant>();
            Requests = new HashSet<Request>();
            Skills = new HashSet<Skill>();
            SubSkillMarks = new HashSet<SubSkillMark>();
            SubSkillTaskResolvings = new HashSet<SubSkillTaskResolving>();
            SubSkillTasks = new HashSet<SubSkillTask>();
            UserDocuments = new HashSet<UserDocument>();
            UserRoles = new HashSet<UserRole>();
            UserTokens = new HashSet<UserToken>();
            UserTrainingDays = new HashSet<UserTrainingDay>();
            SubSkillTaskAppointments = new HashSet<SubSkillTaskResolving>();
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string FullNameEN { get; set; }
        public string FullNameRU { get; set; }
        public string PhotoPath { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? CityId { get; set; }
        public bool? IsStaff { get; set; }

        public virtual ICollection<Catalog> Catalogs { get; set; }
        public virtual ICollection<Participant> Participants { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
        public virtual ICollection<Skill> Skills { get; set; }
        public virtual ICollection<SubSkillMark> SubSkillMarks { get; set; }
        public virtual ICollection<SubSkillTaskResolving> SubSkillTaskResolvings { get; set; }
        public virtual ICollection<SubSkillTask> SubSkillTasks { get; set; }
        public virtual ICollection<UserDocument> UserDocuments { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<UserToken> UserTokens { get; set; }
        public virtual ICollection<UserTrainingDay> UserTrainingDays { get; set; }

        public virtual ICollection<SubSkillTaskResolving> SubSkillTaskAppointments { get; set; }

    }
}
