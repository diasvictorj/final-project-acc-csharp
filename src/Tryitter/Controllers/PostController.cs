using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Tryitter.Controllers;

[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase
{
    private readonly IPostRepository _repository;
    private readonly IUserRepository _userRepository;
    public PostController(IPostRepository repository, IUserRepository userRepository)
    {
        _repository = repository;
        _userRepository = userRepository;
    }
    [HttpGet]
    public async Task<ActionResult<Post>> GetPosts()
    {
        var posts = await _repository.GetPostsAsync();
        return Ok(posts);
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Post>> Create([FromBody] string message)
    {
        try
        {
            var id = User.Identity.Name;
            var user = await _userRepository.GetByIdAsync(int.Parse(id));
            var newPost = await _repository.CreateAsync(message, user);
            return Ok(newPost);
        }
        catch
        {
            return BadRequest("Usuário não existe!");
        }
    }

    [HttpPut]
    [Authorize]
    public async Task<ActionResult<string>> Update([FromBody] string message, int postId)
    {
        try
        {
            var id = User.Identity.Name;
            var post = await _repository.GetPostByIdAsync(postId);
            
            if (id != post.UserId.ToString()) {
                return Unauthorized("Não é possivel atualizar o Post de outra pessoa!");
            }

            string result = await _repository.UpdateAsync(message, postId);

            return Ok(result);
        }
        catch (Exception)
        {
            return BadRequest("Não foi possivel atualizar o Post!");
        }
    }

    [HttpDelete]
    [Authorize]
    public async Task<ActionResult> Delete(int postId)
    {
        try
        {
            var id = User.Identity.Name;
            var post = await _repository.GetPostByIdAsync(postId);

            if (id != post.UserId.ToString())
            {
                return Unauthorized("Não é possivel excluir o Post de outra pessoa!");
            }

            _repository.DeletePostAsync(post);

            return NoContent();
        }
        catch(Exception)
        {
            return BadRequest("Não foi possivel excluir Post");
        }
    }
}
