using StockApi.Context;
using StockApi.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockApi
{
   public  interface IUnitOfWork
    {

        void Inject();

    }
}
