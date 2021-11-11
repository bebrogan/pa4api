using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using api.Model;
using api.Interfaces;
using api.Data;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        // GET: api/Post
        [HttpGet]
        public List<Post> Get()
        {
            IPostDataHandler dataHandler = new PostDataHandler();
            return dataHandler.Select();
        }

        // GET: api/Post/5
        [EnableCors("AnotherPolicy")]

        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Post
        [HttpPost]
        public void Post([FromBody] Post value)
        {
            value.dataHandler.Insert(value);
        }

        // PUT: api/Post/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Post/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Post value = new Post(){ID = id};
            value.dataHandler.Delete(value);
        }
    }
}
