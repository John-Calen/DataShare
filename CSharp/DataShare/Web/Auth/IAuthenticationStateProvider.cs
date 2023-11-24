using Microsoft.AspNetCore.Components.Authorization;

namespace Web.Auth
{
    public interface IAuthenticationStateProvider
    {
        public abstract event AuthenticationStateChangedHandler? AuthenticationStateChanged;
        
        
        
        
        
        
        public abstract Task<AuthenticationState> GetAuthenticationStateAsync();
        public abstract Task<AuthenticationState> Authorize(string token);
        public abstract Task<AuthenticationState> LogOut();
    }
}
