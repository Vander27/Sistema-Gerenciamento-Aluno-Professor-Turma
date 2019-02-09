using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entities
{
    public class Aluno
    {
        public virtual int IdAluno { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Email { get; set; }
        public virtual DateTime DataNascimento { get; set; }

        #region Relacionamentos

        public virtual List<Turma> Turmas { get; set; }

        #endregion
    }
}
