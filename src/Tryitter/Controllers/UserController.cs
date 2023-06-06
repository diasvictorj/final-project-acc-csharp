using Microsoft.AspNetCore.Mvc;

namespace Tryitter.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _repository;
    public UserController(IUserRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    public async Task<ActionResult<User>> Create([FromBody] User user)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // var newUser = new User
            // {   
            //     Name = user.Name,
            //     Email = user.Email,
            //     Module = user.Module,

            // }
            await _repository.CreateAsync(user);

            return user;
        }
        catch (Exception err)
        {
            return StatusCode(err.GetHashCode(), "Ocorreu um erro ao tentar criar o Usuário");
        }
    }

    [HttpGet("{userId}")]
    public async Task<ActionResult<User>> GetById(int userId)
    {
        try
        {
            var user = await _repository.GetByIdAsync(userId);

            if (user == null) return NotFound();

            return user;
        }
        catch (Exception err)
        {
            return StatusCode(err.GetHashCode(), "Ocorreu um erro ao tentar encontrar o Usuário");
        }
    }
}
