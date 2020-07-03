using StockApi.BO;
using StockApi.Context;
using StockApi.Converters;
using StockApi.Entities;
using StockApi.IServices;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace StockApi.Services
{
    public class HolderInformationService : IHolderInfo
    {
        private readonly StockContext _context;
        private HolderInformationConverter hiConverter;

        public HolderInformationService(StockContext context)
        {
            _context = context;
            hiConverter = new HolderInformationConverter();
        }

        public HolderInformationBO Create(HolderInformationBO holderInformation)
        {
            HolderInformation holder = hiConverter.Convert(holderInformation);
            _context.HolderInformations.Add(holder);
            _context.SaveChanges();
            return hiConverter.Convert(holder);
        }

        public List<HolderInformationBO> Create_List(List<HolderInformationBO> holderInformationList)
        {
            List<HolderInformation> holderInformations = hiConverter.Convert(holderInformationList);
            holderInformations.ForEach((holder) =>
            {
                _context.HolderInformations.Add(holder);
            });
            _context.SaveChanges();
            return hiConverter.Convert(holderInformations);
        }

        public HolderInformationBO Delete(long id)
        {
            HolderInformation hi = hiConverter.Convert(GetById(id));
            if (hi == null) { return null; }
            _context.HolderInformations.Remove(hi);
            _context.SaveChanges();
            return hiConverter.Convert(hi);
        }

        public List<HolderInformationBO> Delete_List(List<long> Ids)
        {
            List<HolderInformation> hiList=  hiConverter.Convert(GetById_List(Ids));
            hiList.ForEach((hi) =>
            {
                _context.HolderInformations.Remove(hi);
            });
            _context.SaveChanges();
            return hiConverter.Convert(hiList);
        }

        public List<HolderInformationBO> Get()
        {
            return hiConverter.Convert(_context.HolderInformations.ToList());
        }

        public HolderInformationBO GetById(long id)
        {
            return hiConverter.Convert(_context.HolderInformations.FirstOrDefault(x => x.Id == id));
        }

        public List<HolderInformationBO> GetById_List(List<long> Ids)
        {
            return hiConverter.Convert(_context.HolderInformations.Where(x => Ids.Contains(x.Id)).ToList());
        }

        public HolderInformationBO Update(HolderInformationBO holderInformation)
        {
            HolderInformation holder = hiConverter.Convert(GetById(holderInformation.Id));
            _context.Entry(holder).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return hiConverter.Convert(holder) ;
        }
    }
}
