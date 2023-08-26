using AquaStoreAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace AquaStoreAPI.Data
{
    public class StoreDbContext : DbContext
    {
        private string _connectionString;
        public StoreDbContext(DbContextOptions options) : base(options)
        {
            //this._connectionString = "Data source=LAPTOP-O0AFMGM8\\SQLEXPRESS;Database=AquaStoreDb;Trusted_Connection=True;TrustServerCertificate=True;";
        }

        public DbSet<Product> Products { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(_connectionString);
        //}
    }
}
