using System;
using System.Collections.Generic;

#nullable disable

namespace Client.Data.Model
{
    public partial class Catalog
    {
        public Catalog()
        {
            Files = new HashSet<File>();
            InverseCatalogNavigation = new HashSet<Catalog>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime EditDate { get; set; }
        public int UserId { get; set; }
        public int? CatalogId { get; set; }

        public virtual Catalog CatalogNavigation { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<File> Files { get; set; }
        public virtual ICollection<Catalog> InverseCatalogNavigation { get; set; }
    }
}
