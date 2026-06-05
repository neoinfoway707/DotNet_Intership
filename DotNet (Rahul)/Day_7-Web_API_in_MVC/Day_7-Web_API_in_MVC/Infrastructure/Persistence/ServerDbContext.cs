using System;
using System.Collections.Generic;
using Day_7_Web_API_in_MVC.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Day_7_Web_API_in_MVC.Infrastructure.Data;

public partial class ServerDbContext : DbContext
{
    public ServerDbContext()
    {
    }

    public ServerDbContext(DbContextOptions<ServerDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Server> Servers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Server>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Servers__3214EC0744C32916");

            entity.Property(e => e.IsOnline).HasDefaultValue(true);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
