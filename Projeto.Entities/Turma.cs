using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entities
{
    public class Turma
    {
        public virtual int IdTurma { get; set; }
        public virtual string Nome { get; set; }
        public virtual DateTime DataInicio { get; set; }
        public virtual DateTime DataTermino { get; set; }
        public virtual int IdProfessor { get; set; }

        #region Relacionamentos

        public virtual Professor Professor { get; set; }
        public virtual List<Aluno> Alunos { get; set; }

        #endregion
    }
}
