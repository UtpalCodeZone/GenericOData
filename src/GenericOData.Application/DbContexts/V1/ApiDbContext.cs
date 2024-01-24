using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using GenericOData.Application.Models.V1.DataModels;

namespace GenericOData.Application.DbContexts.V1
{
    public partial class ApiDbContext : DbContext
    {
        public ApiDbContext()
        {
        }

        public ApiDbContext(DbContextOptions<ApiDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<edge> edges { get; set; }
        public virtual DbSet<endpoint> endpoints { get; set; }
        public virtual DbSet<o> os { get; set; }
        public virtual DbSet<parameter> parameters { get; set; }
        public virtual DbSet<protocol> protocols { get; set; }
        public virtual DbSet<site> sites { get; set; }
        public virtual DbSet<uom> uoms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<edge>(entity =>
            {
                entity.Property(e => e.id).UseIdentityAlwaysColumn();

                entity.Property(e => e.created_date).HasDefaultValueSql("timezone('utc'::text, now())");

                entity.Property(e => e.row_id).HasDefaultValueSql("gen_random_uuid()");

                entity.Property(e => e.status).HasDefaultValueSql("true");

                entity.HasOne(d => d.os)
                    .WithMany(p => p.edges)
                    .HasForeignKey(d => d.os_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("edge_fk_os");
            });

            modelBuilder.Entity<endpoint>(entity =>
            {
                entity.Property(e => e.id).UseIdentityAlwaysColumn();

                entity.Property(e => e.created_date).HasDefaultValueSql("timezone('utc'::text, now())");

                entity.Property(e => e.row_id).HasDefaultValueSql("gen_random_uuid()");

                entity.Property(e => e.status).HasDefaultValueSql("true");

                entity.HasOne(d => d.protocol)
                    .WithMany(p => p.endpoints)
                    .HasForeignKey(d => d.protocol_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("endpoint_fk_protocol");
            });

            modelBuilder.Entity<o>(entity =>
            {
                entity.Property(e => e.id).UseIdentityAlwaysColumn();

                entity.Property(e => e.created_date).HasDefaultValueSql("timezone('utc'::text, now())");

                entity.Property(e => e.row_id).HasDefaultValueSql("gen_random_uuid()");

                entity.Property(e => e.status).HasDefaultValueSql("true");
            });

            modelBuilder.Entity<parameter>(entity =>
            {
                entity.Property(e => e.id).UseIdentityAlwaysColumn();

                entity.Property(e => e.created_date).HasDefaultValueSql("timezone('utc'::text, now())");

                entity.Property(e => e.row_id).HasDefaultValueSql("gen_random_uuid()");

                entity.Property(e => e.status).HasDefaultValueSql("true");
            });

            modelBuilder.Entity<protocol>(entity =>
            {
                entity.Property(e => e.id).UseIdentityAlwaysColumn();

                entity.Property(e => e.created_date).HasDefaultValueSql("timezone('utc'::text, now())");

                entity.Property(e => e.row_id).HasDefaultValueSql("gen_random_uuid()");

                entity.Property(e => e.status).HasDefaultValueSql("true");
            });

            modelBuilder.Entity<site>(entity =>
            {
                entity.Property(e => e.id).UseIdentityAlwaysColumn();

                entity.Property(e => e.created_date).HasDefaultValueSql("timezone('utc'::text, now())");

                entity.Property(e => e.deleted).HasDefaultValueSql("false");

                entity.Property(e => e.row_id).HasDefaultValueSql("gen_random_uuid()");

                entity.Property(e => e.status).HasDefaultValueSql("true");
            });

            modelBuilder.Entity<uom>(entity =>
            {
                entity.Property(e => e.id).UseIdentityAlwaysColumn();

                entity.Property(e => e.created_date).HasDefaultValueSql("timezone('utc'::text, now())");

                entity.Property(e => e.row_id).HasDefaultValueSql("gen_random_uuid()");

                entity.Property(e => e.status).HasDefaultValueSql("true");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
