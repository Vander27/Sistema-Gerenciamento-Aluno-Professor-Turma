using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Projeto.Repositories.Mappings
{
    //Classe de mapeamento para a entidade Aluno..
    public class AlunoMap : EntityTypeConfiguration<Aluno>
    {
        //construtor [ctor] + 2x[tab]
        public AlunoMap()
        {
            //nome da tabela..
            ToTable("ALUNO");

            //chave primária..
            HasKey(a => a.IdAluno);

            //mapeando os campos..
            Property(a => a.IdAluno)
                .HasColumnName("IDALUNO")
                .IsRequired();

            Property(a => a.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(150)
                .IsRequired();

            Property(a => a.Email)
                .HasColumnName("EMAIL")
                .HasMaxLength(100)
                .IsRequired();

            Property(a => a.DataNascimento)
                .HasColumnName("DATANASCIMENTO")
                .IsRequired();
        }
    }
}
