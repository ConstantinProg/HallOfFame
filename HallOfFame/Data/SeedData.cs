using HallOfFame.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HallOfFame.Data
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            FameDbContext context = app.ApplicationServices
            .CreateScope().ServiceProvider.GetRequiredService<FameDbContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (!context.Persons.Any())
            {
                Person p1 = new Person { Name = "Constantin", DisplayName = "Programmer" };
                context.Persons.AddRange(p1);
                Skill s1 = new Skill { Name = "English", Level = 5, Person = p1 };
                Skill s2 = new Skill { Name = "AspNet", Level = 2, Person = p1 };
                context.Skills.AddRange(s1, s2);
                context.SaveChanges();
            }
        }
    }
}
