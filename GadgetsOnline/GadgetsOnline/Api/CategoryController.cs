using GadgetsOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GadgetsOnline.Api
{
    public class CategoryController : ApiController
    {
        GadgetsOnlineEntities store = new GadgetsOnlineEntities();
       
        [Route("Category/All")]
        public IEnumerable<Category> GetAll()
        {
            return store.Categories.ToList();
        }

        // GET api/<controller>/5
        public Category Get(int id)
        {
            return store.Categories.FirstOrDefault(c => c.CategoryId == id)
;        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}