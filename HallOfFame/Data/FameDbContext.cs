using HallOfFame.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HallOfFame.Data
{
    public class FameDbContext : DbContext
    {
        public DbSet<Person> Persons => Set<Person>();
        public DbSet<Skill> Skills => Set<Skill>();

        public FameDbContext(DbContextOptions<FameDbContext> options)
            : base(options)
        {
        }

    }
}
