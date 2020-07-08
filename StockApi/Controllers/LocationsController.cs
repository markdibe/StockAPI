using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StockApi.BO;
using StockApi.Entities;
using StockApi.IServices;
using StockApi.Parameters;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StockApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {

        private readonly ILocation _location;
        public LocationsController(ILocation location)
        {
            _location = location;
        }
        // GET: api/<LocationsController>
        [HttpGet]
        public List<LocationBO> Get([FromQuery] QueryParameters parameters)
        {
            IQueryable<LocationBO> locs = _location.GetQuery(parameters);
            return locs.ToList();
        }

        [HttpGet]
        public List<LocationBO> Get( string[] Ids)
        {
            long[] identities = new long[Ids.Length];
            Ids.ToList().Select(x=> identities.Append(long.Parse(x)));
            return  _location.Get(identities.ToList());
        }

        // GET api/<LocationsController>/5
        [HttpGet("{id:long}")]
        public LocationBO Get(long id)
        {
            return _location.Get(id);
        }

        // POST api/<LocationsController>
        [HttpPost]
        public LocationBO Post([FromBody] LocationBO location)
        {
            return _location.Create(location);
        }

        // PUT api/<LocationsController>/5
        [HttpPut("{id:long}")]
        public LocationBO Put(long id, [FromBody] LocationBO updatedLocation)
        {
            return _location.Update(updatedLocation);
        }

        // DELETE api/<LocationsController>/5
        [HttpDelete("{id:long}")]
        public LocationBO Delete(long id)
        {
            return _location.Delete(id);
        }
    }
}
