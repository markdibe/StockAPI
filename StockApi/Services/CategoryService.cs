using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
    public class CategoryService : ICategory
    {
        private readonly StockContext _context;
        private CategoryConverter converter;
        public CategoryService(StockContext context)
        {
            _context = context;
            converter = new CategoryConverter();
        }
        public CategoryBO Create(CategoryBO cat)
        {
            var category = converter.Convert(cat);
            _context.Categories.Add(category);
            _context.SaveChanges();
            return converter.Convert(category) ;
        }

        public List<CategoryBO> Create_List(List<CategoryBO> categories)
        {
            List<Category> catList = converter.Convert(categories);
            catList.ForEach((category) =>
            {
                _context.Categories.Add(category);
            });
            _context.SaveChanges();
            return converter.Convert(catList);
        }

        public CategoryBO Delete(Int64 id)
        {
            Category cat = converter.Convert(GetById(id)) ;
            if (cat != null)
            {
                _context.Categories.Remove(cat);
                _context.SaveChanges();
            }
            return converter.Convert(cat);
        }

        public List<CategoryBO> Get()
        {
            return converter.Convert(_context.Categories.ToList());
        }

        public CategoryBO GetById(long id)
        {
            return converter.Convert(_context.Categories.FirstOrDefault(x => x.Id == id));
        }

        public CategoryBO Update(CategoryBO cat)
        {
            Category category = converter.Convert(cat);
            _context.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return converter.Convert(category);
        }
    }
}
