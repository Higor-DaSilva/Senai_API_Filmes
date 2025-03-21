﻿using api_filmes_senai.Domains;
using api_filmes_senai.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api_filmes_senai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    public class GeneroController : ControllerBase
    {
        private readonly IGeneroRepository _generoRepository;
        private object _generosRepository;

        public GeneroController(IGeneroRepository generoRepository)
        {
            _generoRepository = generoRepository;
        }

        /// <summary>
        /// Endpoint Listar os Generos
        /// </summary>
        /// <param name="id">Id do Genero Buscado</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_generoRepository.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint para Cadastar um Genero
        /// </summary>
        /// <param name="id">Id do Genero Buscado</param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public IActionResult Post(Genero novoGenero)
        {
            try
            {
                _generoRepository.Cadastrar(novoGenero);

                return Created();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        ///<Sumary>
        ///Endpoint para buscar um Gênero pelo seu ID
        /// </Sumary>
        /// <param name ="id">Id do GÊnero</param>
        /// <returns>Gênero Buscado</returns>

        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Genero generoBuscado = _generoRepository.BuscarPorId(id);

                return Ok(generoBuscado);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint para Deletar um Genero
        /// </summary>
        /// <param name="id">Id do Genero Buscado</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _generoRepository.Deletar(id);

                return NoContent();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Endpoint para Atualizar um Genero
        /// </summary>
        /// <param name="id">Id do Genero Buscado</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Genero genero)
        {
            try
            {
                _generoRepository.Atualizar(id, genero);

                return NoContent() ;
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

    }
}
