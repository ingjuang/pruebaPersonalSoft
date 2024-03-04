using System;
using System.Collections.Generic;
using Prueba.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Infrastructure;

public partial class MilesCarRentalContext : DbContext
{
    public MilesCarRentalContext()
    {
    }

    public MilesCarRentalContext(DbContextOptions<MilesCarRentalContext> options)
        : base(options)
    {
    }

    public DbSet<Car> Cars { get; set; }
    public DbSet<Location> Locations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
