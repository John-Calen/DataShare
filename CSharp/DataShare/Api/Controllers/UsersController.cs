using Business;
using Microsoft.AspNetCore.Mvc;
using Models.Users;

namespace Api.Controllers
{
    [ApiController]
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
    }
}
