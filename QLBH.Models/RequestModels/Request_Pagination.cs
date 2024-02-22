﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models
{
    public class Request_Pagination
    {
        public int PageSize { get; set; } = 20;
        public int PageNumber { get; set; }
        public string KeyWord { get; set; }
    }
}
