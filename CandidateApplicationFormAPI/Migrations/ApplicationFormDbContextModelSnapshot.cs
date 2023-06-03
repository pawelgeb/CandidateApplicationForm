﻿// <auto-generated />
using System;
using CandidateApplicationFormAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CandidateApplicationFormAPI.Migrations
{
    [DbContext(typeof(ApplicationFormDbContext))]
    partial class ApplicationFormDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CandidateApplicationFormAPI.Entities.ApplicationForm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("LevelOfEducation")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("ApplicationForms");
                });

            modelBuilder.Entity("CandidateApplicationFormAPI.Entities.CoverLetter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ApplicationFormId")
                        .HasColumnType("integer");

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte[]>("Data")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationFormId")
                        .IsUnique();

                    b.ToTable("CoverLetters");
                });

            modelBuilder.Entity("CandidateApplicationFormAPI.Entities.PreviousJob", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ApplicationFormId")
                        .HasColumnType("integer");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("EndJobDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("StartJobDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationFormId");

                    b.ToTable("PreviousJobs");
                });

            modelBuilder.Entity("CandidateApplicationFormAPI.Entities.Resume", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ApplicationFormId")
                        .HasColumnType("integer");

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte[]>("Data")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationFormId");

                    b.ToTable("Resumes");
                });

            modelBuilder.Entity("CandidateApplicationFormAPI.Entities.CoverLetter", b =>
                {
                    b.HasOne("CandidateApplicationFormAPI.Entities.ApplicationForm", "ApplicationForm")
                        .WithOne("CoverLetters")
                        .HasForeignKey("CandidateApplicationFormAPI.Entities.CoverLetter", "ApplicationFormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationForm");
                });

            modelBuilder.Entity("CandidateApplicationFormAPI.Entities.PreviousJob", b =>
                {
                    b.HasOne("CandidateApplicationFormAPI.Entities.ApplicationForm", "ApplicationForm")
                        .WithMany("PreviousJobs")
                        .HasForeignKey("ApplicationFormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationForm");
                });

            modelBuilder.Entity("CandidateApplicationFormAPI.Entities.Resume", b =>
                {
                    b.HasOne("CandidateApplicationFormAPI.Entities.ApplicationForm", "ApplicationForm")
                        .WithMany("Resumes")
                        .HasForeignKey("ApplicationFormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationForm");
                });

            modelBuilder.Entity("CandidateApplicationFormAPI.Entities.ApplicationForm", b =>
                {
                    b.Navigation("CoverLetters")
                        .IsRequired();

                    b.Navigation("PreviousJobs");

                    b.Navigation("Resumes");
                });
#pragma warning restore 612, 618
        }
    }
}
