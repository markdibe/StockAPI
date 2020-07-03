using StockApi.Entities;
using StockApi.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockApi.Services
{
    public class TestService : IGenericFactor<Store>
    {
        public Store Create(Store value)
        {
            throw new NotImplementedException();
        }

        public Store Create_List(ref List<Store> value)
        {
            throw new NotImplementedException();
        }

        public Store Get()
        {
            throw new NotImplementedException();
        }

        public Store GetById(Store value)
        {
            throw new NotImplementedException();
        }
    }

}
