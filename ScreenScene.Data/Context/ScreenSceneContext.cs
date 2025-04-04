﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ScreenScene.Data.Entities;
using ScreenScene.Data.Entities.Auth;
using ScreenScene.Data.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace ScreenScene.Data.Context;

public class ScreenSceneContext : IdentityDbContext<ApplicationUser>, IScreenSceneDbContext
{
    public ScreenSceneContext(DbContextOptions<ScreenSceneContext> options) : base(options) { }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Actor> Actors { get; set; }
    public DbSet<ActorMovie> ActorMovies { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<GenreMovie> GenreMovies { get; set; }
    public DbSet<Hall> Halls { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Grade> Grades  { get; set; }
    public DbSet<Proposition> Propositions { get; set; }
    public DbSet<Seance> Seances { get; set; }
    public DbSet<Ticket> Tickets { get; set; }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }

    public override DbSet<TEntity> Set<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties | DynamicallyAccessedMemberTypes.Interfaces)] TEntity>()
    {
        return base.Set<TEntity>();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<ActorMovie>()
            .HasKey(am => new { am.ActorId, am.MovieId });

        builder.Entity<GenreMovie>()
            .HasKey(gm => new { gm.GenreId, gm.MovieId });

        base.OnModelCreating(builder);
    }

    public override EntityEntry<TEntity> Entry<TEntity>(TEntity entity)
    {
        return base.Entry(entity);
    }
}