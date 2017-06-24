using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProductsAPI.Models;

namespace ProductsAPI.Services
{
    public class ProductDBStore : IProductStore
    {
        public IEnumerable<Product> AllProducts(string name = null, string description = null, double? price = default(double?))
        {
            using (var context = new ProductsModel())
            {
                return context.Products.ToList();
            }
        }

        public Product Create(Product product)
        {
            using (var context = new ProductsModel())
            {
                var newProduit = context.Products.Add(product);
                context.SaveChanges();
                return newProduit;
            }
        }

        public Product ProductById(int id)
        {
            using (var context = new ProductsModel())
                return context.Products.Find(id);
        }

        public void Update(int id, Product product)
        {
            using (var context = new ProductsModel())
            {
                
                var oldProduct = context.Products.Find(id);
                if (oldProduct == null)
                    throw new Exception("Le produit " + id + " n'existe pas");
                oldProduct.Description = product.Description;
                oldProduct.Name = product.Name;
                oldProduct.Price = product.Price;
                context.SaveChanges();
            }
        }
    }
}