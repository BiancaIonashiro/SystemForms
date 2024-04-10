using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using SystemForm.Entidades;
using SystemForm.ModeloInterface;

namespace SystemForm
{
    public partial class TelaPrincipal : Form
    {
        private readonly ICadastroFuncionario _cadastroFuncionario;
        public TelaPrincipal(ICadastroFuncionario cadastroFuncionario)
        {
            _cadastroFuncionario = cadastroFuncionario;


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
            dgvTabFunc.DataSource = funcionarios.ToList();
        }

        private void ConfigureGridFunc()
        {
            dgvTabFunc.DataSource = new List<Funcionario>();
            dgvTabFunc.ReadOnly = true;
            dgvTabFunc.Columns["Id"].Visible = true;
            dgvTabFunc.Columns["Nome"].Visible = true;
            dgvTabFunc.Columns["Email"].Visible = true;
            dgvTabFunc.Columns["Salario"].Visible = true;
            dgvTabFunc.Columns["Sexo"].Visible = true;
            dgvTabFunc.Columns["TipoContrato"].Visible = true;
            dgvTabFunc.Columns["DataCadastro"].Visible = true;
            dgvTabFunc.Columns["DataAtualizacao"].Visible = true;
            dgvTabFunc.AutoResizeColumns();
        }

    }
}
