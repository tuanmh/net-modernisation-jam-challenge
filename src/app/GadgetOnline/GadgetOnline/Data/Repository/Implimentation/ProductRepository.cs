using GadgetOnline.Data.Model;
using GadgetOnline.Data.Repository.Interfaces;
using GadgetsOnline.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GadgetOnline.Data.Repository.Implimentation
{
    public class ProductRepository : IProductRepository
    {
        GadgetsOnlineEntities store = new GadgetsOnlineEntities();
        public DataResult<bool> Add(Product entity)
        {
            if (store.Categories.Where(c => c.Name == entity.Name).ToList().Any())
                return InvalidRequest("Product Name Already  Present");

            store.Products.Add(entity);
            var result = store.SaveChanges();

            return new DataResult<bool>
            {
                Completed = true,
                Data = result != -1,
                Reason = result != -1 ? "Failed to add the Product" : "Successfully added the Product"
            };
        }

        public DataResult<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public DataResult<List<Product>> Filter(string search)
        {
            throw new NotImplementedException();
        }

        public DataResult<Product> Get(int id)
        {

            var result = new DataResult<Product>
            {
                Completed = true,
                Data = store.Products.FirstOrDefault(c => c.ProductId == id)
            };
            return result;
        }

        public DataResult<List<Product>> GetAll()
        {
            var result = new DataResult<List<Product>>
            {
                Completed = true,
                Data = store.Products.ToList()
            };

            return result;
        }

        public DataResult<bool> Update(Product entity)
        {
            var existingProduct = store.Products.FirstOrDefault(c => c.ProductId == entity.ProductId);

            if (existingProduct == null || existingProduct.ProductId <= 0)
                return InvalidRequest("Product not found");

            var result = store.SaveChanges();

            return new DataResult<bool>
            {
                Completed = true,
                Data = result != -1,
                Reason = result != -1 ? "Failed to update the Product" : "Successfully update the Product"
            };
        }

        private static DataResult<bool> InvalidRequest(string message)
        {
            return new DataResult<bool>
            {
                Completed = false,
                Data = false,
                Reason = message
            };
        }
    }
}