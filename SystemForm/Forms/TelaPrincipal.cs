using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SystemForm.Entidades;
using SystemForm.Infra.Data.Sql.Repository;
using SystemForm.ModeloInterface;

namespace SystemForm
{
    public partial class frmTelaPrincipal : Form
    {
        private readonly ICadastroFuncionario _cadastroFuncionario;
        public frmTelaPrincipal()
        {
            _cadastroFuncionario = Program.ServiceProvider.GetRequiredService<ICadastroFuncionario>();

            InitializeComponent();
        }
        private void btnNovo_Click(object sender, EventArgs e)
        {
            new CadastroFuncionario().Show();
        }
        private void TelaPrincipal_Load(object sender, EventArgs e)
        {
            ConfigureGridFunc();
            var funcionarios = _cadastroFuncionario.ObterTodos();
            dgvFuncionario.DataSource = funcionarios.ToList();
        }
        private void ConfigureGridFunc()
        {
            dgvFuncionario.DataSource = new List<Funcionario>();
            dgvFuncionario.ReadOnly = true;
            dgvFuncionario.Columns["Id"].Visible = false;
            dgvFuncionario.Columns["Nome"].Visible = true;
            dgvFuncionario.Columns["Email"].Visible = true;
            dgvFuncionario.Columns["Salario"].Visible = true;
            dgvFuncionario.Columns["Sexo"].Visible = true;
            dgvFuncionario.Columns["TipoContrato"].Visible = true;
            dgvFuncionario.Columns["TipoContrato"].HeaderText = "Tipo de Contrato";
            dgvFuncionario.Columns["DataCadastro"].Visible = false;
            dgvFuncionario.Columns["DataCadastro"].HeaderText = "Data do Cadastro";
            dgvFuncionario.Columns["DataAtualizacao"].Visible = false;
            dgvFuncionario.Columns["DataAtualizacao"].HeaderText = "Data de Atualização";
            dgvFuncionario.AutoResizeColumns();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
                     
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
           
        }
        private void mnuNovo_Click(object sender, EventArgs e)
        {
            new CadastroFuncionario().Show();
        }
        private void mnuSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void mnuSobre_Click(object sender, EventArgs e)
        {
            
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {

        }
    }
}
