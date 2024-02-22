using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models
{
    public class DataRequest_ProductCategory
    {
        public string categoryName { get; set; }
        public IFormFile files { get; set; }
    }
}
