using Mango.Web.Models;
using Mango.Web.Models.Dto;
using Mango.Web.Services.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Mango.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductServices _productServices;

        public HomeController(ILogger<HomeController> logger,IProductServices productServices)
        {
            _logger = logger;
            _productServices= productServices;
        }

        public async Task<IActionResult> Index()
        {
            List<ProductDto> list = new();
           
            var response = await _productServices.GetAllProductAsync<ResponseDto>("");
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response.Result));
            }

            return View(list);


           
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            ProductDto list = new();

            var response = await _productServices.GetProductByIDAsync<ResponseDto>(id,"");
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
            }

            return View(list);



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


		[Authorize]
		public async Task<IActionResult> Login()
		{
            

			return RedirectToAction(nameof(Index));
		}

		public IActionResult Logout()
		{
			return SignOut("Cookies", "oidc");
		}
	}
}