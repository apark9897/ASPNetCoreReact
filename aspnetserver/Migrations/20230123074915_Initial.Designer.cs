﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using aspnetserver.Data;

#nullable disable

namespace aspnetserver.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20230123074915_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("aspnetserver.Data.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            Title = "General"
                        },
                        new
                        {
                            CategoryId = 2,
                            Title = "Guitar"
                        },
                        new
                        {
                            CategoryId = 3,
                            Title = "Synths"
                        },
                        new
                        {
                            CategoryId = 4,
                            Title = "Vocals"
                        });
                });

            modelBuilder.Entity("aspnetserver.Data.Models.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(100000)
                        .HasColumnType("TEXT");

                    b.Property<int>("PostId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("downs")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ups")
                        .HasColumnType("INTEGER");

                    b.HasKey("CommentId");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            CommentId = 1,
                            Content = "This is a comment on post 1, I love this post!",
                            PostId = 1,
                            UserId = 3,
                            downs = 1,
                            ups = 1
                        },
                        new
                        {
                            CommentId = 2,
                            Content = "This is a comment on post 2, I love this post!",
                            PostId = 2,
                            UserId = 1,
                            downs = 1,
                            ups = 1
                        },
                        new
                        {
                            CommentId = 3,
                            Content = "This is a comment on post 3, I love this post!",
                            PostId = 3,
                            UserId = 2,
                            downs = 1,
                            ups = 1
                        },
                        new
                        {
                            CommentId = 4,
                            Content = "This is a comment on post 4, I love this post!",
                            PostId = 4,
                            UserId = 3,
                            downs = 1,
                            ups = 1
                        },
                        new
                        {
                            CommentId = 5,
                            Content = "This is a comment on post 5, I love this post!",
                            PostId = 5,
                            UserId = 1,
                            downs = 1,
                            ups = 1
                        },
                        new
                        {
                            CommentId = 6,
                            Content = "This is a comment on post 6, I love this post!",
                            PostId = 6,
                            UserId = 2,
                            downs = 1,
                            ups = 1
                        });
                });

            modelBuilder.Entity("aspnetserver.Data.Models.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(100000)
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("PostId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            PostId = 1,
                            CategoryId = 1,
                            Content = "This is post 1 and it has some very interesting content.",
                            Title = "Post 1",
                            UserId = 2
                        },
                        new
                        {
                            PostId = 2,
                            CategoryId = 1,
                            Content = "This is post 2 and it has some very interesting content.",
                            Title = "Post 2",
                            UserId = 3
                        },
                        new
                        {
                            PostId = 3,
                            CategoryId = 1,
                            Content = "This is post 3 and it has some very interesting content.",
                            Title = "Post 3",
                            UserId = 1
                        },
                        new
                        {
                            PostId = 4,
                            CategoryId = 1,
                            Content = "This is post 4 and it has some very interesting content.",
                            Title = "Post 4",
                            UserId = 2
                        },
                        new
                        {
                            PostId = 5,
                            CategoryId = 1,
                            Content = "This is post 5 and it has some very interesting content.",
                            Title = "Post 5",
                            UserId = 3
                        },
                        new
                        {
                            PostId = 6,
                            CategoryId = 1,
                            Content = "This is post 6 and it has some very interesting content.",
                            Title = "Post 6",
                            UserId = 1
                        });
                });

            modelBuilder.Entity("aspnetserver.Data.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Email = "test@test.com",
                            Name = "Barney Dino"
                        },
                        new
                        {
                            UserId = 2,
                            Email = "test2@test.com",
                            Name = "Danny Dino"
                        },
                        new
                        {
                            UserId = 3,
                            Email = "test3@test.com",
                            Name = "Billy Bob"
                        });
                });

            modelBuilder.Entity("aspnetserver.Data.Models.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RoleId = "Default",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            RoleId = "Default",
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            RoleId = "Admin",
                            UserId = 3
                        });
                });

            modelBuilder.Entity("aspnetserver.Data.Models.Comment", b =>
                {
                    b.HasOne("aspnetserver.Data.Models.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("aspnetserver.Data.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("aspnetserver.Data.Models.Post", b =>
                {
                    b.HasOne("aspnetserver.Data.Models.Category", "Category")
                        .WithMany("Posts")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("aspnetserver.Data.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("aspnetserver.Data.Models.UserRole", b =>
                {
                    b.HasOne("aspnetserver.Data.Models.User", "User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("aspnetserver.Data.Models.Category", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("aspnetserver.Data.Models.Post", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("aspnetserver.Data.Models.User", b =>
                {
                    b.Navigation("Roles");
                });
#pragma warning restore 612, 618
        }
    }
}
