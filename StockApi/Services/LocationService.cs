using StockApi.BO;
using StockApi.Context;
using StockApi.Converters;
using StockApi.Entities;
using StockApi.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace StockApi.Services
{
    public class LocationService:ILocation
    {
        private readonly StockContext _context;
        private LocationConverter converter;
        public LocationService(StockContext context)
        {
            _context = context;
            converter = new LocationConverter();
        }

        public LocationBO Create(LocationBO location)
        {
            Location loc = converter.Convert(location);
            if (loc == null) return null;
            _context.Locations.Add(loc);
            _context.SaveChanges();
            return converter.Convert(loc);
        }

        public List<LocationBO> Create(List<LocationBO> locations)
        {
            List<Location> locs = converter.Convert(locations);
            _context.Locations.AddRange(locs);
            _context.SaveChanges();
            return converter.Convert(locs);
        }

        public LocationBO Delete(long Id)
        {
            Location location = converter.Convert(Get(Id));
            _context.Locations.Remove(location);
            _context.SaveChanges();
            return converter.Convert(location)
        }

        public List<LocationBO> Delete(List<long> Ids)
        {
            List<Location> locations = converter.Convert(Get(Ids));
            _context.Locations.RemoveRange(locations.ToArray());
            _context.SaveChanges();
            return converter.Convert(locations);
        }

        public List<LocationBO> Get(List<long> Ids)
        {
            List<Location> locations = _context.Locations.Where(x=>Ids.Contains(x.Id)).ToList();
            return converter.Convert(locations);
        }

        public List<LocationBO> Get()
        {
            return converter.Convert(_context.Locations.ToList());
        }

        public LocationBO Get(long Id)
        {
            return converter.Convert(_context.Locations.FirstOrDefault(x => x.Id == Id));
        }

        public LocationBO Update(LocationBO location)
        {
            Location updateLocation = converter.Convert(location);
            _context.Entry<Location>(updateLocation).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return converter.Convert(updateLocation);

        }
    }
}
