﻿// <auto-generated />
using System;
using BerthApiBeta.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BerthApiBeta.Migrations
{
    [DbContext(typeof(BerthApiBetaContext))]
    partial class BerthApiBetaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-preview3-35497")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BerthApiBeta.Models.RaspberryRecord", b =>
                {
                    b.Property<int>("RecordId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateTime")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<double>("Humudity");

                    b.Property<double>("Pressure");

                    b.Property<double>("Temperature");

                    b.Property<int>("UserId");

                    b.HasKey("RecordId");

                    b.HasIndex("UserId");

                    b.ToTable("RaspberryRecord");
                });

            modelBuilder.Entity("BerthApiBeta.Models.Record", b =>
                {
                    b.Property<int>("RecordId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double?>("BPDiastolic");

                    b.Property<double?>("BPSystolic");

                    b.Property<double?>("BodyTemperature");

                    b.Property<double?>("CarbonMonoxide");

                    b.Property<double?>("Dust");

                    b.Property<double?>("Fluor");

                    b.Property<int?>("HeartBeatPerSecond");

                    b.Property<double>("Lat");

                    b.Property<double>("Long");

                    b.Property<double?>("Nitrogen");

                    b.Property<double?>("Ozone");

                    b.Property<DateTime>("RecordTime")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<double?>("Sulphur");

                    b.Property<int>("UserID");

                    b.HasKey("RecordId");

                    b.HasIndex("UserID");

                    b.ToTable("Record");
                });

            modelBuilder.Entity("BerthApiBeta.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password");

                    b.Property<string>("Username");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("BerthApiBeta.Models.RaspberryRecord", b =>
                {
                    b.HasOne("BerthApiBeta.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BerthApiBeta.Models.Record", b =>
                {
                    b.HasOne("BerthApiBeta.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
