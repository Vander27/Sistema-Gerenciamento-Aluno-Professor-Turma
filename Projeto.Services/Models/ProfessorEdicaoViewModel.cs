using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Services.Models
{
    public class ProfessorEdicaoViewModel
    {
        [Required(ErrorMessage = "Por favor, informe o id.")]
        public int IdProfessor { get; set; }

        [Required(ErrorMessage = "Por favor, informe o nome.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe o cpf.")]
        public string Cpf { get; set; }
    }
}