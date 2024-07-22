
namespace MultiShop.WebUI.Services.StatisticServices.CatalogStatisticServices
{
    public class CatalogStatisticService : ICatalogStatisticService
    {
        private readonly HttpClient _httpClient;

        public CatalogStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<long> GetBrandCount()
        {
            var responseMessage = await _httpClient.GetAsync("statistics/GetBrandCount");
            var value = await responseMessage.Content.ReadFromJsonAsync<long>();
            return value;
        }

        public Task<long> GetCategoryCount()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetMaxPriceProductName()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetMinPriceProductName()
        {
            throw new NotImplementedException();
        }

        public Task<decimal> GetProductAvgPrice()
        {
            throw new NotImplementedException();
        }

        public Task<long> GetProductCount()
        {
            throw new NotImplementedException();
        }
    }
}
