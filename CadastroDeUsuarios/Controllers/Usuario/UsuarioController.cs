using CadastroDeUsuarios.Dtos.Usuario;
using CadastroDeUsuarios.Services;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDeUsuarios.Controllers.Usuario;
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
    private readonly UsuarioService _usuarioService;

    public UsuarioController(UsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpPost] 
    public async Task<ActionResult<int>> Post([FromBody] UsuarioRequest usuario)
    {
        var id = await _usuarioService.CreateUsuarioAsync(usuario);
        return CreatedAtAction(nameof(Post), new { id }, id);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UsuarioResponse>>> Get()
    {
        var usuarios = await _usuarioService.GetAllUsuariosAsync();
        return Ok(usuarios);
    }
}

