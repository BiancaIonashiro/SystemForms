using System.Collections.Generic;
using SystemForm.Entidades;

namespace SystemForm.ModeloInterface
{
    public interface ICadastroFuncionario
    {
        Funcionario ObterPeloId(int Id);
        IEnumerable<Funcionario> ObterTodos();
    }
}

