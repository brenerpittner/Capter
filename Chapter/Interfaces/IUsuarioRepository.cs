using Chapter.Models;

//todos os métodos de interface são abstratos (somente )

namespace Chapter.Interfaces
{
    public interface IUsuarioRepository
    {
        List<Usuario> Listar();
        Usuario BuscarPorId(int id);
        void Cadastrar(Usuario usuario);
        void Atualizar(int id, Usuario usuario);
        void Deletar(int id);
        Usuario Login(string email, string senha);
    }
}
