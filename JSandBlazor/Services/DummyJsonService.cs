namespace JSandBlazor.services
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public class DummyJsonService
    {
        private readonly HttpClient _httpClient;

        public DummyJsonService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<ProductResponse>("https://dummyjson.com/products");
            return response.Products;
        }
    }

    public class ProductResponse
    {
        public List<Product> Products { get; set; }
    }

    public class Product
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }

}
