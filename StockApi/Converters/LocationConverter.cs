using StockApi.BO;
using StockApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockApi.Converters
{
    public class LocationConverter
    {
        private StoreConverter sc;
        
        public LocationConverter()
        {
            sc = new StoreConverter();
        }

        public LocationBO Convert(Location l)
        {
            if (l == null) { return null; }
            LocationBO location = new LocationBO
            {
                CoordinationX = l.CoordinationX,
                CoordinationY = l.CoordinationY,
                Description = l.Description,
                Id = l.Id,
                Name = l.Name,
                ParentId = l.ParentId,
                Store = sc.Convert(l.Store),
                StoreId = l.StoreId
            };
            return location;
        }

        public Location Convert(LocationBO l)
        {
            if (l == null) { return null; }
            Location location = new Location
            {
                CoordinationX = l.CoordinationX,
                CoordinationY = l.CoordinationY,
                Description = l.Description,
                Id = l.Id,
                Name = l.Name,
                ParentId = l.ParentId,
                Store = sc.Convert(l.Store),
                StoreId = l.StoreId
            };
            return location;
        }

        public List<Location> Convert(List<LocationBO> locations)
        {
            if (locations == null) { return null; }
            return locations.Select(x => Convert(x)).ToList();
        }

        public List<LocationBO> Convert(List<Location> locations)
        {
            if (locations == null) { return null; }
            return locations.Select(x => Convert(x)).ToList();
        }

    }
}
