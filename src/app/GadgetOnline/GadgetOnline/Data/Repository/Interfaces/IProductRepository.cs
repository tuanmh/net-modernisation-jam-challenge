using GadgetOnline.Data.Model;
using GadgetsOnline.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GadgetOnline.Data.Repository.Interfaces
{
    public interface IProductRepository
    {
        DataResult<List<Product>> GetAll();
        DataResult<Product> Get(int id);
        DataResult<List<Product>> Filter(string search);
        DataResult<bool> Add(Product entity);
        DataResult<bool> Update(Product entity);
        DataResult<bool> Delete(int id);
    }
}
