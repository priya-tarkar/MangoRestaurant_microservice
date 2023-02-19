using Mango.Services.ProductAPI.Models;
using Mango.Services.ProductAPI.Models.Dto;
using Mango.Services.ProductAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.ProductAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]

    public class ProductAPIController : ControllerBase
    {
        protected ResponseDto _response;
        private IProductRepository _productRepository;

        public ProductAPIController(IProductRepository productRepository)
        {

            _productRepository = productRepository;

            //doubt
            this._response = new ResponseDto();

        }
       
        [HttpGet]
        
        public async Task<ResponseDto> Get()
        {
            try
            {
                IEnumerable<ProductDto> productDtos = await _productRepository.GetProducts();
                _response.Result = productDtos;

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.ToString() };
            }
            return _response;
        }
       
        [HttpGet]
        [Route("{id}")]
        public async Task<ResponseDto> Get(int id)
        {
            try
            {
                ProductDto productDto = await _productRepository.GetProductById(id);
                _response.Result = productDto;
            }

            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.ToString() };
            }
            return _response;

        }
        [Authorize]
        [HttpPost]

        public async Task<ResponseDto> Post(ProductDto productDto)
        {
            try
            {
                ProductDto productDto1 = await _productRepository.CreateUpdateProduct(productDto);
                _response.Result = productDto1;
            }

            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.ToString() };
            }
            return _response;


        }
        [Authorize]
        [HttpPut]

        public async Task<ResponseDto> Update(ProductDto productDto)
        {
            try
            {

                ProductDto productDto1 = await _productRepository.CreateUpdateProduct(productDto);
                _response.Result = productDto1;
            }

            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.ToString() };
            }
            return _response;


        }




        [Authorize(Roles ="Admin")]
        [HttpDelete]
        [Route("{id}")]
        public async Task<ResponseDto> Delete(int id)
        {
            try
            {
                bool b = await _productRepository.DeleteProduct(id);
                _response.Result = b;
            }

            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.ToString() };
            }
            return _response;

        }

    }
}
