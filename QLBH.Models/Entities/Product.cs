using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models.Entities
{
    public class Product : DeleteEntity
    {
        public string Product_Name { get; set; }
        public string Product_Description { get; set; }
        public string Meta_Product { get; set; }
        public long ProductCatogoryID { get; set; }
        public ProductCategory ProductCatogory { get; set; }
        public bool Is_New { get; set; }
        public bool Sale { get; set; }
        public DateTime? Date_Delete { get; set; }
        public long Quantity { get; set; }
        public long Price { get; set; }
        public decimal Price_Sale { get; set; }
        public long AccountID { get; set; }
        public virtual Account Account { get; set; }
        public decimal Evaluate { get; set; }
        public virtual ICollection<Detail_Cart> Detail_Cart { get; set; }
        public virtual ICollection<Details> Details { get; set; }
        public virtual ICollection<ImageProduct> ImageProduct { get; set; }
        public virtual ICollection<Comment_Product> Comment_Product { get; set; }
        public virtual ICollection<FeedBack> FeedBack { get; set; }
    }
}
