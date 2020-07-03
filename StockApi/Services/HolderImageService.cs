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
    public class HolderImageService : IHolderImage
    {
        private readonly StockContext _context;
        private readonly HolderImagesConverter converter;

        public HolderImageService(StockContext context)
        {
            _context = context;
            converter = new HolderImagesConverter();
        }
        public HolderImagesBO Create(HolderImagesBO holder)
        {
            HolderImages holderImage = converter.Convert(holder);
            _context.HolderImages.Add(holderImage);
            _context.SaveChanges();
            return converter.Convert(holderImage);
        }

        public List<HolderImagesBO> Create_List(List<HolderImagesBO> holderImages)
        {
            List<HolderImages> holders = converter.Convert(holderImages);
            _context.HolderImages.AddRange(holders.ToArray());
            _context.SaveChanges();
            return converter.Convert(holders);
        }

        public HolderImagesBO Delete(string id)
        {
            HolderImages holder = converter.Convert(GetById(id));
            _context.HolderImages.Remove(holder);
            _context.SaveChanges();
            return converter.Convert(holder);
        }

        public List<HolderImagesBO> Delete_List(List<HolderImagesBO> holderImages)
        {
            List<HolderImages> holders = converter.Convert(holderImages);
            _context.HolderImages.RemoveRange(holders.ToArray());
            _context.SaveChanges();
            return converter.Convert(holders);
        }

        public HolderImagesBO GetById(string Id)
        {
            return converter.Convert(_context.HolderImages.FirstOrDefault(x => x.Id.Equals(Id)));
        }

        public List<HolderImagesBO> GetById_List(List<string> Ids)
        {
            List<HolderImages> holderImages = _context.HolderImages.Where(x => Ids.Contains(x.Id)).ToList();
            return converter.Convert(holderImages);
        }

        public HolderImagesBO Update(HolderImagesBO holder)
        {
            HolderImages holderImages = converter.Convert(holder);
            _context.Entry(holderImages).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return converter.Convert(holderImages);
        }
    }
}
