using SystemForm.Entidades;
using SystemForm.ModeloInterface;
using System;
using System.Windows.Forms;
using SystemForm;
using System.Drawing;

namespace SystemForm
{
    public partial class FrmLogin : Form
    {
        private readonly IRepositorioUsuario _repositorioUsuario;

        public FrmLogin(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
            InitializeComponent();
        }


        private void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                string loginUsuario = txtLogin.Text;
                string senha = txtSenha.Text;
                bool validacao = string.IsNullOrEmpty(loginUsuario) || string.IsNullOrEmpty(senha);
                if (validacao)

                {
                    MessageBox.Show($"O preenchimento dos campos é obrigatório. \n Tente novamente!", "Erro");
                    return;

                }
                var usuario = _repositorioUsuario.ObterPeloLoginSenha(loginUsuario, senha);

                if (usuario is null)
                {
                    MessageBox.Show($"Usuário ou senha incorretos. \n Tente novamente!", "Erro");
                    return;
                }

                new frmTelaPrincipal().Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Falha ao buscar usuário. Retorno: {ex.Message}", "Falha");
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

    }
}
