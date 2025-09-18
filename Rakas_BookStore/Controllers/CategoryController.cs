using Microsoft.AspNetCore.Mvc;
using Rakas_BookStore.DataAccess.Interfaces;
using Rakas_BookStore.Models;

namespace Rakas_BookStore.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IRepositoryWork _repositoryWork;
        public CategoryController(IRepositoryWork repositoryWork)
        {
            _repositoryWork = repositoryWork;
        }

        public IActionResult Index()
        {
            List<Category> categoryList = _repositoryWork.CategoryRepository.GetAll().ToList();
            return View(categoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category cat) //Gets object from html form element
        {
            //Server side validations

            if(cat.Name == cat.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Category Name and Display Order cannot match");
            }

            if (ModelState.IsValid) //Checks validation from the model/class
            {
                _repositoryWork.CategoryRepository.Add(cat);
                _repositoryWork.Save();
                TempData["success"] = "Category created succesfully"; //temporary item, last for only one page load
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Edit(int? id)
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }
            
            Category? category = _repositoryWork.CategoryRepository.GetFirstOrDefault(c => c.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category cat)
        {
            if (ModelState.IsValid)
            {
                _repositoryWork.CategoryRepository.Update(cat);
                _repositoryWork.Save();
                TempData["success"] = "Category edited succesfully"; //temporary item, last for only one page load
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Category? category = _repositoryWork.CategoryRepository.GetFirstOrDefault(c => c.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {

            Category? category = _repositoryWork.CategoryRepository.GetFirstOrDefault(c => c.Id == id);
            if (category != null)
            {
                _repositoryWork.CategoryRepository.Remove(category);
                _repositoryWork.Save();
                TempData["success"] = "Category deleted succesfully"; //temporary item, last for only one page load
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
