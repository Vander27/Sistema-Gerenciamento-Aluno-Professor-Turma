using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Projeto.Entities;
using Projeto.Repositories.Mappings;
using System.Configuration;

namespace Projeto.Repositories.Context
{
    //REGRA 1) HERDAR DbContext
    public class DataContext : DbContext
    {
        //REGRA 2) CONSTRUTOR PARA RECEBER A CONNECTIONSTRING
        public DataContext()
            : base(ConfigurationManager.ConnectionStrings["AULA17"].ConnectionString)
        {

        }

        //REGRA 3) SOBRESCREVER O MÉTODO OnModelCreating
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //adicionar as classes de mapeamento..
            modelBuilder.Configurations.Add(new AlunoMap());
            modelBuilder.Configurations.Add(new ProfessorMap());
            modelBuilder.Configurations.Add(new TurmaMap());
        }

        //REGRA 4) DECLARAR UMA PROPRIEDADE SET/GET PARA CADA ENTIDADE
        //DO TIPO DbSet (PERMITIR A REALIZAÇÃO DAS OPERAÇÕES DE CRUD)
        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<Professor> Professor { get; set; }
        public DbSet<Turma> Turma { get; set; }
    }
}
