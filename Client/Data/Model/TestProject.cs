using System;
using System.Collections.Generic;

#nullable disable

namespace Client.Data.Model
{
    public partial class TestProject
    {
        public TestProject()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? IssueDate { get; set; }
        public string Country { get; set; }


    }
}
