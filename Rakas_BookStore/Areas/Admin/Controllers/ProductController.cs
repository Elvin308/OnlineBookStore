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
            List<Product> productList = _repositoryWork.ProductRepository.GetAll("Category").ToList();
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

                    if (!string.IsNullOrEmpty(prod.Product.ImageUrl)) //We are replacing old with new
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, prod.Product.ImageUrl.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                            System.IO.File.Delete(oldImagePath);
                    }

                    using (var fileStream = new FileStream(Path.Combine(productPath, filename), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    prod.Product.ImageUrl = @"\images\product\" + filename;
                }
                else
                {
                    prod.Product.ImageUrl = "";
                }

                if (prod.Product.Id == 0) //New product / no ID yet
                {
                    _repositoryWork.ProductRepository.Add(prod.Product);
                }
                else //Updating product
                {
                    _repositoryWork.ProductRepository.Update(prod.Product);
                }
                    
                _repositoryWork.Save();

                TempData["success"] = "Product created succesfully";
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
            
        }

        #region Sudo API
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Product> productList = _repositoryWork.ProductRepository.GetAll("Category").ToList();
            return Json(new {data = productList});
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var prodDelete = _repositoryWork.ProductRepository.GetFirstOrDefault(x=>x.Id == id);
            if (prodDelete == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Error Deleting"
                });
            }

            var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, prodDelete.ImageUrl.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath))
                System.IO.File.Delete(oldImagePath);

            _repositoryWork.ProductRepository.Remove(prodDelete);
            _repositoryWork.Save();


            return Json(new
            {
                success = true,
                message = "Delete Successful"
            });
        }
        #endregion
    }
}
