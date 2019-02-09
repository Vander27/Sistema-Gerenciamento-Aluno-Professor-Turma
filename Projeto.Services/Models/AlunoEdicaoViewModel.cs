using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Services.Models
{
    public class AlunoEdicaoViewModel
    {
        [Required(ErrorMessage = "Por favor, informe o id.")]
        public int IdAluno { get; set; }

        [Required(ErrorMessage = "Por favor, informe o nome.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe o email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Por favor, informe a data de nascimento.")]
        public DateTime DataNascimento { get; set; }
    }
}