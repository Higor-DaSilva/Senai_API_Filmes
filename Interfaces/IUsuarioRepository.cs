using api_filmes_senai.Domains;
using api_filmes_senai.Repositories;

namespace api_filmes_senai.Interfaces
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuario novoUsuario);

        Usuario BuscarPorId(Guid id);

        Usuario BuscarPorEmailESenha(string email, string senha);
        
    }
}
