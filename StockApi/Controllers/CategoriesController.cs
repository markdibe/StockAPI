using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StockApi.BO;
using StockApi.Entities;
using StockApi.IServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StockApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategory _category;
        private readonly IItem _item;
        public CategoriesController(ICategory category, IItem item)
        {
            _category = category;
            _item = item;
        }
        // GET: api/<CategoriesController>
        [HttpGet]
        public ICollection<CategoryBO> Get()
        {

            var list = _category.Get();
            //List<ItemBO> items = new List<ItemBO>();
            //int i = 0;
            //list.ForEach((cat) =>
            //{
            //    ItemBO item = new ItemBO
            //    {
            //        BarCode = "00000000000",
            //        CategoryId = cat.Id,
            //        Name = i + "Item Name here" + i
            //    };
            //items.Add(item);
            //});
            //_item.Create_List(items);
            return list;
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id:int}")]
        public CategoryBO Get(Int64 id)
        {
            return _category.GetById(id);
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public CategoryBO Post([FromBody] CategoryBO category)
        {
            return _category.Create(category);
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id:long}")]
        public CategoryBO Put(Int64 id, [FromBody] CategoryBO category)
        {
            if (id != category.Id) { return null; }
            return _category.Update(category);
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id:long}")]
        public CategoryBO Delete(Int64 id)
        {
            return _category.Delete(id);
        }
    }
}
