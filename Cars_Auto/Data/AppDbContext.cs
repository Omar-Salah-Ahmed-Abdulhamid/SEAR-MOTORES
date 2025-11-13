using Cars_Auto.Models;

namespace Cars_Auto.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        :base(options) 
        {

            
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Categoriey> Categories { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<CarImage> carImages { get; set; }
		public DbSet<Purchase> Purchases { get; set; }



		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoriey>().
                HasData(new Categoriey[]
                {
                    new Categoriey{Id=1,Name="Sedan"},
                    new Categoriey{Id=2,Name="Hatchback"},
                    new Categoriey{Id=3,Name="SUV"},
                    new Categoriey{Id=4,Name="Crossover"},
                    new Categoriey{Id=5,Name="Pickup"},
                    new Categoriey{Id=6,Name="Luxury"}

                });

            modelBuilder.Entity<User>().
                HasData(new User[]
                {
                    new User{Id=1,Name="Omar Salah",Email="OmarSalah@gamil.com",Password="1234",PhoneNumber = "0100000000",Role="Admin" },
                    new User{Id=2,Name="Admin",Email="Admin@gamil.com",Password="Admin1234",PhoneNumber = "0100000000",Role="Admin" }

                });
        }

    }
}
