using GadgetsOnline.Models;
using GadgetsOnline.Repository.Implimentation;
using GadgetsOnline.Repository.Interfaces;
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

        private ICategoryRepository _categoryRepository;

        public CategoryController()
        {
            _categoryRepository = new CategoryRepository();
        }
       
        [Route("Category/All")]
        public IHttpActionResult GetAll()
        {
            return Ok(_categoryRepository.GetAll());
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            return Ok(_categoryRepository.Get(id));
;        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody] Category category)
        {
            if (category == null || category.CategoryId <= 0)
                return BadRequest("Invalid Parameter");

           return Ok(_categoryRepository.Update(category));
        }
       
        // PUT api/<controller>/5
        public IHttpActionResult Put([FromBody] Category category)
        {
            if (category == null)
                return BadRequest("Invalid Parameter");

            return Ok(_categoryRepository.Add(category));
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            return Ok(_categoryRepository.Delete(id));
        }
    }
}