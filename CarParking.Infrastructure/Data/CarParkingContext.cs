using CarParking.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarParking.Infrastructure.Data
{
    public class CarParkingContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ParkingAccessCard> ParkingAccessCards { get; set; }
        public DbSet<CarAccessHistory> CarAccessHistories { get; set; }


        public CarParkingContext(DbContextOptions<CarParkingContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(ConfigureCar);
            modelBuilder.Entity<Employee>(ConfigureEmployee);
            modelBuilder.Entity<ParkingAccessCard>(ConfigureParkingAccessCard);
            modelBuilder.Entity<CarAccessHistory>(ConfigureCarAccessHistory);
        }

        private void ConfigureCar(EntityTypeBuilder<Car> builder)
        {
            builder.ToTable("Car");
        }

        private void ConfigureEmployee(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");
        }

        private void ConfigureParkingAccessCard(EntityTypeBuilder<ParkingAccessCard> builder)
        {
            builder.ToTable("ParkingAccessCard");
        }
        private void ConfigureCarAccessHistory(EntityTypeBuilder<CarAccessHistory> builder)
        {
            builder.ToTable("CarAccessHistory");
        }
    }
}
