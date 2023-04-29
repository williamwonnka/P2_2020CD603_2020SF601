using Microsoft.EntityFrameworkCore;

namespace P2_2020CD603_2020SF601.Models
{
    public class parcialDbContext : DbContext
    {
        public parcialDbContext(DbContextOptions dbContext) : base(dbContext)
        {


        }

        public DbSet<Departamentos> departamentos { get; set; }

        public DbSet<Generos> Generos { get; set; }

        public DbSet<CasosReportados> CasosReportados { get; set; }
    }
}
