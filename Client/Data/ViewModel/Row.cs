﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Data.ViewModel
{
    public class Row<T>
    {
        public int Index { get; set; }
        public T Element { get; set; }
    }
}
