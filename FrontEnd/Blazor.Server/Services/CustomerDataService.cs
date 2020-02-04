using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Blazor.Shared;
using Newtonsoft.Json;

namespace Blazor.Server.Services
{
    public class CustomerDataService: ICustomerDataService
    {
        private readonly HttpClient _httpClient;

        public CustomerDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PaginatedItemsViewModel<CustomerDTO>> GetAllCustomers()
        {
            var responseMessage = await _httpClient.GetAsync($"api/Customers");
            HandleResponseCode((int)responseMessage.StatusCode);

            var json = await responseMessage.Content.ReadAsStringAsync();
            return await Task.Run(() => JsonConvert.DeserializeObject<PaginatedItemsViewModel<CustomerDTO>>(json));
        }

        public async Task<CustomerDTO> GetCustomerDetails(Guid customerId)
        {
            var responseMessage = await _httpClient.GetAsync($"api/Customers/{customerId}");
            HandleResponseCode((int)responseMessage.StatusCode);

            var json = await responseMessage.Content.ReadAsStringAsync();
            return await Task.Run(() => Newtonsoft.Json.JsonConvert.DeserializeObject<CustomerDTO>(json));
        }

        public async Task<Guid> AddCustomer(CustomerDTO customer)
        {

            var serializedCustomer = JsonConvert.SerializeObject(customer);

            var response = await _httpClient.PostAsync($"api/Customers", new StringContent(serializedCustomer, Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return await Task.Run(() => JsonConvert.DeserializeObject<Guid>(json));
            }

            return Guid.Empty;
        }

        public async Task DeleteCustomer(Guid customerId)
        {
            await _httpClient.DeleteAsync($"api/Customer/{customerId}");
        }

        private void HandleResponseCode(int code)
        {
            switch (code)
            {
                case 200:
                case 201:
                    return;
                case 409:
                    throw new Exception(message: "Prato duplicado, nome repetido!");
                default:
                    throw new Exception(message: "Error no servidor!");
            }
        }
    }
}
