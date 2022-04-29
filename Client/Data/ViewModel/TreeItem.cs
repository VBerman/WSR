using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Data.ViewModel
{
    public class TreeItem
    {
        public TreeItem()
        {
            
        }

        public string ViewNumber { get; set; }
        public string Name { get; set; }

        public int Id { get; set; }

        public bool IsWSOS { get; set; }

        //public bool HasChild { get; set; }

        public string ViewName
        {
            get { return ViewNumber + ' ' + Name; }
        }

        public string Style { get; set; }





    }
}
