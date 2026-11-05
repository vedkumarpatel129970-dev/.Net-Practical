using System.Linq;
using System.Web.Mvc;
using Practical8.Models;
using Practical8.Services;

namespace Practical8.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductService service = new ProductService();

        public ActionResult Index()
        {
            var products = service.GetAll();
            ViewBag.TotalProducts = products.Count;
            ViewBag.TotalUnits = products.Sum(p => p.Quantity);
            ViewBag.LowStock = products.Count(p => p.Quantity <= 5);
            return View(products);
        }

        public ActionResult Create()
        {
            return View(new Product());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                service.Add(product);
                TempData["Success"] = "Product added successfully.";
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public ActionResult Edit(int id)
        {
            Product product = service.GetById(id);
            if (product == null) return HttpNotFound();
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                service.Update(product);
                TempData["Success"] = "Product updated successfully.";
                return RedirectToAction("Index");
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            service.Delete(id);
            TempData["Success"] = "Product deleted successfully.";
            return RedirectToAction("Index");
        }
    }
}