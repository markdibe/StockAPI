using StockApi.BO;
using StockApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockApi.Converters
{
    public class ItemImageConverter
    {
        private ItemConverter ic;
        private ImageConverter imc;


        public ItemImageConverter()
        {
            ic = new ItemConverter();
            imc = new ImageConverter();
        }

        public ItemImageBO Convert(ItemImages ii)
        {
            ItemImageBO itemImage = new ItemImageBO
            {
                Id = ii.Id,
                Image = imc.Convert(ii.Image) ,
                ImageId = ii.ImageId,
                Item = ic.Convert(ii.Item) ,
                ItemId = ii.ItemId
            };
            return itemImage;
        }

        public ItemImages Convert(ItemImageBO ii)
        {
            ItemImages itemImage = new ItemImages
            {
                Id = ii.Id,
                Image = imc.Convert(ii.Image),
                ImageId = ii.ImageId,
                Item = ic.Convert(ii.Item),
                ItemId = ii.ItemId
            };
            return itemImage;
        }

        public List<ItemImages> Convert(List<ItemImageBO> itemImages)
        {
            return itemImages.Select(x => Convert(x)).ToList();
        }

        public List<ItemImageBO> Convert(List<ItemImages> itemImages)
        {
            return itemImages.Select(x => Convert(x)).ToList();
        }

    }
}
