using Mango.Web.Models;
using Mango.Web.Services.IServices;
using static Mango.Web.SD;

namespace Mango.Web.Services
{
    public class ProductService : BaseService, IProductServices
    {
        private readonly IHttpClientFactory _clientFactory;

        public ProductService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;

        }

        public async Task<T> CreateProductAsync<T>(ProductDto productDto, string Token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = productDto,
                Url = SD.ProductAPIBase + "/api/ProductAPI",
                AccessToken = Token

			});
        }

        public async Task<T> DeleteProductAsync<T>(int id, string Token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.DELETE,
               
                Url = SD.ProductAPIBase + "/api/ProductAPI/" + id,
                AccessToken = Token

			});
        }

        public async  Task<T> GetAllProductAsync<T>(string Token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,

                Url = SD.ProductAPIBase + "/api/ProductAPI",
                AccessToken = Token

            });
        }

        public async Task<T> GetProductByIDAsync<T>(int id, string Token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,

                Url = SD.ProductAPIBase + "/api/ProductAPI/" + id,
                AccessToken = Token

            });
        }

        public async Task<T> UpdateProductAsync<T>(ProductDto productDto, string Token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = productDto,
                Url = SD.ProductAPIBase + "/api/ProductAPI",
                AccessToken = Token

			});
        }
    }
}
