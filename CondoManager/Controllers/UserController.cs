using Microsoft.AspNetCore.Mvc;
using CondoManager.Models;
using CondoManager.Models.DTO;
using CondoManager.Services;

namespace CondoManager.Controllers
{
    [ApiController]
    [Route("v1/api/[controller]")]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Authenticate(
            [FromServices]IUserRepository userRepository,
            UserDTO user)
        {
            var userFound = await userRepository.GetUserByUserName(user.UserName);
            if (userFound == null)
            {
                return NotFound();
            }
            if (user.Password != userFound.Password)
            {
                return BadRequest("Wrong Password");
            }

            var token = TokenService.GenerateToken(userFound);
            
            return new 
            {
                user = userFound.UserName,
                role = userFound.Role,
                token = token
            };
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<dynamic>> Registrate(
            [FromServices]IUserRepository userRepository,
            [FromServices]IUnitOfWork uow,
            User user)
        {
            try
            {
                await userRepository.Register(user);
                uow.Commit();
            }
            catch (Exception err)
            {
                uow.RollBack();
                return BadRequest(err);
            }
            return NoContent();
        }
    }
}