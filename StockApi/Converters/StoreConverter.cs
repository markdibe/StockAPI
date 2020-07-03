using Microsoft.AspNetCore.Mvc.Rendering;
using StockApi.BO;
using StockApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockApi.Converters
{
    public class StoreConverter
    {
        private LocationConverter lc;
        public StoreConverter()
        {
            lc = new LocationConverter();
        }

        public StoreBO Convert(Store s)
        {
            if(s is null) { return null; }
            StoreBO store = new StoreBO
            {
                Address = s.Address,
                City = s.City,
                CoordinationX = s.CoordinationX,
                CoordinationY = s.CoordinationY,
                Id = s.Id,
                ItemsQuantity = s.ItemsQuantity,
                Locations = lc.Convert(s.Locations.ToList()),
                Name = s.Name,
                Road = s.Road,
                Street = s.Street
            };
            return store;
        }



        public Store Convert(StoreBO s)
        {
            if (s == null) { return null; }
            Store store = new Store
            {
                Address = s.Address,
                City = s.City,
                CoordinationX = s.CoordinationX,
                CoordinationY = s.CoordinationY,
                Id = s.Id,
                ItemsQuantity = s.ItemsQuantity,
                Locations = lc.Convert(s.Locations.ToList()),
                Name = s.Name,
                Road = s.Road,
                Street = s.Street
            };
            return store;
        }


        public List<Store> Convert(List<StoreBO> stores)
        {
            if (stores == null) return null;
            return stores.Select(x => Convert(x)).ToList();
        }

        public List<StoreBO> Convert(List<Store> stores)
        {
            if (stores == null) return null;
            return stores.Select(x => Convert(x)).ToList();
        }


    }
}
