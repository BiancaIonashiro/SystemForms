using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Windows.Forms;
using SystemForm.Entidades;
using SystemForm.ModeloInterface;

namespace SystemForm
{
    public partial class CadastroFuncionario : Form
    {
        private readonly ICadastroFuncionario _cadastroFuncionario;
        public CadastroFuncionario()
        {
            _cadastroFuncionario = Program.ServiceProvider.GetRequiredService<ICadastroFuncionario>();
            InitializeComponent();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            //Mover os dados p/ classe funcionario
            Funcionario funcionario = new Funcionario();
            funcionario.Nome = txtNome.Text;
            funcionario.Email = txtEmail.Text;
            decimal.TryParse(txtSalario.Text, out decimal salario);
            funcionario.Salario = salario;
            funcionario.Sexo = (rbM.Checked) ? "M" : "F";
            funcionario.TipoContrato = (rbCLT.Checked) ? "CLT" : (rbPJ.Checked) ? "PJ" : "AUT";
            funcionario.DataCadastro = DateTime.Now;

            //Validar os dados 
            List<ValidationResult> listErrors = new List<ValidationResult>();
            ValidationContext contexto = new ValidationContext(funcionario);
            bool validado = Validator.TryValidateObject(funcionario, contexto, listErrors, true);

            if (validado)
            {
                //Salvar os dados
                _cadastroFuncionario.Inserir(funcionario);
                //Fechar e atualizar a tela principal
                this.Close();

                new frmTelaPrincipal().ShowDialog();
                //Sucesso
            }
            else
            {
                //Validacao erro
                StringBuilder sb = new StringBuilder();
                foreach (ValidationResult erro in listErrors)
                {
                    sb.AppendLine(erro.ErrorMessage + "\n");
                }
                lblErros.Text = sb.ToString();
                //lblErros.Text = "Erro na inserção - Banco";
            }
        }
    }
}
