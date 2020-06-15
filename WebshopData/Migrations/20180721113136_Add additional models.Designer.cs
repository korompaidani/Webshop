﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebshopData;

namespace WebshopData.Migrations
{
    [DbContext(typeof(WebshopContext))]
    [Migration("20180721113136_Add additional models")]
    partial class Addadditionalmodels
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebshopData.Models.Category", b =>
                {
                    b.Property<string>("CategoryKind")
                        .ValueGeneratedOnAdd();

                    b.HasKey("CategoryKind");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("WebshopData.Models.Person", b =>
                {
                    b.Property<string>("Email")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("PersonName");

                    b.HasKey("Email");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("WebshopData.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryKind")
                        .IsRequired();

                    b.Property<string>("Description");

                    b.Property<string>("ItemName")
                        .IsRequired();

                    b.Property<string>("PersonEmail")
                        .IsRequired();

                    b.Property<string>("PersonName");

                    b.Property<float>("Price");

                    b.Property<DateTime>("UploadTime");

                    b.HasKey("Id");

                    b.HasIndex("CategoryKind");

                    b.HasIndex("PersonEmail");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("WebshopData.Models.Product", b =>
                {
                    b.HasOne("WebshopData.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryKind")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebshopData.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonEmail")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
