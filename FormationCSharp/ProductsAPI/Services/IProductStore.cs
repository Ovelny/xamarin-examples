using System.Collections.Generic;
using ProductsAPI.Models;

namespace ProductsAPI.Services
{
    public interface IProductStore
    {
        IEnumerable<Product> AllProducts(string name = null, string description = null, double? price = default(double?));
        Product Create(Product product);
        Product ProductById(int id);
        void Update(int id, Product product);
    }
}