using Microsoft.EntityFrameworkCore;
using CadastroEstudantesIEL.Models;

namespace CadastroEstudantesIEL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Estudante> Estudantes { get; set; }
    }
}