﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231204192248_UpdateFKUnits2")]
    partial class UpdateFKUnits2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API.Entities.Clients", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PropertyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("PropertyId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("API.Entities.Condominiums", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("Condominiums");
                });

            modelBuilder.Entity("API.Entities.Maintenances", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at");

                    b.Property<bool>("IsSolved")
                        .HasColumnType("bit");

                    b.Property<string>("ProblemDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UnitID")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("UnitID");

                    b.ToTable("Maintenances");
                });

            modelBuilder.Entity("API.Entities.Properties", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at");

                    b.Property<int?>("UnitId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("UnitId");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("API.Entities.Units", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CondominiumId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at");

                    b.Property<int?>("MaintenanceId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PropertyId")
                        .HasColumnType("int");

                    b.Property<int>("TenantClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TenantFinishedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TenantStartedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("CondominiumId");

                    b.HasIndex("MaintenanceId");

                    b.HasIndex("PropertyId");

                    b.HasIndex("TenantClientId");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("API.Entities.Clients", b =>
                {
                    b.HasOne("API.Entities.Properties", "Property")
                        .WithMany()
                        .HasForeignKey("PropertyId");

                    b.Navigation("Property");
                });

            modelBuilder.Entity("API.Entities.Maintenances", b =>
                {
                    b.HasOne("API.Entities.Units", "Unity")
                        .WithMany("Maintenances")
                        .HasForeignKey("UnitID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Unity");
                });

            modelBuilder.Entity("API.Entities.Properties", b =>
                {
                    b.HasOne("API.Entities.Clients", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId");

                    b.HasOne("API.Entities.Units", "Units")
                        .WithMany()
                        .HasForeignKey("UnitId");

                    b.Navigation("Client");

                    b.Navigation("Units");
                });

            modelBuilder.Entity("API.Entities.Units", b =>
                {
                    b.HasOne("API.Entities.Condominiums", "Condominium")
                        .WithMany("Units")
                        .HasForeignKey("CondominiumId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("API.Entities.Maintenances", "Maintenance")
                        .WithMany()
                        .HasForeignKey("MaintenanceId");

                    b.HasOne("API.Entities.Properties", "Property")
                        .WithMany()
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.Clients", "TenantClient")
                        .WithMany("RentUnits")
                        .HasForeignKey("TenantClientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Condominium");

                    b.Navigation("Maintenance");

                    b.Navigation("Property");

                    b.Navigation("TenantClient");
                });

            modelBuilder.Entity("API.Entities.Clients", b =>
                {
                    b.Navigation("RentUnits");
                });

            modelBuilder.Entity("API.Entities.Condominiums", b =>
                {
                    b.Navigation("Units");
                });

            modelBuilder.Entity("API.Entities.Units", b =>
                {
                    b.Navigation("Maintenances");
                });
#pragma warning restore 612, 618
        }
    }
}
