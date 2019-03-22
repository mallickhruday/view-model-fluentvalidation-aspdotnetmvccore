using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SimonGilbert.Blog.Models;
using SimonGilbert.Blog.ViewModels;

namespace SimonGilbert.Blog.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(UserAccountViewModel viewModel)
        {
            if (this.ModelState.IsValid)
            {
                return RedirectToAction("Success", "Home", viewModel);
            }
            return View();
        }

        [HttpGet]
        public IActionResult Success(UserAccountViewModel viewModel)
        {
            return View(viewModel);
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
