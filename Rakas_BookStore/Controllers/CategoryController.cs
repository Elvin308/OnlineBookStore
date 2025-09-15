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
    }
}
