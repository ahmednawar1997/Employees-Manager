﻿using Employees_Manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employees_Manager.Data.EFCore
{
    public class RequestRepository : ConcreteRepository<Request>
    {

        public RequestRepository(ApplicationDbContext _db) : base(_db)
        {

        }

        public override Task<Request> Update(Request entity)
        {
            throw new NotImplementedException();
        }
    }
}
