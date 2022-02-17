using System;
using System.Collections.Generic;

#nullable disable

namespace Client.Data.Model
{
    public partial class RequestHotel
    {
        public int Id { get; set; }
        public int RequestId { get; set; }
        public string Address { get; set; }

        public virtual Request Request { get; set; }
    }
}
