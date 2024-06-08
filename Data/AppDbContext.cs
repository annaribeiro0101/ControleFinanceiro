using ApiCrud.Model;
using Microsoft.EntityFrameworkCore;
using ApiContasAPagar;

namespace ApiCrud.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<ContasAPagar> ContasAPagar { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Banco.sqlite");
            optionsBuilder.LogTo(Console.WriteLine);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
