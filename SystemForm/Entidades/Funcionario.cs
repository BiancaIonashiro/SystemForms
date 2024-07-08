using System;
using System.ComponentModel.DataAnnotations;

namespace SystemForm.Entidades
{
    public class Funcionario
    {
        public int Id { get; set; }

        [Required, StringLength(70, MinimumLength = 5)]
        public string Nome { get; set; }

        [Required, EmailAddress, StringLength(70, MinimumLength = 5)]
        public string Email { get; set; }

        [Required]
        public decimal Salario { get; set; }
        public string Sexo { get; set; }
        public string TipoContrato { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }

    }
}
