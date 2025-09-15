using Microsoft.AspNetCore.Mvc;
using Rakas_BookStore.Data;
using Rakas_BookStore.Models;

namespace Rakas_BookStore.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Category> categoryList  = _db.Categories.ToList();
            return View(categoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category cat) //Gets object from html form element
        {
            _db.Categories.Add(cat);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
