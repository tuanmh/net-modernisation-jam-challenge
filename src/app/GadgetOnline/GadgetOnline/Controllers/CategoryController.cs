using GadgetOnline.Data.Model;
using GadgetsOnline.Data.Repository.Implimentation;
using GadgetsOnline.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GadgetsOnline.Api
{
    [Route("[Controller]")]
    public class CategoryController : ApiController
    {

        private ICategoryRepository _categoryRepository;

        public CategoryController()
        {
            _categoryRepository = new CategoryRepository();
        }
       
        [Route("Category/All")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Ok(_categoryRepository.GetAll());
        }


        [Route("Category/{id}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            return Ok(_categoryRepository.Get(id));
;        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] Category category)
        {
            if (category == null || category.CategoryId <= 0)
                return BadRequest("Invalid Parameter");

           return Ok(_categoryRepository.Update(category));
        }

        [HttpPut]
        public IHttpActionResult Put([FromBody] Category category)
        {
            if (category == null)
                return BadRequest("Invalid Parameter");

            return Ok(_categoryRepository.Add(category));
        }

      [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            return Ok(_categoryRepository.Delete(id));
        }
    }
}