using System.Collections.Generic;
using SystemForm.Entidades;

namespace SystemForm.ModeloInterface

{
    public interface IRepositorioUsuario
    {
        Usuario ObterPeloLogin(string login);
        IEnumerable<Usuario> ObterTodos();
        Usuario ObterPeloLoginSenha(string login, string senha);
    }
}
