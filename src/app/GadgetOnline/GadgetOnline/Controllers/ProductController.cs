using GadgetOnline.Data.Model;
using GadgetOnline.Data.Repository.Implimentation;
using GadgetOnline.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GadgetsOnline.Api
{
    public class ProductController : ApiController
    {
        private IProductRepository _productRepository;

        public ProductController()
        {
            _productRepository = new ProductRepository();
        }

        [Route("Product/All")]
        public IHttpActionResult GetAll()
        {
            return Ok(_productRepository.GetAll());
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            return Ok(_productRepository.Get(id));
            ;
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody] Product category)
        {
            if (category == null || category.ProductId <= 0)
                return BadRequest("Invalid Parameter");

            return Ok(_productRepository.Update(category));
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put([FromBody] Product category)
        {
            if (category == null)
                return BadRequest("Invalid Parameter");

            return Ok(_productRepository.Add(category));
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            return Ok(_productRepository.Delete(id));
        }
    }
}