﻿// <auto-generated />
using System;
using DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataBase.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20230124041402_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DataBase.Models.AppointmentModel", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("integer");

                NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                b.Property<int>("DoctorId")
                    .HasColumnType("integer");

                b.Property<DateTime>("EndTime")
                    .HasColumnType("timestamp with time zone");

                b.Property<int>("PatientId")
                    .HasColumnType("integer");

                b.Property<DateTime>("StartTime")
                    .HasColumnType("timestamp with time zone");

                b.HasKey("Id");

                b.ToTable("Appointments");
            });

            modelBuilder.Entity("DataBase.Models.DoctorModel", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("integer");

                NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                b.Property<string>("FullName")
                    .IsRequired()
                    .HasColumnType("text");

                b.Property<int>("SpecializationId")
                    .HasColumnType("integer");

                b.HasKey("Id");

                b.HasIndex("SpecializationId");

                b.ToTable("Doctors");
            });

            modelBuilder.Entity("DataBase.Models.SchenduleModel", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("integer");

                NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                b.Property<int>("DoctorId")
                    .HasColumnType("integer");

                b.Property<DateTime>("EndTime")
                    .HasColumnType("timestamp with time zone");

                b.Property<DateTime>("StartTime")
                    .HasColumnType("timestamp with time zone");

                b.HasKey("Id");

                b.ToTable("Schendules");
            });

            modelBuilder.Entity("DataBase.Models.SpecializationModel", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("integer");

                NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("text");

                b.HasKey("Id");

                b.ToTable("Specializations");
            });

            modelBuilder.Entity("DataBase.Models.UserModel", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("integer");

                NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                b.Property<string>("FullName")
                    .IsRequired()
                    .HasColumnType("text");

                b.Property<string>("Password")
                    .IsRequired()
                    .HasColumnType("text");

                b.Property<string>("PhoneNumber")
                    .IsRequired()
                    .HasColumnType("text");

                b.Property<int>("Role")
                    .HasColumnType("integer");

                b.Property<string>("Username")
                    .IsRequired()
                    .HasColumnType("text");

                b.HasKey("Id");

                b.ToTable("Users");
            });

            modelBuilder.Entity("DataBase.Models.DoctorModel", b =>
            {
                b.HasOne("DataBase.Models.SpecializationModel", "Specialization")
                    .WithMany()
                    .HasForeignKey("SpecializationId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Specialization");
            });
#pragma warning restore 612, 618
        }
    }
}
