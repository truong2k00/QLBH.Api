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
        public long productID { get; set; }
        public string username { get; set; }
        public string metaProduct { get; set; }
        public decimal evaluate { get; set; }
        public List<Respon_ImageProduct> imageProduct { get; set; }
    }
}
