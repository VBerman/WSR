using System;
using System.Collections.Generic;

#nullable disable

namespace Client.Data.Model
{
    public partial class File
    {
        public int Id { get; set; }
        public int CatalogId { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime EditDateTime { get; set; }

        public virtual Catalog Catalog { get; set; }
    }
}
