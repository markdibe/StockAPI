using StockApi.BO;
using StockApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockApi.Converters
{
    public class ImageConverter
    {
        public ImageBO Convert(Image i)
        {
            if (i == null) { return null; }
            ImageBO image = new ImageBO
            {
                Description = i.Description,
                Id = i.Id,
                Name = i.Name,
                Url = i.Url
            };
            return image;
        }

        public Image Convert(ImageBO i)
        {
            if (i == null) { return null; }
            Image image = new Image
            {
                Description = i.Description,
                Id = i.Id,
                Name = i.Name,
                Url = i.Url
            };
            return image;
        }

        public List<Image> Convert(List<ImageBO> images)
        {
            if (images == null) { return null; }
            return images.Select(i => Convert(i)).ToList();
        }

        public List<ImageBO> Convert(List<Image> images)
        {
            if (images == null) { return null; }
            return images.Select(i => Convert(i)).ToList();
        }
    }
}
