using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InventorySerivce.Models;

namespace InventorySerivce.Data
{
    public class InventorySerivceContext : DbContext
    {
        public InventorySerivceContext (DbContextOptions<InventorySerivceContext> options)
            : base(options)
        {
        }

        public DbSet<Bot> Bot { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<Skin> Skin { get; set; }
        public DbSet<Trade> Trade { get; set; }
        public DbSet<User> User { get; set; }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure one-to-many relationship between Trade and Item
            modelBuilder.Entity<Trade>()
                .HasMany(t => t.Items)
                .WithOne(i => i.Trade)
                .HasForeignKey(i => i.TradeId);

            // Optionally, configure one-to-one or many-to-many relationships
            modelBuilder.Entity<Trade>()
                .HasOne(t => t.User)
                .WithMany() // If User does not have a collection of Trades
                .HasForeignKey(t => t.UserId);
        }*/
    }
}
