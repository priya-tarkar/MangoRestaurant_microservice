using Mango.Web.Models;
using Mango.Web.Models.Dto;
using Mango.Web.Services.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Mango.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductServices _productServices;

        public ProductController(IProductServices productServices)
        {
            _productServices= productServices;

        }

        public async Task<IActionResult> ProductIndex()
        {
            List<ProductDto> list = new();
			var accessToken = await HttpContext.GetTokenAsync("access_token");
			var response = await _productServices.GetAllProductAsync<ResponseDto>(accessToken);
            if(response != null && response.IsSuccess) {
                list = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response.Result));
            }

            return View(list);
        }
        public async Task<IActionResult> CreateProduct()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductDto model)
        {
            if (ModelState.IsValid) {
				var accesstoken = await HttpContext.GetTokenAsync("access_token");
				var response = await _productServices.CreateProductAsync<ResponseDto>(model, accesstoken);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction("ProductIndex");
                }
            }

            return View(model);
        }
        public async Task<IActionResult> EditProduct(int id)
        {
			var accesstoken = await HttpContext.GetTokenAsync("access_token");

			var response = await _productServices.GetProductByIDAsync<ResponseDto>(id, accesstoken);
            if (response != null && response.IsSuccess)
            {
                ProductDto list = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
                return View(list);
            }
            return NotFound();


            
        }

        [HttpPost]
        public async Task<IActionResult> EditProduct(ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
				var accesstoken = await HttpContext.GetTokenAsync("access_token");
				var response = await _productServices.UpdateProductAsync<ResponseDto>(productDto, accesstoken);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction("ProductIndex");
                }
            }

            return View();
        }
        public async Task<IActionResult> DeleteProduct(int id)
        {
			var accesstoken = await HttpContext.GetTokenAsync("access_token");
			var response = await _productServices.GetProductByIDAsync<ResponseDto>(id, accesstoken);
            if ( response.IsSuccess)
            {
                ProductDto list = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
                return View(list);
            }
            Console.WriteLine("hello");
            return NotFound();

        }
        [HttpPost]
        public async Task<IActionResult> DeleteProduct(ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
				var accesstoken = await HttpContext.GetTokenAsync("access_token");
				var response = await _productServices.DeleteProductAsync<ResponseDto>(productDto.ProductId, accesstoken);
                if ( response.IsSuccess)
                {
                    return RedirectToAction("ProductIndex");
                }
            }

            return View();

        }


    }
}
