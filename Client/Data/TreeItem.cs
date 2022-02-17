using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Data
{
    public class TreeItem
    {

        public string ViewNumber { get; set; } 
        public string Name { get; set; }

        public int Id { get; set; }

        public bool IsWSOS { get; set; }

        public string ViewName { 
            get { return ViewNumber + ' ' + Name; } 
        }

    }
}
