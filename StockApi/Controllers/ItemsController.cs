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
    public class ItemsController : ControllerBase
    {
        private readonly IItem _item;
        private readonly ICategory _category;
        public ItemsController(IItem item, ICategory category)
        {
            _item = item;
            _category = category;
        }

        // GET: api/<ItemsController>
        [HttpGet]
        public ICollection<ItemBO> Get()
        {
            var Catlist = _category.Get();
            Catlist.ForEach((cat) =>
            {
                int i = 0;
                while (i < 10)
                {
                    _item.Create(new ItemBO { BarCode = "1234568789", CategoryId = cat.Id, Name = "Item Name " + i });
                    i += 1;
                }
                    
                
            });
            return _item.Get().ToList();
        }

        // GET api/<ItemsController>/5
        [HttpGet("{id:Guid}")]
        public ItemBO Get(string id)
        {
            return _item.GetById(id);
        }

        // POST api/<ItemsController>
        [HttpPost]
        public ItemBO Post([FromBody] ItemBO item)
        {
            return _item.Create(item);
        }

        // PUT api/<ItemsController>/5
        [HttpPut("{id:Guid}")]
        public ItemBO Put(string id, [FromBody] ItemBO item)
        {
            return _item.Update(item);
        }

        // DELETE api/<ItemsController>/5
        [HttpDelete("{id:Guid}")]
        public ItemBO Delete(string id)
        {
            return _item.Delete(id);
        }
    }
}
