using System;
using System.Collections.Generic;

#nullable disable

namespace Client.Data.Model
{
    public partial class TestProjectSession
    {
        public int Id { get; set; }
        public int TestProjectId { get; set; }
        public byte[] FileStorage { get; set; }
        public string FileName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual TestProject TestProject { get; set; }
    }
}
