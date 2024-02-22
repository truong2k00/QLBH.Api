using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models.Entities
{
    public class Address_Receive : DeleteEntity
    {
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Full_Name { get; set; }
        public string Describe { get; set; }
        public string Email { get; set; }
        public bool Confirm { get; set; }
        public long AccountID { get; set; }
        public virtual Account Account { get; set; }
        public virtual ICollection<Bill> Bill { get; set; }
        public virtual ICollection<ConfirmEmail> ConfirmEmail { get; set; }
    }
}
