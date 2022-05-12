using Microsoft.EntityFrameworkCore;
using SimpleTodo.Models;
using System.Configuration;

namespace SimpleTodo.Data
{
    public class Context : DbContext
    {
        public DbSet<Todo> Todos { get; set; }

        public Context(): base()
        {
            try
            {
                Database.Migrate();
            }catch(Exception ex)
            {
                Console.WriteLine($"Erro ao iniciar a base! {ex.Message}");
            }
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                optionsBuilder.UseSqlite(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            }catch (Exception ex)
            {
                throw new ConfigurationErrorsException("Erro ao iniciar o banco", ex);
            }
           
        }
    }
}
