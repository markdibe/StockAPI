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
    public class HolderInformationsController : ControllerBase
    {

        private readonly IHolderInfo _holder;

        public HolderInformationsController(IHolderInfo holder)
        {
            _holder = holder;
        }
        // GET: api/<HolderInformationsController>
        [HttpGet]
        public List<HolderInformationBO> Get()
        {
            return _holder.Get();
        }

        // GET api/<HolderInformationsController>/5
        [HttpGet("{id:long}")]
        public HolderInformationBO Get(long id)
        {
            return _holder.GetById(id);
        }

        // POST api/<HolderInformationsController>
        [HttpPost]
        public HolderInformationBO Post([FromBody] HolderInformationBO holder)
        {
            return _holder.Create(holder);
        }

        // PUT api/<HolderInformationsController>/5
        [HttpPut("{id:long}")]
        public void Put(long id, [FromBody] HolderInformationBO editedHolder)
        {
            if (id == editedHolder.Id)
            {
                _holder.Update(editedHolder);
            }
        }

        // DELETE api/<HolderInformationsController>/5
        [HttpDelete("{id:long}")]
        public void Delete(long id)
        {
            _holder.Delete(id);
        }
    }
}
