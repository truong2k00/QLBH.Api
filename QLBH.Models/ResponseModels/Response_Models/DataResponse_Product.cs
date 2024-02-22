using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models
{
    public class DataResponse_Product : Request_Product
    {
        public long Product_ID { get; set; }
        public string Username { get; set; }
        public string Meta_Product { get; set; }
        public decimal Evaluate { get; set; }
        public List<Respon_ImageProduct> ImageProduct { get; set; }
    }
}
