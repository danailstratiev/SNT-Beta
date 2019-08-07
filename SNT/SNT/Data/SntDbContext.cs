using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SNT.Models;
using SNT.Models.Interfaces;

namespace SNT.Data
{
    public class SntDbContext : IdentityDbContext
    {
        public DbSet<Tyre> Tyres { get; set; }
        public DbSet<WheelRim> WheelRims { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<SntUser> SntUsers { get; set; }
        public DbSet<ShoppingBag> ShoppingBags { get; set; }
        public DbSet<SntReceipt> SntReceipts { get; set; }

        public SntDbContext(DbContextOptions<SntDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-7FT7CTPS\\SQLEXPRESS;Database=PandaDB;Trusted_Connection=true");
        }
    }
}
