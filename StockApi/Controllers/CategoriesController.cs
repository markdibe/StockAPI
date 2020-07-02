using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StockApi.BO;
using StockApi.IServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StockApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategory _category;
        public CategoriesController(ICategory category)
        {
            _category = category;
        }
        // GET: api/<CategoriesController>
        [HttpGet]
        public ICollection<CategoryBO> Get()
        {
            return _category.Get();
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id:Int64}")]
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
        [HttpPut("{id:Int64}")]
        public CategoryBO Put(Int64 id, [FromBody] CategoryBO category)
        {
            if (id != category.Id) { return null; }
            return _category.Update(category);
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id:Int64}")]
        public CategoryBO Delete(Int64 id)
        {
            return _category.Delete(id);
        }
    }
}
