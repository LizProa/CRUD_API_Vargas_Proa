using Microsoft.EntityFrameworkCore;

namespace CRUD_API_Vargas_Proa.Models
{
    public class LibroContext : DbContext
    {
        public LibroContext(DbContextOptions<LibroContext> options)
            : base(options)
        {

        }
        public DbSet<LibroItem> LibroItems { get; set; } = null!;
    }
}
