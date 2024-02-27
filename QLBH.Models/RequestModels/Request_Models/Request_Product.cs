using Microsoft.AspNetCore.Http;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models
{
    public class Request_Product
    {
        public long accountID { get; set; }
        public string product_Name { get; set; }
        public string productDescription { get; set; }
        public long categoryID { get; set; }
        public bool isNew { get; set; }
        public bool sale { get; set; }
        public long quantity { get; set; }
        public long price { get; set; }
        public decimal priceSale { get; set; }
    }
}
