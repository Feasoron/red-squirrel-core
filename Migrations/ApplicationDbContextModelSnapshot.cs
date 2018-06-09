﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RedSquirrel.Data;

namespace redsquirrelcore.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("RedSquirrel.Data.Entities.Food", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<long?>("OwnerUserId");

                    b.HasKey("Id");

                    b.HasIndex("OwnerUserId");

                    b.ToTable("Food");
                });

            modelBuilder.Entity("RedSquirrel.Data.Entities.FoodConversion", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("FirstUnitId");

                    b.Property<long?>("FoodId");

                    b.Property<long?>("OwnerUserId");

                    b.Property<double>("Ratio");

                    b.Property<long?>("SecondUnitId");

                    b.HasKey("Id");

                    b.HasIndex("FirstUnitId");

                    b.HasIndex("FoodId");

                    b.HasIndex("OwnerUserId");

                    b.HasIndex("SecondUnitId");

                    b.ToTable("FoodConversion");
                });

            modelBuilder.Entity("RedSquirrel.Data.Entities.Inventory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Amount");

                    b.Property<long?>("FoodId");

                    b.Property<long?>("LocationId");

                    b.Property<long?>("OwnerUserId");

                    b.Property<long?>("UnitId");

                    b.HasKey("Id");

                    b.HasIndex("FoodId");

                    b.HasIndex("LocationId");

                    b.HasIndex("OwnerUserId");

                    b.HasIndex("UnitId");

                    b.ToTable("Inventory");
                });

            modelBuilder.Entity("RedSquirrel.Data.Entities.Location", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<long?>("OwnerUserId");

                    b.HasKey("Id");

                    b.HasIndex("OwnerUserId");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("RedSquirrel.Data.Entities.Unit", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<long?>("OwnerUserId");

                    b.HasKey("Id");

                    b.HasIndex("OwnerUserId");

                    b.ToTable("Unit");
                });

            modelBuilder.Entity("RedSquirrel.Data.Entities.UnitConversion", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("FirstUnitId");

                    b.Property<long?>("OwnerUserId");

                    b.Property<double>("Ratio");

                    b.Property<long?>("SecondUnitId");

                    b.HasKey("Id");

                    b.HasIndex("FirstUnitId");

                    b.HasIndex("OwnerUserId");

                    b.HasIndex("SecondUnitId");

                    b.ToTable("UnitConversion");
                });

            modelBuilder.Entity("RedSquirrel.Data.Entities.User", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("ExternalUserId");

                    b.Property<string>("Name");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RedSquirrel.Data.Entities.Food", b =>
                {
                    b.HasOne("RedSquirrel.Data.Entities.User", "Owner")
                        .WithMany("Foods")
                        .HasForeignKey("OwnerUserId");
                });

            modelBuilder.Entity("RedSquirrel.Data.Entities.FoodConversion", b =>
                {
                    b.HasOne("RedSquirrel.Data.Entities.Unit", "FirstUnit")
                        .WithMany()
                        .HasForeignKey("FirstUnitId");

                    b.HasOne("RedSquirrel.Data.Entities.Food", "Food")
                        .WithMany()
                        .HasForeignKey("FoodId");

                    b.HasOne("RedSquirrel.Data.Entities.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerUserId");

                    b.HasOne("RedSquirrel.Data.Entities.Unit", "SecondUnit")
                        .WithMany()
                        .HasForeignKey("SecondUnitId");
                });

            modelBuilder.Entity("RedSquirrel.Data.Entities.Inventory", b =>
                {
                    b.HasOne("RedSquirrel.Data.Entities.Food", "Food")
                        .WithMany()
                        .HasForeignKey("FoodId");

                    b.HasOne("RedSquirrel.Data.Entities.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");

                    b.HasOne("RedSquirrel.Data.Entities.User", "Owner")
                        .WithMany("Inventories")
                        .HasForeignKey("OwnerUserId");

                    b.HasOne("RedSquirrel.Data.Entities.Unit", "Unit")
                        .WithMany()
                        .HasForeignKey("UnitId");
                });

            modelBuilder.Entity("RedSquirrel.Data.Entities.Location", b =>
                {
                    b.HasOne("RedSquirrel.Data.Entities.User", "Owner")
                        .WithMany("Locations")
                        .HasForeignKey("OwnerUserId");
                });

            modelBuilder.Entity("RedSquirrel.Data.Entities.Unit", b =>
                {
                    b.HasOne("RedSquirrel.Data.Entities.User", "Owner")
                        .WithMany("Units")
                        .HasForeignKey("OwnerUserId");
                });

            modelBuilder.Entity("RedSquirrel.Data.Entities.UnitConversion", b =>
                {
                    b.HasOne("RedSquirrel.Data.Entities.Unit", "FirstUnit")
                        .WithMany()
                        .HasForeignKey("FirstUnitId");

                    b.HasOne("RedSquirrel.Data.Entities.User", "Owner")
                        .WithMany("UnitConversions")
                        .HasForeignKey("OwnerUserId");

                    b.HasOne("RedSquirrel.Data.Entities.Unit", "SecondUnit")
                        .WithMany()
                        .HasForeignKey("SecondUnitId");
                });
#pragma warning restore 612, 618
        }
    }
}
