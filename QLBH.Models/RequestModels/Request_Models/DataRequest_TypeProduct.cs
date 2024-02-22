using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models
{
    public class DataRequest_TypeProduct
    {
        public string type_Name { get; set; }
        public IFormFile image { get; set; }
        public long productID { get; set; }
    }
}
