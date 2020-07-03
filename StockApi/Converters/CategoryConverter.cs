using StockApi.BO;
using StockApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockApi.Converters
{
    public class CategoryConverter
    {
        private ItemConverter converter;
        public CategoryConverter()
        {
            converter = new ItemConverter();
        }
        public Category Convert(CategoryBO cbo)
        {
            if (cbo == null) return null;
            Category cat = new Category
            {
                Description = cbo.Description,
                Id = cbo.Id,
                Items = converter.Convert(cbo.Items.ToList()),
                Name = cbo.Name
            };
            return cat;
        }

        public CategoryBO Convert(Category cat)
        {
            if (cat == null) return null;
            CategoryBO cbo = new CategoryBO
            {
                Name = cat.Name,
                Items = converter.Convert(cat.Items.ToList()),
                Id = cat.Id,
                Description = cat.Description
            };
            return cbo;
        }

        public List<Category> Convert(List<CategoryBO> catlist)
        {
            if (catlist == null) return null;
            List<Category> CatList = catlist.Select(x => Convert(x)).ToList();
            return CatList;
        }

        public List<CategoryBO> Convert(List<Category> catlist)
        {
            if (catlist == null) return null;
            return catlist.Select(x => Convert(x)).ToList();
        }
    }
}
