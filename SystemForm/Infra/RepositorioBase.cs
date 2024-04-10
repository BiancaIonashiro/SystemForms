using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemForm.Infra
{
    public class RepositorioBase
    {
        //TODO: Propriedade deve estar preenchida na inicialização do container
        protected readonly string connectionString = "Server=localhost\\SQL2022;Database=crud_db;Trusted_Connection=True;";
    }
}


    

