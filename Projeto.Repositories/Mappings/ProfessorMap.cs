using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entities; //importando..
using System.Data.Entity.ModelConfiguration; //ORM..

namespace Projeto.Repositories.Mappings
{
    //Classe de mapeamento para a entidade Professor..
    public class ProfessorMap : EntityTypeConfiguration<Professor>
    {
        //construtor [ctor] + 2x[tab]
        public ProfessorMap()
        {
            //nome da tabela..
            ToTable("PROFESSOR");

            //chave primária..
            HasKey(p => p.IdProfessor);

            //mapear os campos da tabela..
            Property(p => p.IdProfessor)
                .HasColumnName("IDPROFESSOR")
                .IsRequired();

            Property(p => p.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(150)
                .IsRequired();

            Property(p => p.Cpf)
                .HasColumnName("CPF")
                .HasMaxLength(11)
                .IsRequired();
        }
    }
}
