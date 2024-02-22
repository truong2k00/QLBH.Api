using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models
{
    public class Request_Pagination
    {
        public int pageSize { get; set; } = 20;
        public int pageNumber { get; set; }
        public string keyWord { get; set; }
    }
}
