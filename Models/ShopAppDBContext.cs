using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ShopApp.Models
{
    public class ShopAppDBContext: DbContext
    {
        public ShopAppDBContext(DbContextOptions<ShopAppDBContext> options): base(options)
        { 
            
        }

        public DbSet<DCustomer> Customer { get; set; }
        public DbSet<DFestival> Festival { get; set; }
        public DbSet<DShoppingCart> ShoppingCart { get; set; }
        public DbSet<DOrderStatus> OrderStatus { get; set; }
        public DbSet<DOrder> Order { get; set; }
        public DbSet<DOrderItem> OrderItem { get; set; }
        public DbSet<DPayment> Payment { get; set; }
        public DbSet<DTicket> Ticket { get; set; }
        public DbSet<DStage> Stage { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<DShoppingCart>().HasOne(sc => sc.Customer).WithMany(c=>c.ShoppingCarts).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<DOrder>().HasOne(o=>o.Customer).WithMany(c=>c.Orders).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<DOrder>().HasOne(o=>o.OrderStatus).WithMany().OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<DOrderItem>().HasOne(oi => oi.Order).WithMany(o=>o.OrderItems).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<DOrderItem>().HasOne(oi => oi.Ticket).WithMany().OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<DPayment>().HasOne(p => p.Customer).WithMany(c=>c.Payments).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<DPayment>().HasOne(p => p.Order).WithMany().OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<DTicket>().HasOne(t => t.Stage).WithMany(s=>s.Tickets).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<DStage>().HasOne(s => s.Festival).WithMany(f=>f.Stages).OnDelete(DeleteBehavior.NoAction);

        }

    }
}
