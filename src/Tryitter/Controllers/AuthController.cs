using Microsoft.AspNetCore.Mvc;

namespace Tryitter.Controllers;

[ApiController]
[Route("[controller]")]

public class AuthController : ControllerBase
{
    private readonly IUserRepository _repository;
    public AuthController(IUserRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    [Route("/login")]
    public async Task<ActionResult<UserViewModel>> Autenticate([FromBody] UserLogin user)
    {
        UserViewModel userViewModel = new();
        try
        {
            userViewModel.User = await _repository.LoginAsync(user);

            if (userViewModel.User == null)
            {
                return NotFound("Usuário não encontrado!");
            }

            userViewModel.Token = new TokenGenerator().Generate(userViewModel.User);
            userViewModel.User.Password = string.Empty;
        }
        catch (Exception err)
        {
            return BadRequest(err.Message);
        }
        return userViewModel;
    }
}