using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models
{
    public class DataResponse_TypeProduct
    {
        public long iD { get; set; }
        public string typeName { get; set; }
        public string image { get; set; }
        public long productID { get; set; }
    }
}
