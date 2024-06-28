﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PZ2_PROJECT.Data;

#nullable disable

namespace PZ2_PROJECT.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("PZ2_PROJECT.Models.Movie", b =>
                {
                    b.Property<string>("MovieID")
                        .HasColumnType("TEXT");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.HasKey("MovieID");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("PZ2_PROJECT.Models.Opinion", b =>
                {
                    b.Property<string>("MovieID")
                        .HasColumnType("TEXT")
                        .HasColumnOrder(0);

                    b.Property<string>("UserID")
                        .HasColumnType("TEXT")
                        .HasColumnOrder(1);

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<string>("Rating")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.Property<string>("ReviewText")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.HasKey("MovieID", "UserID");

                    b.HasIndex("UserID");

                    b.ToTable("Opinions");
                });

            modelBuilder.Entity("PZ2_PROJECT.Models.User", b =>
                {
                    b.Property<string>("UserID")
                        .IsRequired()  // Klucz główny musi być oznaczony jako Required
                        .HasMaxLength(30)  // Ustawiam maksymalną długość na 30, zgodnie z modelem
                        .HasColumnType("INTEGER");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.HasKey("UserID");  // Ustawienie klucza głównego

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PZ2_PROJECT.Models.Opinion", b =>
                {
                    b.HasOne("PZ2_PROJECT.Models.Movie", "Movie")
                        .WithMany("Opinions")
                        .HasForeignKey("MovieID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PZ2_PROJECT.Models.User", "User")
                        .WithMany("Opinions")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PZ2_PROJECT.Models.Movie", b =>
                {
                    b.Navigation("Opinions");
                });

            modelBuilder.Entity("PZ2_PROJECT.Models.User", b =>
                {
                    b.Navigation("Opinions");
                });
#pragma warning restore 612, 618
        }
    }
}
