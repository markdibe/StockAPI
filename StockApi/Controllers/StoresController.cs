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
    public class StoresController : ControllerBase
    {

        private readonly IStore _store;

        public StoresController(IStore store)
        {
            _store = store;
        }

        // GET: api/<StoresController>
        [HttpGet]
        public List<StoreBO> Get()
        {
            return _store.Get();
        }

        // GET api/<StoresController>/5
        [HttpGet("{id:int}")]
        public StoreBO Get(int id)
        {
            return _store.GetById(id);
        }

        // POST api/<StoresController>
        [HttpPost]
        public StoreBO Post([FromBody] StoreBO store)
        {
            return _store.Create(store);
        }

        // PUT api/<StoresController>/5
        [HttpPut("{id:int}")]
        public StoreBO Put(int id, [FromBody] StoreBO store)
        {
            if (id == store.Id)
            {
                return _store.Update(store);
            }
            return null;
        }

        // DELETE api/<StoresController>/5
        [HttpDelete("{id:int}")]
        public StoreBO Delete(int id)
        {
            if (_store.GetById(id) != null)
            {
                return _store.Delete(id);
            }
            return null;
        }
    }
}
