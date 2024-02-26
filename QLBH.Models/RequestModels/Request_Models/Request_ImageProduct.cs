using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models
{
    public class Request_ImageProduct
    {
        public long product_ID { get; set; }
        public long accountID { get; set; }
        public IFormFile file { get;set; }
    }
}
