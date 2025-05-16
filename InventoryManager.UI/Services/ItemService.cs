using InventoryManager.UI.Models;
using System.Net.Http.Json;

namespace InventoryManager.UI.Services
{
    public class ItemService
    {
        public readonly HttpClient _httpClient;
        public ItemService(HttpClient httpClient) 
        {  
            _httpClient = httpClient; 
        }   
        
        public  async Task<List<ItemDto>> GetItemsAsync() 
        {
            var response = await _httpClient.GetFromJsonAsync<List<ItemDto>>("api/item");
            return response ?? new List<ItemDto>();
        }
    }
}
