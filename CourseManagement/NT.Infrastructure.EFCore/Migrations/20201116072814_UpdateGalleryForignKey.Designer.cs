﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NT.CM.Infrastructure.EFCore;

namespace NT.CM.Infrastructure.EFCore.Migrations
{
    [DbContext(typeof(NTContext))]
    [Migration("20201116072814_UpdateGalleryForignKey")]
    partial class UpdateGalleryForignKey
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.BaseInfoAgg.BaseInfo", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("ParentID")
                        .HasColumnType("bigint");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000);

                    b.Property<long?>("TypeID")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("ParentID");

                    b.HasIndex("TypeID");

                    b.ToTable("Tbl_Base_Info");
                });

            modelBuilder.Entity("NT.CM.Domain.CandidateAgg.Candidate", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityOfBirth")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("CompanyID")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DOB")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("NationalityID")
                        .HasColumnType("bigint");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("CompanyID");

                    b.HasIndex("NationalityID");

                    b.ToTable("Tbl_Candidate");
                });

            modelBuilder.Entity("NT.CM.Domain.CandidateCourseInstructorAgg.CandidateCourseInstructor", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CandidateID")
                        .HasColumnType("bigint");

                    b.Property<long>("Course_InstructorID")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RegistrationDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("CandidateID");

                    b.HasIndex("Course_InstructorID");

                    b.ToTable("Tbl_Candidate_Course_Instructor");
                });

            modelBuilder.Entity("NT.CM.Domain.CompanyAgg.Company", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("BaseInfoID")
                        .HasColumnType("bigint");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsClient")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPartner")
                        .HasColumnType("bit");

                    b.Property<string>("Logo")
                        .HasColumnType("varbinary(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Website")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("BaseInfoID");

                    b.ToTable("Tbl_Companies");
                });

            modelBuilder.Entity("NT.CM.Domain.CourseAgg.Course", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Audience")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("CategoryID")
                        .HasColumnType("bigint");

                    b.Property<long?>("Cost")
                        .HasColumnType("bigint");

                    b.Property<byte?>("CourseCatalog")
                        .HasColumnType("tinyint");

                    b.Property<long?>("CourseLevel")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DailyPlan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<bool>("IsPrivate")
                        .HasColumnType("bit");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("CourseLevel");

                    b.ToTable("Tbl_Course");
                });

            modelBuilder.Entity("NT.CM.Domain.CourseCandidateInstructorDetailsAgg.CourseCandidateInstructorDetails", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CCI_ID")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<byte>("DocumentIMG")
                        .HasColumnType("tinyint");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<long>("TypeID")
                        .HasColumnType("bigint");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CCI_ID");

                    b.HasIndex("TypeID");

                    b.ToTable("Tbl_Course_Candidate_Instuctor_Details");
                });

            modelBuilder.Entity("NT.CM.Domain.CourseInstructorAgg.CourseInstructor", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<long>("CourseID")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("InstructorID")
                        .HasColumnType("bigint");

                    b.Property<long>("Location")
                        .HasColumnType("bigint");

                    b.Property<string>("SDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Venue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CourseID");

                    b.HasIndex("InstructorID");

                    b.HasIndex("Location");

                    b.ToTable("Tbl_Course_Instructor");
                });

            modelBuilder.Entity("NT.CM.Domain.GalleryAgg.Gallery", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("ParentID")
                        .HasColumnType("bigint");

                    b.Property<string>("PhotoAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("TypeID")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("ParentID");

                    b.HasIndex("TypeID");

                    b.ToTable("Tbl_Gallery");
                });

            modelBuilder.Entity("NT.CM.Domain.InstructorAgg.Instructor", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EducationLevel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Resume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("Tbl_Instructor");
                });

            modelBuilder.Entity("Domain.BaseInfoAgg.BaseInfo", b =>
                {
                    b.HasOne("Domain.BaseInfoAgg.BaseInfo", "Parent")
                        .WithMany("ParentChilds")
                        .HasForeignKey("ParentID");

                    b.HasOne("Domain.BaseInfoAgg.BaseInfo", "Type")
                        .WithMany("TypeChilds")
                        .HasForeignKey("TypeID");
                });

            modelBuilder.Entity("NT.CM.Domain.CandidateAgg.Candidate", b =>
                {
                    b.HasOne("NT.CM.Domain.CompanyAgg.Company", "Company")
                        .WithMany("Candidates")
                        .HasForeignKey("CompanyID");

                    b.HasOne("Domain.BaseInfoAgg.BaseInfo", "BaseInfo")
                        .WithMany("Candidates")
                        .HasForeignKey("NationalityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NT.CM.Domain.CandidateCourseInstructorAgg.CandidateCourseInstructor", b =>
                {
                    b.HasOne("NT.CM.Domain.CandidateAgg.Candidate", "Candidates")
                        .WithMany("CandidateCourseInstructors")
                        .HasForeignKey("CandidateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NT.CM.Domain.CourseInstructorAgg.CourseInstructor", "CourseInstructors")
                        .WithMany("CandidateCourseInstructors")
                        .HasForeignKey("Course_InstructorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NT.CM.Domain.CompanyAgg.Company", b =>
                {
                    b.HasOne("Domain.BaseInfoAgg.BaseInfo", null)
                        .WithMany("Companies")
                        .HasForeignKey("BaseInfoID");
                });

            modelBuilder.Entity("NT.CM.Domain.CourseAgg.Course", b =>
                {
                    b.HasOne("Domain.BaseInfoAgg.BaseInfo", "BaseInfoCategory")
                        .WithMany("CourseCategoriers")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.BaseInfoAgg.BaseInfo", "BaseInfoCourseLevel")
                        .WithMany("CourseLevels")
                        .HasForeignKey("CourseLevel");
                });

            modelBuilder.Entity("NT.CM.Domain.CourseCandidateInstructorDetailsAgg.CourseCandidateInstructorDetails", b =>
                {
                    b.HasOne("NT.CM.Domain.CandidateCourseInstructorAgg.CandidateCourseInstructor", "CandidateCourseInstructor")
                        .WithMany("CourseCandidateInstructorDetailss")
                        .HasForeignKey("CCI_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.BaseInfoAgg.BaseInfo", "BaseInfo")
                        .WithMany("CourseCandidateInstructorDetails")
                        .HasForeignKey("TypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NT.CM.Domain.CourseInstructorAgg.CourseInstructor", b =>
                {
                    b.HasOne("NT.CM.Domain.CourseAgg.Course", "Course")
                        .WithMany("CourseInstructors")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NT.CM.Domain.InstructorAgg.Instructor", "Instructor")
                        .WithMany("CourseInstructors")
                        .HasForeignKey("InstructorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.BaseInfoAgg.BaseInfo", "BaseInfo")
                        .WithMany("CourseInstructors")
                        .HasForeignKey("Location")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NT.CM.Domain.GalleryAgg.Gallery", b =>
                {
                    b.HasOne("NT.CM.Domain.GalleryAgg.Gallery", "gallery")
                        .WithMany("Galleries")
                        .HasForeignKey("ParentID");

                    b.HasOne("Domain.BaseInfoAgg.BaseInfo", "BaseInfo")
                        .WithMany("Galleries")
                        .HasForeignKey("TypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
