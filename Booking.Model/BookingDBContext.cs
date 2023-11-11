using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Booking.Model {
    public class BookingDBContext : DbContext {
        public BookingDBContext(DbContextOptions options)
            : base(options) {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            List<Package> packages = new List<Package>();
            packages.Add(new Package { Id = 1, Name = "Basic", Country = Country.Singapore, Credit = 3, StartTime = DateTime.Now, EndTime = DateTime.Now.AddDays(7) });
            packages.Add(new Package { Id = 2, Name = "Intermidiate", Country = Country.US, Credit = 2, StartTime = DateTime.Now, EndTime = DateTime.Now.AddDays(7) });
            packages.Add(new Package { Id = 3, Name = "Basic", Country = Country.Myanmar, Credit = 3, StartTime = DateTime.Now, EndTime = DateTime.Now.AddDays(7) });

            modelBuilder.Entity<Package>().HasData(packages);
        }

        public class DbContextFactory : IDesignTimeDbContextFactory<BookingDBContext> {
            public BookingDBContext CreateDbContext(string[] args) {
                string connectionstring = "Server=localhost; Database=BookingDB; User Id=root; Password=$ecr3t;";
                if (args.Length > 0)
                    connectionstring = args[0];
                var optionsBuilder = new DbContextOptionsBuilder<BookingDBContext>();
                optionsBuilder.UseMySql(connectionstring, ServerVersion.AutoDetect(connectionstring));

                return new BookingDBContext(optionsBuilder.Options);
            }
        }
    }
}
