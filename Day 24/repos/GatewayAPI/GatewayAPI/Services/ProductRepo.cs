using GatewayAPI.Models;
using Newtonsoft.Json;

namespace GatewayAPI.Services
{
    public class ProductRepo : IRepo<int, ProductDTO>
    {
        private readonly HttpClient _httpClient;
        public ProductRepo()
        {
            _httpClient = new HttpClient();
        }
        public async Task<ProductDTO> Insert(ProductDTO item)
        {
            using (_httpClient)
            {
                //StringContent content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
                using (var response = await _httpClient.PostAsJsonAsync("http://localhost:5053/api/Product", item))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseText = await response.Content.ReadAsStringAsync();
                        var products = JsonConvert.DeserializeObject<ProductDTO>(responseText);
                        return products;
                    }
                }
            }
            return null;
        }

        public async Task<ProductDTO> Delete(int key)
        {
            using (_httpClient)
            {
                using (var response = await _httpClient.DeleteAsync("http://localhost:5053/api/Product?id=" + key))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseText = await response.Content.ReadAsStringAsync();
                        var product = JsonConvert.DeserializeObject<ProductDTO>(responseText);
                        return product;
                    }
                }
            }
            return null;
        }

        public async Task<ProductDTO> Get(int key)
        {
            using (_httpClient)
            {
                using (var response = await _httpClient.GetAsync("http://localhost:5053/api/Product/GetProduct?id=" + key))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseText = await response.Content.ReadAsStringAsync();
                        var product = JsonConvert.DeserializeObject<ProductDTO>(responseText);
                        return product;
                    }
                }
            }
            return null;
        }

        public async Task<IEnumerable<ProductDTO>> GetAll()
        {
            using (_httpClient)
            {
                using (var response = await _httpClient.GetAsync("http://localhost:5053/api/Product"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseText = await response.Content.ReadAsStringAsync();
                        var products = JsonConvert.DeserializeObject<List<ProductDTO>>(responseText);
                        return products.ToList();
                    }
                }
            }
            return null;
        }

        public async Task<ProductDTO> Update(ProductDTO item)
        {
            using (_httpClient)
            {
                // StringContent content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
                using (var response = await _httpClient.PutAsJsonAsync<ProductDTO>("http://localhost:5053/api/Product?id=" + item.Id, item))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseText = await response.Content.ReadAsStringAsync();
                        var product = JsonConvert.DeserializeObject<ProductDTO>(responseText);
                        return product;
                    }
                }
            }
            return null;
        }
    }
}
