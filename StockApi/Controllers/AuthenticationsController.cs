using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using StockApi.BO;
using StockApi.Converters;
using StockApi.Entities;
using StockApi.IServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StockApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationsController : ControllerBase
    {
        private readonly IAuthentication _authentication;

        public AuthenticationsController(IAuthentication authentication, IDataProtectionProvider provider)
        {
            _authentication = authentication;
        }

        // GET: api/<Authentications>
        [HttpGet]
        public ICollection<UserBO> Get()
        {
            return _authentication.Get();
        }

        // GET api/<Authentications>/5
        [HttpGet("{id}")]
        public UserBO Get(string id)
        {
            return _authentication.GetById(id);
        }

        // POST api/<Authentications>
        [HttpPost(nameof(Register))]
        public ICollection<UserBO> Register([FromBody] UserBO user)
        {
            ICollection<UserBO> userList = new List<UserBO>();
            userList.Add(user);
            return _authentication.Create(userList);
        }

        [HttpPost(nameof(Login))]
        public bool Login([FromBody] UserBO user)
        {
            //user.Password = _protector.Protect(user.Password);
            return _authentication.Login(user);
        }

        // PUT api/<Authentications>/5
        [HttpPut]
        public UserBO Put([FromBody] UserBO editedUser)
        {
            return _authentication.Update(editedUser);
        }

        // DELETE api/<Authentications>/5
        [HttpDelete("{id}")]
        public ICollection<UserBO> Delete(ICollection<string> Ids)
        {
            return _authentication.Delete(Ids);
        }
    }
}
