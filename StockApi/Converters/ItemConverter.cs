using StockApi.BO;
using StockApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockApi.Converters
{
    public class ItemConverter
    {
        private CategoryConverter converter;
        public ItemConverter()
        {
            converter = new CategoryConverter();
        }
        public Item Convert(ItemBO item)
        {
            Item Item = new Item
            {
                BarCode = item.BarCode,
                Category = converter.Convert(item.Category),
                CategoryId = item.CategoryId,
                Name = item.Name,
                Id = item.Id
            };
            return Item;
        }

        public ItemBO Convert(Item item)
        {
            ItemBO itemBO = new ItemBO
            {
                Id = item.Id,
                Name = item.Name,
                CategoryId = item.CategoryId,
                BarCode = item.BarCode,
                Category = converter.Convert(item.Category) 
            };
            return itemBO;
        }

        public List<Item> Convert(List<ItemBO> ItemList)
        {
            return ItemList.Select(x => Convert(x)).ToList();
        }

        public List<ItemBO> Convert(List<Item> ItemList)
        {
            return ItemList.Select(x => Convert(x)).ToList();
        }
    }
}
