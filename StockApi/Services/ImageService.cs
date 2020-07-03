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
    public class ImageService : IImage
    {
        private readonly StockContext _context;
        private readonly ImageConverter imageConverter;

        public ImageService(StockContext context)
        {
            _context = context;
            imageConverter = new ImageConverter();
        }
        public ImageBO Create(ImageBO image)
        {
            Image _image = imageConverter.Convert(image);
            _context.Images.Add(_image);
            _context.SaveChanges();
            return imageConverter.Convert(_image);
        }

        public List<ImageBO> Create_List(List<ImageBO> images)
        {
            List<Image> ImageList = imageConverter.Convert(images);
            ImageList.ForEach((img) =>
            {
                _context.Images.Remove(img);
            });
            _context.SaveChanges();
            return imageConverter.Convert(ImageList);
        }

        public ImageBO Delete(string id)
        {
            Image image = imageConverter.Convert(GetById(id));
            _context.Images.Remove(image);
            _context.SaveChanges();
            return imageConverter.Convert(image);
        }

        public List<ImageBO> Delete_List(List<string> Ids)
        {
            List<Image> ImageList = imageConverter.Convert(GetById_List(Ids));
            ImageList.ForEach((image) =>
            {
                _context.Images.Remove(image);
            });
            _context.SaveChanges();
            return imageConverter.Convert(ImageList);
        }

        public List<ImageBO> Get()
        {
            return imageConverter.Convert(_context.Images.ToList());
        }

        public ImageBO GetById(string Id)
        {
            return imageConverter.Convert(_context.Images.FirstOrDefault(x => x.Id.Equals(Id)));
        }

        public List<ImageBO> GetById_List(List<string> Ids)
        {
            List<Image> ImageList = _context.Images.Where(x => Ids.Contains(x.Id)).ToList();
            return imageConverter.Convert(ImageList);
        }

        public ImageBO Update(ImageBO image)
        {
            Image _image = imageConverter.Convert(image);
            _context.Entry(_image).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return imageConverter.Convert(_image);
        }
    }
}
