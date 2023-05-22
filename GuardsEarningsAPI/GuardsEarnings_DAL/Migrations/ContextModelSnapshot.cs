﻿// <auto-generated />
using System;
using GuardsEarnings_DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GuardsEarnings_DAL.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GuardsEarnings_DAL.Models.Guard", b =>
                {
                    b.Property<long>("GuardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("GuardId"), 1L, 1);

                    b.Property<string>("Cellphone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direction")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Imagen")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GuardId");

                    b.ToTable("Guards");
                });

            modelBuilder.Entity("GuardsEarnings_DAL.Models.Journey", b =>
                {
                    b.Property<long>("JourneyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("JourneyId"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.HasKey("JourneyId");

                    b.ToTable("Journeys");
                });

            modelBuilder.Entity("GuardsEarnings_DAL.Models.Target", b =>
                {
                    b.Property<long>("TargetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("TargetId"), 1L, 1);

                    b.Property<string>("Direction")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("MapLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Payment")
                        .HasColumnType("real");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TargetId");

                    b.ToTable("Targets");
                });

            modelBuilder.Entity("GuardsEarnings_DAL.Models.Work", b =>
                {
                    b.Property<long>("WorkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("WorkId"), 1L, 1);

                    b.Property<string>("EnterTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("GuardId")
                        .HasColumnType("bigint");

                    b.Property<long?>("JourneyId")
                        .HasColumnType("bigint");

                    b.Property<string>("OutTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("Payment")
                        .HasColumnType("real");

                    b.Property<long?>("TargetId")
                        .HasColumnType("bigint");

                    b.HasKey("WorkId");

                    b.HasIndex("GuardId");

                    b.HasIndex("JourneyId");

                    b.HasIndex("TargetId");

                    b.ToTable("Works");
                });

            modelBuilder.Entity("GuardsEarnings_DAL.Models.Work", b =>
                {
                    b.HasOne("GuardsEarnings_DAL.Models.Guard", "Guard")
                        .WithMany("Works")
                        .HasForeignKey("GuardId");

                    b.HasOne("GuardsEarnings_DAL.Models.Journey", "Journey")
                        .WithMany("Works")
                        .HasForeignKey("JourneyId");

                    b.HasOne("GuardsEarnings_DAL.Models.Target", "Target")
                        .WithMany("Works")
                        .HasForeignKey("TargetId");

                    b.Navigation("Guard");

                    b.Navigation("Journey");

                    b.Navigation("Target");
                });

            modelBuilder.Entity("GuardsEarnings_DAL.Models.Guard", b =>
                {
                    b.Navigation("Works");
                });

            modelBuilder.Entity("GuardsEarnings_DAL.Models.Journey", b =>
                {
                    b.Navigation("Works");
                });

            modelBuilder.Entity("GuardsEarnings_DAL.Models.Target", b =>
                {
                    b.Navigation("Works");
                });
#pragma warning restore 612, 618
        }
    }
}
