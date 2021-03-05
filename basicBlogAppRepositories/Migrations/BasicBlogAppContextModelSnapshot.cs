﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using basicBlogAppRepository.Data;

namespace basicBlogAppRepositories.Migrations
{
    [DbContext(typeof(BasicBlogAppContext))]
    partial class BasicBlogAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("basicBlogAppModels.Comment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CommentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PostId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("basicBlogAppModels.Post", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ApprovalDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Approver")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("PublishDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WorkflowStates")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            AddedDate = new DateTime(2021, 3, 5, 17, 14, 25, 712, DateTimeKind.Local).AddTicks(9250),
                            Author = "Nicolas Garcia",
                            Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna ",
                            ModifiedDate = new DateTime(2021, 3, 5, 17, 14, 25, 713, DateTimeKind.Local).AddTicks(7061),
                            PublishDate = new DateTime(2021, 3, 5, 17, 14, 25, 713, DateTimeKind.Local).AddTicks(9835),
                            Title = "Post 1",
                            WorkflowStates = 0
                        },
                        new
                        {
                            ID = 2,
                            AddedDate = new DateTime(2021, 3, 5, 17, 14, 25, 714, DateTimeKind.Local).AddTicks(593),
                            Author = "Carolina Garcia",
                            Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna ",
                            ModifiedDate = new DateTime(2021, 3, 5, 17, 14, 25, 714, DateTimeKind.Local).AddTicks(605),
                            PublishDate = new DateTime(2021, 3, 5, 17, 14, 25, 714, DateTimeKind.Local).AddTicks(641),
                            Title = "Post 2",
                            WorkflowStates = 0
                        },
                        new
                        {
                            ID = 3,
                            AddedDate = new DateTime(2021, 3, 5, 17, 14, 25, 714, DateTimeKind.Local).AddTicks(652),
                            Author = "Alejandra Garcia",
                            Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna ",
                            ModifiedDate = new DateTime(2021, 3, 5, 17, 14, 25, 714, DateTimeKind.Local).AddTicks(652),
                            PublishDate = new DateTime(2021, 3, 5, 17, 14, 25, 714, DateTimeKind.Local).AddTicks(656),
                            Title = "Post 3",
                            WorkflowStates = 0
                        },
                        new
                        {
                            ID = 4,
                            AddedDate = new DateTime(2021, 3, 5, 17, 14, 25, 714, DateTimeKind.Local).AddTicks(656),
                            Author = "Trufa Garcia",
                            Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna ",
                            ModifiedDate = new DateTime(2021, 3, 5, 17, 14, 25, 714, DateTimeKind.Local).AddTicks(656),
                            PublishDate = new DateTime(2021, 3, 5, 17, 14, 25, 714, DateTimeKind.Local).AddTicks(656),
                            Title = "Post 4",
                            WorkflowStates = 0
                        });
                });

            modelBuilder.Entity("basicBlogAppModels.Comment", b =>
                {
                    b.HasOne("basicBlogAppModels.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
