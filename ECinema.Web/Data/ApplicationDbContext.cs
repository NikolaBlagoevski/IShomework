using ECinema.Web.Models.Domain;
using ECinema.Web.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECinema.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ECinemaAppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ECinemaTicket> tickets { get; set; }

        public virtual DbSet<ECinemaCart> carts { get; set; }

        public virtual DbSet<ECinemaTicketInCart> ticketsInCarts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ECinemaTicket>().Property(z => z.id).ValueGeneratedOnAdd();

            builder.Entity<ECinemaCart>().Property(z => z.id).ValueGeneratedOnAdd();

            builder.Entity<ECinemaTicketInCart>().HasKey(z => new { z.ticketId, z.cartId });

            builder.Entity<ECinemaTicketInCart>().HasOne(z => z.ticket).WithMany(z => z.ticketsInCart).HasForeignKey(z => z.cartId);

            builder.Entity<ECinemaTicketInCart>().HasOne(z => z.cart).WithMany(z => z.ticketsInCart).HasForeignKey(z => z.ticketId);

            builder.Entity<ECinemaCart>().HasOne<ECinemaAppUser>(z => z.user).WithOne(z => z.userCart).HasForeignKey<ECinemaCart>(z => z.userId);
        }
    }
}
