namespace Projeto.Repositories.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Projeto.Repositories.Context.DataContext>
    {
        public Configuration()
        {
            //Permissão para atualizar o banco de dados..
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Projeto.Repositories.Context.DataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
