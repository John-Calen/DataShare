using Business.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Users;
using System.Security.Claims;

namespace Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;





        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }






        [HttpGet]
        public async Task<IEnumerable<GetUserModel>> Get()
        {
            return await userService.GetAsync();
        }

        [HttpGet("{id}")]
        public async Task<GetUserModel?> Get([FromRoute] long id)
        {
            return await userService.GetAsync(id);
        }

        [HttpPost]
        public async Task<GetUserModel> Create([FromBody] CreateUserModel model)
        {
            return await userService.CreateAsync(model);
        }

        [HttpPut]
        public async Task<GetUserModel> Update([FromBody] UpdateUserModel model)
        {
            return await userService.UpdateAsync(model);
        }

        [HttpDelete("{id}")]
        public async Task Delete([FromRoute] long id) 
        {
            await userService.DeleteAsync(id);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<GetUserModel> Register([FromBody] CreateUserModel model)
        {
            return await userService.CreateAsync(model);
        }

        [AllowAnonymous]
        [HttpPost("Auth")]
        public async Task<AuthToken> Authorize([FromBody] AuthUserModel model, [FromServices] IJwtTokenService jwtTokenService)
        {
            var user = await userService.FindAsync(model.Name, model.Password) 
                ?? throw new Exception("Name or password is not correct");

            var accessToken = jwtTokenService.GenerateToken
            (
                new Claim[]
                {
                    new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new(ClaimTypes.Name, user.Name)
                },
                DateTime.Now.AddMinutes(15)
            );

            var refreshToken = jwtTokenService.GenerateToken
            (
                new Claim[]
                {
                    new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new(ClaimTypes.Name, user.Name)
                },
                DateTime.Now.AddMinutes(25)
            );

            return new AuthToken
            {
                JwtAccess = accessToken,
                JwtRefresh = refreshToken
            };
        }
    }
}
