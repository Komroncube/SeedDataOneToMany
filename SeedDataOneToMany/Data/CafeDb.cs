namespace SeedDataOneToMany.Data
{
    public class CafeDb : DbContext
    {
        private Guid client1 = Guid.Parse("f06b1e67-4aee-47db-b112-beb91fe3a141");
        private Guid client2 = Guid.Parse("ef45969d-c5f3-4ceb-b86e-ae1229f64841");

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost; Port=5432; User Id=postgres; Password=root; Database=CafeDb");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AddClient(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Client> Clients { get; set; }



        void AddClient(ModelBuilder modelBuilder)
        {
            string cl_1 = "Jorj";
            string cl_2 = "Simon";

            modelBuilder.Entity<Client>().HasData(
                new Client
                {
                    Id = client1,
                    Name = cl_1,
                    Username = "newuser",
                }
            );

            modelBuilder.Entity<Client>().HasData(
                new Client
                {
                    Id = client2,
                    Name = cl_2,
                    Username = "incognito",
                }
            );
        }
    }
}
