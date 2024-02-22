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
        public long ID { get; set; }
        public string Type_Name { get; set; }
        public string Image { get; set; }
        public long ProductID { get; set; }
    }
}
