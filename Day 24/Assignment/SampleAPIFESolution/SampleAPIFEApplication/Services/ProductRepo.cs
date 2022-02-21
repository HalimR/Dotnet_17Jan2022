using Newtonsoft.Json;
using SampleAPIFEApplication.Models;
using System.Net.Http.Headers;
using System.Text;

namespace SampleAPIFEApplication.Services
{
    public class ProductRepo :IRepo<int, Product>
    {
        private readonly HttpClient _httpClient;
        private string _token;
        public ProductRepo()
        {
            _httpClient = new HttpClient();
        }
        public void GetToken(string token)
        {
            _token = token;
        }

        public async Task<Product> Insert(Product item)
        {
            //authorize with token
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            using (_httpClient)
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
                using (var response = await _httpClient.PostAsJsonAsync("http://localhost:5208/api/Product", content))
                //using (var response = await _httpClient.PostAsJsonAsync("http://localhost:5208/api/Product", item))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseText = await response.Content.ReadAsStringAsync();
                        var products = JsonConvert.DeserializeObject<Product>(responseText);
                        return products;
                    }
                }
            }
            return null;
        }

        public async Task<Product> Delete(int key)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            using (_httpClient)
            {
                using (var response = await _httpClient.DeleteAsync("http://localhost:5208/api/Product?id=" + key))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseText = await response.Content.ReadAsStringAsync();
                        var product = JsonConvert.DeserializeObject<Product>(responseText);
                        return product;
                    }
                }
            }
            return null;
        }

        public async Task<Product> Get(int key)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            using (_httpClient)
            {
                using (var response = await _httpClient.GetAsync("http://localhost:5208/api/Product/GetProduct?id=" + key))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseText = await response.Content.ReadAsStringAsync();
                        var product = JsonConvert.DeserializeObject<Product>(responseText);
                        return product;
                    }
                }
            }
            return null;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            using (_httpClient)
            {
                using (var response = await _httpClient.GetAsync("http://localhost:5208/api/Product"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseText = await response.Content.ReadAsStringAsync();
                        var products = JsonConvert.DeserializeObject<List<Product>>(responseText);
                        return products.ToList();
                    }
                }
            }
            return null;
        }

        public async Task<Product> Update(Product item)
        {
            //_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            using (_httpClient)
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
                using (var response = await _httpClient.PutAsync("http://localhost:5208/api/Product?id=" + item.Id, content))
                //using (var response = await _httpClient.PutAsJsonAsync<Product>("http://localhost:5208/api/Product?id=" + item.Id, item))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseText = await response.Content.ReadAsStringAsync();
                        var product = JsonConvert.DeserializeObject<Product>(responseText);
                        return product;
                    }
                }
            }
            return null;
        }
    }
}
