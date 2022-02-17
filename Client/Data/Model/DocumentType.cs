using System;
using System.Collections.Generic;

#nullable disable

namespace Client.Data.Model
{
    public partial class DocumentType
    {
        public DocumentType()
        {
            UserDocuments = new HashSet<UserDocument>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UserDocument> UserDocuments { get; set; }
    }
}
