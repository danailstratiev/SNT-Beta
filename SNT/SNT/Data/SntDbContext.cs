using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SNT.Models;

namespace SNT.Data
{
    public class SntDbContext : IdentityDbContext<SntUser, IdentityRole, string>
    {
        public DbSet<Tyre> Tyres { get; set; }
        public DbSet<WheelRim> WheelRims { get; set; }
        public DbSet<MotorOil> MotorOils { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ShoppingBag> ShoppingBag { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<ShoppingBagTyre> ShoppingBagTyres { get; set; }
        public DbSet<ShoppingBagWheelRim> ShoppingBagWheelRims { get; set; }
        public DbSet<ShoppingBagMotorOil> ShoppingBagMotorOils { get; set; }
        public DbSet<OrderTyre> OrderTyres { get; set; }
        public DbSet<OrderWheelRim> OrderWheelRims { get; set; }
        public DbSet<OrderMotorOil> OrderMotorOils { get; set; }

        public SntDbContext(DbContextOptions<SntDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=SntDB;Trusted_Connection=true");
        }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<ShoppingBagTyre>().HasKey(x => new { x.UserId, x.TyreId });


        //}
    }
}
