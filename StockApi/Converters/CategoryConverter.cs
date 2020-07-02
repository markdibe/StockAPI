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
            Category cat = new Category
            {
                Description = cbo.Description,
                Id = cbo.Id,
                Items = converter.Convert(cbo.Items.ToList()) ,
                Name = cbo.Name
            };
            return cat;
        }

        public CategoryBO Convert(Category cat)
        {
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
            List<Category> CatList  = catlist.Select(x => Convert(x)).ToList();
            return CatList;
        }

        public List<CategoryBO> Convert(List<Category> catlist)
        {
            return catlist.Select(x => Convert(x)).ToList();
        }
    }
}
