using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entities
{
    public class Professor
    {
        public virtual int IdProfessor { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Cpf { get; set; }

        #region Relacionamentos

        public virtual List<Turma> Turmas { get; set; }

        #endregion
    }
}
