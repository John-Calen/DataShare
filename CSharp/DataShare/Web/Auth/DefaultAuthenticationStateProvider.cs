using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Security.Claims;
using Tools.Helpers;
using Web.Helpers;

namespace Web.Auth
{
    public class DefaultAuthenticationStateProvider : AuthenticationStateProvider, IAuthenticationStateProvider
    {
        private readonly ILocalStorageService localStorage;
        private readonly HttpClient httpClient;

        private const string TOKEN = "token";





        public DefaultAuthenticationStateProvider(ILocalStorageService localStorage, HttpClient httpClient)
        {
            this.localStorage = localStorage;
            this.httpClient = httpClient;
        }






        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            AuthenticationState state;
            
            switch (await GetAuthStateAsync())
            {
                case AuthState.ANONYMOUS:
                {
                    state = GetAnonymousState();
                    
                    break;
                }

                case AuthState.EXPIRED:
                {
                    await UseAnonymousAsync();
                    state = GetAnonymousState();
                    
                    break;
                }

                case AuthState.AUTHORIZED:
                {
                    state = await GetAuthorizedStateAsync();
                    
                    break;
                }

                default:
                    throw new Exception("Unexpected");
            }

            NotifyAuthenticationStateChanged(Task.FromResult(state));

            return state;
        }

        private AuthenticationState GetAnonymousState()
        {
            var identity = new ClaimsIdentity();
            var user = new ClaimsPrincipal(identity);
            var state = new AuthenticationState(user);

            return state;
        }

        private async Task UseAnonymousAsync()
        {
            if (httpClient.DefaultRequestHeaders.Authorization is not null)
                httpClient.DefaultRequestHeaders.Authorization = null;

            var token = await localStorage.GetItemAsStringAsync(TOKEN);
            if (token is not null)
                await localStorage.RemoveItemAsync(TOKEN);
        }

        public async Task<AuthenticationState> Authorize(string token)
        {
            await localStorage.SetItemAsync(TOKEN, token);
            TryAddAuthorizationHeader(token);

            return await GetAuthenticationStateAsync();
        }

        private bool TryAddAuthorizationHeader(string token)
        {
            if (httpClient.DefaultRequestHeaders.Authorization is null)
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Replace("\"", ""));
                return true;
            }

            else
                return false;
        }

        public async Task<AuthenticationState> LogOut()
        {
            await UseAnonymousAsync();
            return await GetAuthenticationStateAsync();
        }

        private async Task<AuthenticationState> GetAuthorizedStateAsync()
        {
            var token = (await localStorage.GetItemAsStringAsync(TOKEN))!;
            var identity = new ClaimsIdentity(JwtHelper.ParseClaimsFromJwt(token), "jwt");
            var user = new ClaimsPrincipal(identity);
            var state = new AuthenticationState(user);

            return state;
        }

        private async Task<AuthState> GetAuthStateAsync()
        {
            var token = await localStorage.GetItemAsStringAsync(TOKEN);
            if (string.IsNullOrEmpty(token))
                return AuthState.ANONYMOUS;

            var identity = new ClaimsIdentity(JwtHelper.ParseClaimsFromJwt(token), "jwt");
            var user = new ClaimsPrincipal(identity);

            var expiration = user.Claims.SingleOrDefault((c) => c.Type is "exp");

            if (expiration is not null)
            {
                var utcSeconds = long.Parse(expiration.Value);
                var dateTime = DateTimeHelper.ConvertFromUnixTimestamp(utcSeconds);

                if (dateTime <= DateTime.UtcNow)
                    return AuthState.EXPIRED;
            }

            TryAddAuthorizationHeader(token);

            return AuthState.AUTHORIZED;
        }
    }
}
