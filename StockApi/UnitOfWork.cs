using Microsoft.Extensions.DependencyInjection;
using StockApi.Context;
using StockApi.IServices;
using StockApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockApi
{
    public class UnitOfWork  :IUnitOfWork
    {
        private readonly StockContext _context;
        private readonly IServiceCollection _services;
        public UnitOfWork(IServiceCollection services, StockContext context)
        {
            _context = context;
            _services = services;
        }
        public void Inject()
        {
            _services.AddScoped<IAuthentication, AuthenticationService>();
        }
        
        

        
    }
}
