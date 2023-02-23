using Microsoft.EntityFrameworkCore;

namespace CarsTestTask.Models
{
    public class Context : DbContext
    {
        public DbSet<Brand> Brands { get; set; } = null!;
        public DbSet<Model> Models { get; set; } = null!;
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string[] Brands = { "Kia", "Mitsubishi", "Nissan", "Lada", "Subaru", "Toyota", "Volkswagen", "Hyundai" };
            string[][] Marks = {
                    new string[] { "Rio", "Rondo", "Sorento" },
                    new string[] { "Lancer", "Outlander", "Rvr" },
                    new string[] { "Murano", "Pathfinder", "Sentra" },
                    new string[] { "Kalina", "Vesta", "Granta" },
                    new string[] { "Impreza", "Legacy", "Outback" },
                    new string[] { "Corolla", "Highlander", "Land Cruiser" },
                    new string[]{ "Passat", "Tiguan", "Touareg" },
                    new string[] { "Accent", "Elantra", "Sonata"} };
            var random = new Random();
            for (int i = 0; i < Brands.Length; i++)
            {

                modelBuilder.Entity<Brand>().HasData(new Brand[] { new Brand { Id = i + 1, Name = Brands[i], Active = random.Next(2) == 1 } });

                for (int j = 0; j < Marks[i].Length; j++)
                {
                    modelBuilder.Entity<Model>().HasData(new Model[] { new Model { Id = j + 1 + (i * 3), Name = Marks[i][j], Active = random.Next(2) == 1, BrandID = i + 1 } });
                }

            }

        }
    }
}

