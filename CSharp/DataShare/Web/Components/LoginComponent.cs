using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Models;
using Models.Users;
using System.Net.Http.Json;
using System.Text.Json;
using Web.Auth;

namespace Web.Components
{
    public class LoginComponent: ComponentBase
    {
        [Inject]
        public HttpClient HttpClient { get; set; } = default!;
        [Inject]
        public ILocalStorageService LocalStorage { get; set; } = default!;
        [Inject]
        public IAuthenticationStateProvider AuthStateProvider { get; set; } = default!;
        
        
        
        
        
        
        protected async Task Login(AuthUserModel model)
        {
            var result = await HttpClient.PostAsJsonAsync("Users/Auth", model);
            var content = await result.Content.ReadAsStringAsync();
            var authToken = JsonSerializer.Deserialize<AuthToken>(content)!;

            await AuthStateProvider.Authorize(authToken.JwtAccess);
        }
    }
}
