using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        [HttpGet]
        public Product[] GetAllProducts()
        {
            return FakeData.Products.Values.ToArray();
        }

        [HttpGet("{id}")]
        public Product GetProductByID(int id)
        {
            if (FakeData.Products.ContainsKey(id))
                return FakeData.Products[id];
            else
                return null;
        }

        [HttpPost]
        public Product CreateProduct([FromBody]Product product)
        {
            product.ID = FakeData.Products.Keys.Max() + 1;
            FakeData.Products.Add(product.ID, product);

            return product; //contains the new ID
        }

        [HttpPut("{id}")]
        public void UpdateProductByID(int id, [FromBody]Product product)
        {
            if(FakeData.Products.ContainsKey(id))
            {
                var target = FakeData.Products[id];
                target.ID = product.ID;
                target.Name = product.Name;
                target.Price = product.Price;
            }
        }

        [HttpDelete("{id}")]
        public void DeleteProductByID(int id)
        {
            if(FakeData.Products.Contains(id))
            {
                FakeData.Products.Remove(id);
            }
        }

    }
}
