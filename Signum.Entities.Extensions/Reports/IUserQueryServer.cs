﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Signum.Entities;
using Signum.Entities.DynamicQuery;
using Signum.Entities.Reports;

namespace Signum.Services
{
    [ServiceContract]
    public interface IUserQueryServer
    {
        [OperationContract, NetDataContract]
        List<Lite<UserQueryDN>> GetUserQueries(object queryName);

        [OperationContract, NetDataContract]
        void RemoveUserQuery(Lite<UserQueryDN> lite);
    }

   
}
