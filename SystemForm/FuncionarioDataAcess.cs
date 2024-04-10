using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemForm.Entidades;
using System.ComponentModel.DataAnnotations; //validacao de dados via ref. e classe.

namespace SystemForm
{
    public partial class CadastroFuncionario : Form
    {
        public CadastroFuncionario()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Mover os dados p/ classe funcionario
            Funcionario funcionario = new Funcionario();
            funcionario.Nome = txtNome.Text;
            funcionario.Email = txtEmail.Text;
            funcionario.Salario = decimal.Parse(txtSalario.Text);
            funcionario.Sexo = (rbM.Checked) ? "M" : "F";
            funcionario.TipoContrato = (rbCLT.Checked) ? "CLT" : (rbPJ.Checked) ? "PJ" : "AUT";
            funcionario.DataCadastro = DateTime.Now;

            //Validar os dados 
            List<ValidationResult> listErrors = new List<ValidationResult>();
            ValidationContext contexto = new ValidationContext(funcionario);
            bool validado = Validator.TryValidateObject(funcionario, contexto, listErrors, true);

            if(validado)
            {
                //Salvar os dados
                //Fechar e atualizar a tela principal
            }
            else
            {
                //validacao erro
                StringBuilder sb = new StringBuilder();
                foreach(ValidationResult erro in listErrors) 
                {
                    sb.AppendLine(erro.ErrorMessage + "\n");                
                }
                lblErros.Text = sb.ToString();
            }
        }
    }
}
