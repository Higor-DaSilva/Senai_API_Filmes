﻿using api_filmes_senai.Context;
using api_filmes_senai.Domains;
using api_filmes_senai.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api_filmes_senai.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private readonly Filmes_Context _context;
        

        public FilmeRepository(Filmes_Context context)
        {
                _context = context;
        }

        public void Atualizar(Guid id, Filme filme)
        {
            Filme filmeBuscado = _context.Filmes.Find(id)!;

            if (filmeBuscado != null)
            {
                filmeBuscado.Titulo = filme.Titulo;
                filmeBuscado.IdGenero = filme.IdGenero;
            }
            _context.SaveChanges();
        }

        public Filme BuscarPorId(Guid id)
        {
            try
            {
                Filme filmeBuscado = _context.Filmes.Find(id)!;

                return filmeBuscado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Filme novoFilme)
        {
            try
            {
                _context.Filmes.Add(novoFilme);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                Filme filmeBuscado = _context.Filmes.Find(id)!;

                if (filmeBuscado != null)
                {
                    _context.Filmes.Remove(filmeBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Filme> Listar()
        {
            List<Filme> listaFilme = _context.Filmes.ToList();
            return listaFilme;
        }

        public List<Filme> ListarPorGenero(Guid idGenero)
        {
            try
            {
                List<Filme> listaDeFilmes = _context.Filmes
                    .Include(g => g.Genero)
                    .Where(f => f.IdGenero == idGenero)
                    .ToList();

                return listaDeFilmes;
            }
            catch (Exception)
            {

                throw;
            }
        }

        
    }
}
