using Microsoft.AspNetCore.Mvc;
using Rakas_BookStore.DataAccess.Interfaces;
using Rakas_BookStore.Models;

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
    }
}
