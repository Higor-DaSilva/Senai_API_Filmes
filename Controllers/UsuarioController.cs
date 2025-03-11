using api_filmes_senai.Domains;
using api_filmes_senai.Interfaces;
using api_filmes_senai.Repositories;
using api_filmes_senai.DTO;
using Microsoft.AspNetCore.Mvc;

namespace api_filmes_senai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        /// <summary>
        /// Endpoint Cadastrar um Usuario
        /// </summary>
        /// <param name="id">Id do Genero Buscado</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Usuario usuario)
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

        /// <summary>
        /// Endpoint Buscar um Usuario Por ID
        /// </summary>
        /// <param name="id">Id do Genero Buscado</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetByld(Guid id)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorId(id);   

                if (usuarioBuscado != null)
                {
                    return Ok(usuarioBuscado); 
                }
                return null!;

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        //[HttpGet("BuscarPorEmailESenha")]
        //public IActionResult GetActionResult(string email, string senha)
        //{
        //    try
        //    {
        //        Usuario usuarioBuscado = _usuarioRepository.BuscarPorEmailESenha(email, senha);

        //        if (usuarioBuscado != null)
        //        {
        //            return Ok(usuarioBuscado);
        //        }
        //        return null!;
        //    }
        //    catch (Exception e)
        //    {

        //        return BadRequest (e.Message);
        //    }
        //}
        
    }
}
