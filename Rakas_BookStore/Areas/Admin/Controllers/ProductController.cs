using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Rakas_BookStore.DataAccess;
using Rakas_BookStore.DataAccess.Interfaces;
using Rakas_BookStore.Models;
using Rakas_BookStore.Models.ViewModels;

namespace Rakas_BookStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {

        private readonly IRepositoryWork _repositoryWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IRepositoryWork repositoryWork, IWebHostEnvironment webHostEnvironment)
        {
            _repositoryWork = repositoryWork;
            _webHostEnvironment = webHostEnvironment; //DI'ed automatically by default in ASP.NET
        }

        public IActionResult Index()
        {
            List<Product> productList = _repositoryWork.ProductRepository.GetAll().ToList();
            return View(productList);
        }

        public IActionResult Upsert(int? id)
        {
            ProductVM productVM = new ProductVM
            {
                CategoryList = _repositoryWork.CategoryRepository
                .GetAll().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }),
                Product = (id == null || id == 0) ? new Product() : _repositoryWork.ProductRepository.GetFirstOrDefault(x => x.Id == id)
            };
            return View(productVM);
        }


        [HttpPost]
        public IActionResult Upsert(ProductVM prod, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath; //Get the wwwRoot path
                if (file != null)
                {
                    string filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images\product");

                    using (var fileStream = new FileStream(Path.Combine(productPath, filename), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    prod.Product.ImageUrl = @"\images\product\" + filename;
                }

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
