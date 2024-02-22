﻿using QLBH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Business
{
    public interface IFeedbackServices<TEntity> : IReponsitory<Request_Feedback, Response_Feedback, long>
    {
        IEnumerable<TEntity> Get(long accountId = 0, long productId = 0);
    }
}