using ATM.Models;
using ATM.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ATM.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SaqueService _saqueService;
        private readonly CartaoService _cartaoService;

        public HomeController(ILogger<HomeController> logger, SaqueService saqueService, CartaoService cartaoService)
        {
            _logger = logger;
            _saqueService = saqueService;
            _cartaoService = cartaoService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Saque()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult CreateSaqueForm(Saque model)
        {
            RedirectToActionResult result = (RedirectToActionResult)_saqueService.ValidarSaque(model).Result;

            return View(result.ActionName, result.ControllerName);
        }

        public IActionResult CreateCartaoForm(Cartao model)
        {
            _cartaoService.Add(model);

            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
