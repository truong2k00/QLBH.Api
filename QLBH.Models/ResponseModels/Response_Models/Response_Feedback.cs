﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QLBH.Commons.Enums;

namespace QLBH.Models
{
    public class Response_Feedback
    {
        public string FeedBack_Quality { get; set; }
        public string Opinion { get; set; }
        public Star Star { get; set; }
    }
}
