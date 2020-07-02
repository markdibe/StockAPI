using StockApi.BO;
using StockApi.Context;
using StockApi.Converters;
using StockApi.Entities;
using StockApi.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace StockApi.Services
{
    public class ItemService : IItem
    {
        private ItemConverter converter;
        private readonly StockContext _context;
        public ItemService(StockContext context)
        {
            converter = new ItemConverter();
            _context = context;
        }

        public ItemBO Create(ItemBO item)
        {
            var Item = converter.Convert(item);
            _context.Items.Add(Item);
            _context.SaveChanges();
            return converter.Convert(Item);
        }

        public List<ItemBO> Create_List(List<ItemBO> ItemList)
        {
            List<Item> Items = converter.Convert(ItemList);
            Items.ForEach((item) =>
            {
                _context.Items.Add(item);
            });
            _context.SaveChanges();
            return converter.Convert(Items);
        }

        public ItemBO Delete(string Id)
        {
            var item = converter.Convert(GetById(Id)) ;
            if (item != null) {
                _context.Items.Remove(item);
            }
            _context.SaveChanges();
            return converter.Convert(item);
        }

        public List<ItemBO> Delete_List(List<ItemBO> ItemList)
        {
            List<Item> Items = converter.Convert(ItemList);
            Items.ForEach((item) =>
            {
                _context.Items.Remove(item);
            });
            _context.SaveChanges();
            return converter.Convert(Items);
        }

        public List<ItemBO> Get()
        {
            return converter.Convert(_context.Items.ToList());
        }

        public ItemBO GetById(string Id)
        {
            return converter.Convert(_context.Items.FirstOrDefault(x => x.Id.Equals(Id)));
        }

        public ItemBO Update(ItemBO item)
        {
            var updatedItem = converter.Convert(item);
            _context.Entry(updatedItem).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return converter.Convert(updatedItem);
        }
    }
}
