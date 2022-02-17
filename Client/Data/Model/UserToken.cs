using System;
using System.Collections.Generic;

#nullable disable

namespace Client.Data.Model
{
    public partial class UserToken
    {
        public string Token { get; set; }
        public int UserId { get; set; }
        public string DeviceId { get; set; }
        public DateTime CreatedDateTime { get; set; }

        public virtual User User { get; set; }
    }
}
