using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Projeto.Repositories.Mappings
{
    public class TurmaMap : EntityTypeConfiguration<Turma>
    {
        public TurmaMap()
        {
            ToTable("TURMA");

            HasKey(t => t.IdTurma);

            Property(t => t.IdTurma)
                .HasColumnName("IDTURMA")
                .IsRequired();

            Property(t => t.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(50)
                .IsRequired();

            Property(t => t.DataInicio)
                .HasColumnName("DATAINICIO")
                .IsRequired();

            Property(t => t.DataTermino)
                .HasColumnName("DATATERMINO")
                .IsRequired();

            Property(t => t.IdProfessor)
                .HasColumnName("IDPROFESSOR")
                .IsRequired();

            #region Relacionamento com Professor (1pN)

            HasRequired(t => t.Professor) //TURMA TEM 1 PROFESSOR
                .WithMany(p => p.Turmas) //PROFESSOR TEM 'N' TURMAS
                .HasForeignKey(t => t.IdProfessor) //CHAVE ESTRANGEIRA
                .WillCascadeOnDelete(false);

            #endregion

            #region Relacionamento com Aluno (NpN)

            HasMany(t => t.Alunos) //TURMA TEM MUITOS ALUNOS
                .WithMany(a => a.Turmas) //ALUNO TEM MUITAS TURMAS                
                .Map( //MAPEANDO A TABELA ASSOCIATIVA
                    m =>
                    {
                        //NOME DA TABELA ASSOCIATIVA
                        m.ToTable("TURMAALUNO");

                        //CHAVE ESTRANGEIRA COM A TABELA TURMA
                        m.MapLeftKey("IDTURMA");

                        //CHAVE ESTRANGEIRA COM A TABELA ALUNO
                        m.MapRightKey("IDALUNO");
                    }
                );                

            #endregion
        }
    }
}
