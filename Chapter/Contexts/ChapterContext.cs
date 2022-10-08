using Chapter.Models;
using Microsoft.EntityFrameworkCore;

namespace Chapter.Contexts
{
    public class ChapterContext: DbContext //classe herdada
    {
        public ChapterContext() { }
        public ChapterContext(DbContextOptions<ChapterContext> options) : base(options) { }

        //método para configurar bd
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            if (!optionsBuilder.IsConfigured)
            {
                //sintaxe para o provedor
                optionsBuilder.UseSqlServer("Data Source = MYMAX\\SQLEXPRESS; initial catalog = Chapter; Integrated Security=true"); //User Id=myUsername;Password=myPassword;

            }
        }

        public DbSet<Livro> Livros { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
