using Models;
using System.Net.Http.Json;

namespace Web.Services
{
    public class ElementService: IElementService
    {
        private readonly HttpClient httpClient;





        public ElementService(HttpClient httpClient) 
        {
            this.httpClient = httpClient;
        }






        public async Task<IEnumerable<ElementModel>?> GetAsync()
        {
            var elements = await httpClient.GetFromJsonAsync<IEnumerable<ElementModel>>("Elements");
            return elements;
        }
    }
}
