using System;
using System.Collections.Generic;

#nullable disable

namespace Client.Data.Model
{
    public partial class Role
    {
        public Role()
        {
            UserRoles = new HashSet<UserRole>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
