using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Dynamix.API.Models
{
    public partial class DbDynamixContext : DbContext
    {
        public DbDynamixContext()
        {
        }

        public DbDynamixContext(DbContextOptions<DbDynamixContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<EmojiRating> EmojiRating { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<LocationVisitor> LocationVisitor { get; set; }
        public virtual DbSet<Review> Review { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:2002-training-altamirano.database.windows.net,1433;Initial Catalog=DbDynamix;Persist Security Info=False;User ID=haroldo;Password=EllieIs#1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.CommentId).HasColumnName("CommentID");

                entity.Property(e => e.CommentText).IsRequired();

                entity.Property(e => e.ReviewId).HasColumnName("ReviewID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Review)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.ReviewId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comment_Review");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comment_User");
            });

            modelBuilder.Entity<EmojiRating>(entity =>
            {
                entity.Property(e => e.EmojiRatingId).HasColumnName("EmojiRatingID");

                entity.Property(e => e.EmojiDescription).HasMaxLength(70);

                entity.Property(e => e.EmojiPictureUrl)
                    .IsRequired()
                    .HasColumnName("EmojiPictureURL");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<LocationVisitor>(entity =>
            {
                entity.Property(e => e.LocationVisitorId)
                    .HasColumnName("LocationVisitorID")
                    .ValueGeneratedNever();

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.ReviewId).HasColumnName("ReviewID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.LocationVisitor)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Location_LocationVisitor");

                entity.HasOne(d => d.Review)
                    .WithMany(p => p.LocationVisitor)
                    .HasForeignKey(d => d.ReviewId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LocationVisitor_Review");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.LocationVisitor)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_LocationVisitor");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.Property(e => e.ReviewId).HasColumnName("ReviewID");

                entity.Property(e => e.CreatorUserId).HasColumnName("CreatorUserID");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.RatingEmojiId).HasColumnName("RatingEmojiID");

                entity.Property(e => e.ReviewImageUrl).HasColumnName("ReviewImageURL");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.CreatorUser)
                    .WithMany(p => p.Review)
                    .HasForeignKey(d => d.CreatorUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Review");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Review)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Location_Review");

                entity.HasOne(d => d.RatingEmoji)
                    .WithMany(p => p.Review)
                    .HasForeignKey(d => d.RatingEmojiId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmojiRating_Review");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(70);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
