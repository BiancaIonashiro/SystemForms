using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
using SystemForm.Infra.Data.Sql.Repository;
using SystemForm.ModeloInterface;

namespace SystemForm
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();

            var loginForm = ServiceProvider.GetRequiredService<FrmLogin>();
            Application.Run(loginForm);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            //Registrar a connectionString
            //services.AddSingleton(sqlSettings);
            services.AddTransient<ICadastroFuncionario, RepositorioFuncionario>();
            services.AddTransient<IRepositorioUsuario, RepositorioUsuario>();
            services.AddTransient<FrmLogin>();
            services.AddTransient<frmTelaPrincipal>();
            services.AddTransient<CadastroFuncionario>();
        }
    }
}
