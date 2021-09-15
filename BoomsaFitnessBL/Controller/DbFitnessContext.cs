using BoomsaFitnessBL.Model;
using System.Data.Entity;

namespace BoomsaFitnessBL.Controller
{
    public class DbFitnessContext : DbContext
    {
        public DbFitnessContext():base("DBConnection")
        {
            Database.CreateIfNotExists();
        }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Eating> Eatings { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet <Gender> Genders { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
