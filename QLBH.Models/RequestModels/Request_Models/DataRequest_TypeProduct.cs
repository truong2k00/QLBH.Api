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
        public string Type_Name { get; set; }
        public IFormFile Image { get; set; }
        public long ProductID { get; set; }
    }
}
