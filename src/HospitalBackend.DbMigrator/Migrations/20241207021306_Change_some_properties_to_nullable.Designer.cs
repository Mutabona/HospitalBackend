﻿// <auto-generated />
using System;
using HospitalBackend.DbMigrator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HospitalBackend.DbMigrator.Migrations
{
    [DbContext(typeof(MigrationDbContext))]
    [Migration("20241207021306_Change_some_properties_to_nullable")]
    partial class Change_some_properties_to_nullable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HospitalBackend.Domain.Analyzes.Analysis", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AppointmentId")
                        .HasColumnType("uuid");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<Guid>("HistoryId")
                        .HasColumnType("uuid");

                    b.Property<string>("Result")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentId")
                        .IsUnique();

                    b.HasIndex("HistoryId");

                    b.ToTable("Analyzes", (string)null);
                });

            modelBuilder.Entity("HospitalBackend.Domain.Appointments.Appointment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<Guid>("ExaminationId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ExaminationId");

                    b.ToTable("Appointments", (string)null);
                });

            modelBuilder.Entity("HospitalBackend.Domain.Examinations.Examination", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Conclusion")
                        .HasColumnType("text");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<Guid>("HistoryId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("HistoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Examinations", (string)null);
                });

            modelBuilder.Entity("HospitalBackend.Domain.Histories.History", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateOnly>("ArriveDate")
                        .HasColumnType("date");

                    b.Property<string>("Complaints")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly?>("DepartureDate")
                        .HasColumnType("date");

                    b.Property<string>("Diagnosis")
                        .HasColumnType("text");

                    b.Property<string>("DiseaseAnamnesis")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Epicrisis")
                        .HasColumnType("text");

                    b.Property<string>("LifeAnamnesis")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.HasIndex("UserId");

                    b.ToTable("Histories", (string)null);
                });

            modelBuilder.Entity("HospitalBackend.Domain.Marks.Mark", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AppointmentId")
                        .HasColumnType("uuid");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<bool>("IsDone")
                        .HasColumnType("boolean");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentId")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Marks", (string)null);
                });

            modelBuilder.Entity("HospitalBackend.Domain.Patients.Patient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("FIO")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Passport")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Patients", (string)null);
                });

            modelBuilder.Entity("HospitalBackend.Domain.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("FIO")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Login")
                        .IsUnique();

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("HospitalBackend.Domain.Analyzes.Analysis", b =>
                {
                    b.HasOne("HospitalBackend.Domain.Appointments.Appointment", "Appointment")
                        .WithOne("Analysis")
                        .HasForeignKey("HospitalBackend.Domain.Analyzes.Analysis", "AppointmentId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.HasOne("HospitalBackend.Domain.Histories.History", "History")
                        .WithMany("Analyzes")
                        .HasForeignKey("HistoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Appointment");

                    b.Navigation("History");
                });

            modelBuilder.Entity("HospitalBackend.Domain.Appointments.Appointment", b =>
                {
                    b.HasOne("HospitalBackend.Domain.Examinations.Examination", "Examination")
                        .WithMany("Appointments")
                        .HasForeignKey("ExaminationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Examination");
                });

            modelBuilder.Entity("HospitalBackend.Domain.Examinations.Examination", b =>
                {
                    b.HasOne("HospitalBackend.Domain.Histories.History", "History")
                        .WithMany("Examinations")
                        .HasForeignKey("HistoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalBackend.Domain.Users.User", "User")
                        .WithMany("Examinations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("History");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HospitalBackend.Domain.Histories.History", b =>
                {
                    b.HasOne("HospitalBackend.Domain.Patients.Patient", "Patient")
                        .WithMany("Histories")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalBackend.Domain.Users.User", "User")
                        .WithMany("Histories")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Patient");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HospitalBackend.Domain.Marks.Mark", b =>
                {
                    b.HasOne("HospitalBackend.Domain.Appointments.Appointment", "Appointment")
                        .WithOne("Mark")
                        .HasForeignKey("HospitalBackend.Domain.Marks.Mark", "AppointmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalBackend.Domain.Users.User", "User")
                        .WithMany("Marks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("Appointment");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HospitalBackend.Domain.Appointments.Appointment", b =>
                {
                    b.Navigation("Analysis");

                    b.Navigation("Mark");
                });

            modelBuilder.Entity("HospitalBackend.Domain.Examinations.Examination", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("HospitalBackend.Domain.Histories.History", b =>
                {
                    b.Navigation("Analyzes");

                    b.Navigation("Examinations");
                });

            modelBuilder.Entity("HospitalBackend.Domain.Patients.Patient", b =>
                {
                    b.Navigation("Histories");
                });

            modelBuilder.Entity("HospitalBackend.Domain.Users.User", b =>
                {
                    b.Navigation("Examinations");

                    b.Navigation("Histories");

                    b.Navigation("Marks");
                });
#pragma warning restore 612, 618
        }
    }
}
