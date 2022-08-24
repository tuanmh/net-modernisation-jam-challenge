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
    [Route("[Controller]")]
    public class ProductController : ApiController
    {
        private IProductRepository _productRepository;

        public ProductController()
        {
            _productRepository = new ProductRepository();
        }

        [Route("Product/All")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Ok(_productRepository.GetAll());
        }

        [Route("Product/{id}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            return Ok(_productRepository.Get(id));
            ;
        }

       [HttpPost]
        public IHttpActionResult Post([FromBody] Product category)
        {
            if (category == null || category.ProductId <= 0)
                return BadRequest("Invalid Parameter");

            return Ok(_productRepository.Update(category));
        }

        [HttpPut]
        public IHttpActionResult Put([FromBody] Product category)
        {
            if (category == null)
                return BadRequest("Invalid Parameter");

            return Ok(_productRepository.Add(category));
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            return Ok(_productRepository.Delete(id));
        }
    }
}