﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PruebaTecnicaDotNet.Server.Data;

#nullable disable

namespace PruebaTecnicaDotNet.Server.Migrations
{
    [DbContext(typeof(PruebaDbContext))]
    [Migration("20221119201721_M1")]
    partial class M1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PruebaTecnicaDotNet.Server.Models.Customers", b =>
                {
                    b.Property<int>("cId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("cId"));

                    b.Property<string>("cLastName1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cLastName2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cName1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cName2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("cId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("PruebaTecnicaDotNet.Server.Models.CustomersPhones", b =>
                {
                    b.Property<int>("cpId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("cpId"));

                    b.Property<int>("cId")
                        .HasColumnType("int");

                    b.Property<string>("cpPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("cpId");

                    b.HasIndex("cId");

                    b.ToTable("CustomersPhones");
                });

            modelBuilder.Entity("PruebaTecnicaDotNet.Server.Models.CustomersPhones", b =>
                {
                    b.HasOne("PruebaTecnicaDotNet.Server.Models.Customers", "Customers")
                        .WithMany("CustomersPhones")
                        .HasForeignKey("cId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customers");
                });

            modelBuilder.Entity("PruebaTecnicaDotNet.Server.Models.Customers", b =>
                {
                    b.Navigation("CustomersPhones");
                });
#pragma warning restore 612, 618
        }
    }
}