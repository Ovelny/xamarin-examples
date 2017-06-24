using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProductsAPI.Models;
using ProductsAPI.Services;

namespace ProductsAPI.Controllers
{
    public class ProductsController : ApiController
    {
        private IProductStore store;

        public ProductsController() : this(new ProductDBStore())
        {
            //this.store = new ProductStore();
        }

        public ProductsController(IProductStore store)
        {
            this.store = store;
        }


        [HttpPost]
        public Product Create(Product product)
        {
            return this.store.Create(product);
        }

        [HttpPut]
        public Product Update(int id, Product product)
        {
            try
            {
                this.store.Update(id, product);
                return this.store.ProductById(id);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        [HttpGet]
        public Product ProductById(int id)
        {
            var product = this.store.ProductById(id);

            if (product == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return product;
        }

        [HttpGet]
        public IEnumerable<Product> AllProducts(string name = null, string description  = null, double? price = null)
        {
            return this.store.AllProducts(name, description, price);
        }
    }
}
