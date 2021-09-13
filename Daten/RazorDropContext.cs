using Microsoft.EntityFrameworkCore;
using Brushless.Models;

namespace Brushless.Data
{
   public class RazorDropContext : DbContext
   {
      public RazorDropContext(DbContextOptions<RazorDropContext> options) : base(options)
      { 

      }

      public DbSet<Country>     Countries { get; set; }
      public DbSet<Customer>    Customers { get; set; }
      public DbSet<Region>      Regions { get; set; }

      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      {

      }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         modelBuilder.Entity<Country>().ToTable("Countries");
         modelBuilder.Entity<Region>().ToTable("Regions");
         modelBuilder.Entity<Customer>().ToTable("Customers");

         modelBuilder.Entity<Country>().HasData(
             new Country
             {
                CountryId = "US",
                CountryNameEnglish = "United States of America"
             },
             new Country
             {
                CountryId = "CA",
                CountryNameEnglish = "Canada"
             },
             new Country
             {
                CountryId = "DE",
                CountryNameEnglish = "Germany"
             });
         modelBuilder.Entity<Region>().HasData(
             /*disbale region test 
             new Region
             {
                CountryId = "US",
                RegionId = "CT",
                RegionNameEnglish = "Connecticut"
             },*/
             new Region
             {
                CountryId = "US",
                RegionId = "ME",
                RegionNameEnglish = "Maine"
             },
             new Region
             {
                CountryId = "DE",
                RegionId = "BY",
                RegionNameEnglish = "Bavaria"
             },
             new Region
             {
                CountryId = "DE",
                RegionId = "BW",
                RegionNameEnglish = "Baden-Wuerttemberg"
             },
             new Region
             {
                CountryId = "DE",
                RegionId = "NRW",
                RegionNameEnglish = "North Rhine-Westphalia"
             });
      }
   }
}