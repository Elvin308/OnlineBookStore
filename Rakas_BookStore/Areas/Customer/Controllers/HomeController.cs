using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Rakas_BookStore.DataAccess;
using Rakas_BookStore.DataAccess.Interfaces;
using Rakas_BookStore.Models;

namespace Rakas_BookStore.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly IRepositoryWork _repositoryWork;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IRepositoryWork repositoryWork)
        {
            _logger = logger;
            _repositoryWork = repositoryWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> productList = _repositoryWork.ProductRepository.GetAll("Category");
            return View(productList);
        }

        public IActionResult Details(int id)
        {
            Product productItem = _repositoryWork.ProductRepository.GetFirstOrDefault(x => x.Id == id, "Category");
            return View(productItem);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
