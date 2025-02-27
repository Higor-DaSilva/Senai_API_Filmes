using api_filmes_senai.Interfaces;
using api_filmes_senai.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace api_filmes_senai.Controllers
{
    [Route("api/[controllador]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : Controller
    {
       private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioController(UsuarioRepository usuarioRepository) 
        {
            _usuarioRepository = usuarioRepository;
        }
        [HttpGet]
        public IActionResult Post(UsuarioRepository usuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(usuario);

                return StatusCode(201, usuario);
            }
            catch (Exception error)
            {

               return BadRequest(error.Message);
            }
        }
    }
}
