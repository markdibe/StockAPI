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
    public class ImagesController : ControllerBase
    {
        private readonly  IImage _image;

        public ImagesController(IImage image)
        {
            _image = image;
        }

        // GET: api/<ImagesController>
        [HttpGet]
        public List<ImageBO> Get()
        {
            return _image.Get();
        }

        // GET api/<ImagesController>/5
        [HttpGet("{id}")]
        public ImageBO Get(string  id)
        {
            return _image.GetById(id);
        }

        // POST api/<ImagesController>
        [HttpPost]
        public ImageBO Post([FromBody] ImageBO image)
        {
            return _image.Create(image);
        }

        // PUT api/<ImagesController>/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] ImageBO image)
        {
            if (id == image.Id) 
            {
                _image.Update(image);
            }
        }

        // DELETE api/<ImagesController>/5
        [HttpDelete("{id}")]
        public ImageBO Delete(string id)
        {
            return _image.Delete(id);
        }
    }
}
