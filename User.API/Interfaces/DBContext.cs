using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using User.API.Models;

namespace User.API.Interfaces;

public partial class DBContext : DbContext
{
    public DBContext()
    {
    }

    public DBContext(DbContextOptions<DBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    public virtual DbSet<UserToken> UserTokens { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.pkid).HasName("Roles_pkey");

            entity.HasIndex(e => e.name, "Roles_name_key").IsUnique();

            entity.Property(e => e.created_at)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.is_active).HasDefaultValue(true);
            entity.Property(e => e.name).HasMaxLength(50);
            entity.Property(e => e.updated_at).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.pkid).HasName("Users_pkey");

            entity.HasIndex(e => e.email, "Users_email_key").IsUnique();

            entity.HasIndex(e => e.username, "Users_username_key").IsUnique();

            entity.Property(e => e.created_at)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.email).HasMaxLength(100);
            entity.Property(e => e.first_name).HasMaxLength(100);
            entity.Property(e => e.is_active).HasDefaultValue(true);
            entity.Property(e => e.last_name).HasMaxLength(100);
            entity.Property(e => e.password_hash).HasMaxLength(200);
            entity.Property(e => e.phone_number).HasMaxLength(20);
            entity.Property(e => e.updated_at).HasColumnType("timestamp without time zone");
            entity.Property(e => e.username).HasMaxLength(50);
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => new { e.user_pkid, e.role_pkid }).HasName("UserRoles_pkey");

            entity.Property(e => e.assigned_at)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.role_pk).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.role_pkid)
                .HasConstraintName("UserRoles_role_pkid_fkey");

            entity.HasOne(d => d.user_pk).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.user_pkid)
                .HasConstraintName("UserRoles_user_pkid_fkey");
        });

        modelBuilder.Entity<UserToken>(entity =>
        {
            entity.HasKey(e => e.pkid).HasName("UserTokens_pkey");

            entity.HasIndex(e => e.user_id, "UserTokens_user_id_key").IsUnique();

            entity.Property(e => e.created_at)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.expired_at).HasColumnType("timestamp without time zone");
            entity.Property(e => e.revoked_at).HasColumnType("timestamp without time zone");
            entity.Property(e => e.updated_at).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.user).WithOne(p => p.UserToken)
                .HasForeignKey<UserToken>(d => d.user_id)
                .HasConstraintName("UserTokens_user_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
