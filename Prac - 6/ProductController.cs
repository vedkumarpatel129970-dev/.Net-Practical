using System.Collections.Generic;
using System.Web.Mvc;
using ProductCatalog.Models;

namespace ProductCatalog.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            List<Product> products = new List<Product>()
            {
                new Product
                {
                    Id = 1,
                    Name = "Laptop",
                    Category = "Electronics",
                    Price = 55000
                },

                new Product
                {
                    Id = 2,
                    Name = "Mobile Phone",
                    Category = "Electronics",
                    Price = 25000
                },

                new Product
                {
                    Id = 3,
                    Name = "Headphones",
                    Category = "Accessories",
                    Price = 2000
                },

                new Product
                {
                    Id = 4,
                    Name = "Smart Watch",
                    Category = "Wearable",
                    Price = 4500
                }
            };

            return View(products);
        }
    }
}