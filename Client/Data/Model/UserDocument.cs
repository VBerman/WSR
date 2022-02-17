using System;
using System.Collections.Generic;

#nullable disable

namespace Client.Data.Model
{
    public partial class UserDocument
    {
        public UserDocument()
        {
            Requests = new HashSet<Request>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public int DocumentTypeId { get; set; }
        public string Value { get; set; }
        public string ScanPath { get; set; }

        public virtual DocumentType DocumentType { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
    }
}
