﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models
{
    public class DataResponse_InvoiceDetail : DataRequest_InvoidDetails
    {
        public long billId { get; set; }
    }
}
