using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemForm.Infra
{
    public class RepositorioBaseConexaoDados
    {
        //TODO: Propriedade deve estar preenchida na inicialização do container
        protected readonly string connectionString = "Server=localhost\\SQL2022;Database=TREINAMENTO;Trusted_Connection=True;";
    }
}


    

