﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models
{
    public class DataRequest_Bill
    {
        public long statusBillID { get; set; }
        public long accountID { get; set; }
        public List<DataRequest_InvoiceDetails> invoiceDetail { get; set; }
        public long addressReceiveID { get; set; }
    }
}
