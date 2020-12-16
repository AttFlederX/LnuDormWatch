﻿// <auto-generated />
using System;
using LDW.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LDW.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20201216221856_AddDormitoryLocation")]
    partial class AddDormitoryLocation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LDW.Domain.Entities.DormitoryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Latitude")
                        .HasColumnType("float");

                    b.Property<double?>("Longitude")
                        .HasColumnType("float");

                    b.Property<int>("Number")
                        .HasColumnType("int")
                        .HasMaxLength(3);

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.ToTable("Dormitories");
                });

            modelBuilder.Entity("LDW.Domain.Entities.DormitoryPictureEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DormitoryId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasMaxLength(5000);

                    b.Property<bool>("IsMain")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("DormitoryId");

                    b.ToTable("DormitoryPictures");
                });

            modelBuilder.Entity("LDW.Domain.Entities.ForumSectionEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("AuthorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("SectionDescription")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("SectionTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("ForumSections");
                });

            modelBuilder.Entity("LDW.Domain.Entities.ForumThreadEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("AuthorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<Guid>("ForumSectionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ThreadBody")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasMaxLength(5000);

                    b.Property<string>("ThreadTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("ForumSectionId");

                    b.ToTable("ForumThreads");
                });

            modelBuilder.Entity("LDW.Domain.Entities.ForumThreadReplyEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("AuthorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<Guid>("ParentForumThreadId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ParentForumThreadReplyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ReplyBody")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasMaxLength(5000);

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("ParentForumThreadId");

                    b.HasIndex("ParentForumThreadReplyId");

                    b.ToTable("ForumThreadReplies");
                });

            modelBuilder.Entity("LDW.Domain.Entities.UserRefEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.ToTable("UserRefs");
                });

            modelBuilder.Entity("LDW.Domain.Entities.DormitoryPictureEntity", b =>
                {
                    b.HasOne("LDW.Domain.Entities.DormitoryEntity", "Dormitory")
                        .WithMany("DormitoryPictures")
                        .HasForeignKey("DormitoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LDW.Domain.Entities.ForumSectionEntity", b =>
                {
                    b.HasOne("LDW.Domain.Entities.UserRefEntity", "Author")
                        .WithMany("ForumSections")
                        .HasForeignKey("AuthorId");
                });

            modelBuilder.Entity("LDW.Domain.Entities.ForumThreadEntity", b =>
                {
                    b.HasOne("LDW.Domain.Entities.UserRefEntity", "Author")
                        .WithMany("ForumThreads")
                        .HasForeignKey("AuthorId")
                        .IsRequired();

                    b.HasOne("LDW.Domain.Entities.ForumSectionEntity", "ForumSection")
                        .WithMany("ForumThreads")
                        .HasForeignKey("ForumSectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LDW.Domain.Entities.ForumThreadReplyEntity", b =>
                {
                    b.HasOne("LDW.Domain.Entities.UserRefEntity", "Author")
                        .WithMany("ForumThreadReplies")
                        .HasForeignKey("AuthorId")
                        .IsRequired();

                    b.HasOne("LDW.Domain.Entities.ForumThreadEntity", "ForumThread")
                        .WithMany("ForumThreadReplies")
                        .HasForeignKey("ParentForumThreadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LDW.Domain.Entities.ForumThreadReplyEntity", "ParentForumThreadReply")
                        .WithMany("ForumThreadReplies")
                        .HasForeignKey("ParentForumThreadReplyId");
                });
#pragma warning restore 612, 618
        }
    }
}
