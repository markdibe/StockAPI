using StockApi.BO;
using StockApi.Context;
using StockApi.Converters;
using StockApi.Entities;
using StockApi.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockApi.Services
{
    public class StoreService : IStore
    {
        private readonly StockContext _context;
        private StoreConverter converter;

        public StoreService(StockContext context)
        {
            _context = context;
            converter = new StoreConverter();
        }

        public StoreBO Create(StoreBO store)
        {
            Store s = converter.Convert(store);
            _context.Stores.Add(s);
            _context.SaveChanges();
            return converter.Convert(s);
        }

        public List<StoreBO> Create_List(List<StoreBO> Stores)
        {
            List<Store> stores = converter.Convert(Stores);
            _context.Stores.AddRange(stores);
            _context.SaveChanges();
            return converter.Convert(stores);
        }

        public StoreBO Delete(int id)
        {
            Store store = converter.Convert(GetById(id));
            if (store == null) { return null; }
            _context.Stores.Remove(store);
            _context.SaveChanges();
            return converter.Convert(store);
        }

        public List<StoreBO> Delete_List(List<StoreBO> Stores)
        {
            List<Store> stores = converter.Convert(Stores);
            _context.Stores.RemoveRange(stores);
            _context.SaveChanges();
            return converter.Convert(stores);
        }

        public List<StoreBO> Get()
        {
            return converter.Convert(_context.Stores.ToList());
        }

        public StoreBO GetById(int id)
        {
            return converter.Convert(_context.Stores.FirstOrDefault(x => x.Id == id));
        }

        public List<StoreBO> GetById_List(List<int> Ids)
        {
            return converter.Convert(_context.Stores.Where(x => Ids.Contains(x.Id)).ToList());
        }

        public StoreBO Update(StoreBO editedStore)
        {
            Store store = converter.Convert(editedStore);
            _context.Entry(store).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            _context.SaveChanges();
            return converter.Convert(store);
        }
    }
}
