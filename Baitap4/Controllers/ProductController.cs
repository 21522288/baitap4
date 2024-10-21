using Baitap4.Models;
using Microsoft.AspNetCore.Mvc;

namespace Baitap4.Controllers
{
    public class ProductController : Controller
    {
        private readonly BookManageContext db = new BookManageContext();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult NewItem()
        {
            return View();
        }
        public IActionResult Detail()
        {
            return View();
        }
        [Route("AddNew")]
        [HttpGet]
        public IActionResult AddNew()
        {
            return View();
        }
        [Route("AddNew")]
        [HttpPost]
        public IActionResult AddNew(Book product)
        {
            if (ModelState.IsValid) { 
                db.Books.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }
    }
}
