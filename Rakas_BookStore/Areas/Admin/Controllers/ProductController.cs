using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Rakas_BookStore.DataAccess.Interfaces;
using Rakas_BookStore.Models;
using Rakas_BookStore.Models.ViewModels;

namespace Rakas_BookStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {

        private readonly IRepositoryWork _repositoryWork;

        public ProductController(IRepositoryWork repositoryWork)
        {
            _repositoryWork = repositoryWork;
        }

        public IActionResult Index()
        {
            List<Product> productList = _repositoryWork.ProductRepository.GetAll().ToList();
            return View(productList);
        }

        public IActionResult Create()
        {
            ProductVM productVM = new ProductVM
            {
                CategoryList = _repositoryWork.CategoryRepository
                .GetAll().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }),
                Product = new Product()
            };
            return View(productVM);
        }


        [HttpPost]
        public IActionResult Create(ProductVM prod)
        {
            if (ModelState.IsValid)
            {
                _repositoryWork.ProductRepository.Add(prod.Product);
                _repositoryWork.Save();

                TempData["success"] = "Product created succesfully";
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
            
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Product? prod = _repositoryWork.ProductRepository.GetFirstOrDefault(x=> x.Id == id);

            if (prod == null)
            {
                return NotFound();
            }
            
            return View(prod);
        }

        [HttpPost]
        public IActionResult Edit(Product prod)
        {
            if (ModelState.IsValid)
            {
                _repositoryWork.ProductRepository.Update(prod);
                _repositoryWork.Save();

                TempData["success"] = "Product updated succesfully";
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

            Product? prod = _repositoryWork.ProductRepository.GetFirstOrDefault(x => x.Id == id);

            if (prod == null)
            {
                return NotFound();
            }

            return View(prod);
        }

        [HttpPost]
        public IActionResult Delete(Product prod)
        {
            _repositoryWork.ProductRepository.Remove(prod);
            _repositoryWork.Save();
            TempData["success"] = "Product deleted succesfully";
            return RedirectToAction("Index");
        }
    }
}
