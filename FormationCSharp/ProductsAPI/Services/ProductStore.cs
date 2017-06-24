using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProductsAPI.Models;

namespace ProductsAPI.Services
{
    public class ProductStore : IProductStore
    {
        private static List<Product> products = new List<Product>
        {
            new Product{Id = 1, Description = "produit_1_desc", Name = "produit_1", Price = 1},
            new Product{Id = 2, Description = "produit_2_desc", Name = "produit_2", Price = 2},
            new Product{Id = 3, Description = "produit_3_desc", Name = "produit_3", Price = 3}
        };

        public IEnumerable<Product> AllProducts(string name = null, string description = null, double? price = null)
        {
            return products;
        }

        public Product ProductById(int id)
        {
            foreach (var product in products)
            {
                if (product.Id == id)
                {
                    return product;
                }
            }
            return null;
        }

        public Product Create(Product product)
        {
            var id = products.Max(p => p.Id) + 1;
            product.Id = id;
            products.Add(product);
            return product;
        }

        /// <summary>
        /// Met à jour un produit
        /// </summary>
        /// <param name="id">identifiant du produit</param>
        /// <param name="product">Informations de mise à jour concernant le produit</param>
        /// <exception cref="Exception">Levée quand le produit n'existe pas</exception>
        public void Update(int id, Product product)
        {
            var index = products.FindIndex(p => p.Id == id);
            if (index < 0)
                throw new Exception("le produit " + id + " n'existe pas");

            product.Id = id;
            products[index] = product;

            // Variante 2
            var tmp = this.ProductById(id);
            if (tmp == null)
                throw new Exception("le produit " + id + " n'existe pas");
            tmp.Name = product.Name;
            tmp.Description = product.Description;
            tmp.Price = product.Price;
        }
    }
}