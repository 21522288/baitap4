using Baitap4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Baitap4.Controllers
{
    public class ProductController : Controller
    {
        private readonly BookManageContext db = new BookManageContext();
        public IActionResult Index()
        {
            var list = db.Books.ToList();
            return View(list);
        }
        public IActionResult NewItem()
        {
            return View();
        }
        [Route("Detail")]
        [HttpGet]
        public IActionResult Detail(int id)
        {
            var book = db.Books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            // Trả về view cùng với model Book
            return View(book);
        }
        //[Route("AddNew")]
        //[HttpGet]
        //public IActionResult AddNew()
        //{
        //    return View();
        //}
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

        [Route("EditItem")]
        [HttpGet]
        public IActionResult EditItem( int id)
        {
            var book = db.Books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            // Trả về view cùng với model Book
            return View(book);
        }
        [Route("EditItem")]
        [HttpPost]
        public IActionResult EditItem(Book product)
        {
            if (ModelState.IsValid)
            {
                db.Books.Update(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            // Tìm sách theo id
            var book = await db.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound(); // Trả về nếu không tìm thấy sách
            }

            // Xóa sách
            db.Books.Remove(book);
            await db.SaveChangesAsync(); // Lưu thay đổi

            // Chuyển hướng về trang danh sách sách (hoặc trang khác)
            return RedirectToAction("Index");
        }
    }
}
