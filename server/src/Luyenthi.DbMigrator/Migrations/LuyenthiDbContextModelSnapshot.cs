﻿// <auto-generated />
using System;
using Luyenthi.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Luyenthi.DbMigrator.Migrations
{
    [DbContext(typeof(LuyenthiDbContext))]
    partial class LuyenthiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.10");

            modelBuilder.Entity("GradeSubjects", b =>
                {
                    b.Property<Guid>("GradeId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("char(36)");

                    b.HasKey("GradeId", "SubjectId");

                    b.HasIndex("SubjectId");

                    b.ToTable("GradeSubjects");
                });

            modelBuilder.Entity("Luyenthi.Domain.Chapter", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("GradeId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("OrderNumber")
                        .HasColumnType("longtext");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("GradeId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Chapters");
                });

            modelBuilder.Entity("Luyenthi.Domain.Document", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<int>("DocumentType")
                        .HasColumnType("int");

                    b.Property<int>("Form")
                        .HasColumnType("int");

                    b.Property<string>("GoogleDocId")
                        .HasColumnType("longtext");

                    b.Property<Guid>("GradeId")
                        .HasColumnType("char(36)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsApprove")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("NameNomarlize")
                        .HasColumnType("longtext");

                    b.Property<int>("ShuffleType")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Times")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("GradeId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("Luyenthi.Domain.DocumentHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("DocumentId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("NumberCorrect")
                        .HasColumnType("int");

                    b.Property<int>("NumberIncorrect")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("DocumentId");

                    b.ToTable("DocumentHistories");
                });

            modelBuilder.Entity("Luyenthi.Domain.Grade", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Code")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int>("OrderNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("Luyenthi.Domain.LevelQuestion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Code")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int>("OrderNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("LevelQuestions");
                });

            modelBuilder.Entity("Luyenthi.Domain.Question", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("ChapterId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Content")
                        .HasColumnType("longtext");

                    b.Property<string>("CorrectAnswer")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("GradeId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Introduction")
                        .HasColumnType("longtext");

                    b.Property<Guid?>("LevelId")
                        .HasColumnType("char(36)");

                    b.Property<int?>("NumberQuestion")
                        .HasColumnType("int");

                    b.Property<string>("Options")
                        .HasColumnType("longtext");

                    b.Property<int>("OrderNumber")
                        .HasColumnType("int");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Solve")
                        .HasColumnType("longtext");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid?>("SubjectId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("TemplateQuestionId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<Guid?>("UnitId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("ChapterId");

                    b.HasIndex("GradeId");

                    b.HasIndex("LevelId");

                    b.HasIndex("NumberQuestion");

                    b.HasIndex("ParentId");

                    b.HasIndex("SubjectId");

                    b.HasIndex("TemplateQuestionId");

                    b.HasIndex("Type");

                    b.HasIndex("UnitId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("Luyenthi.Domain.QuestionHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Answer")
                        .HasColumnType("longtext");

                    b.Property<int>("AnswerStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("DocumentHistoryId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("DocumentHistoryId");

                    b.HasIndex("QuestionId");

                    b.ToTable("QuestionHistories");
                });

            modelBuilder.Entity("Luyenthi.Domain.QuestionSet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("DocumentId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int>("OrderNumber")
                        .HasColumnType("int");

                    b.Property<bool>("Show")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("DocumentId");

                    b.ToTable("QuestionSets");
                });

            modelBuilder.Entity("Luyenthi.Domain.Subject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Code")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int>("OrderNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("Luyenthi.Domain.TemplateQuestion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("UnitId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("UnitId");

                    b.ToTable("TemplateQuestions");
                });

            modelBuilder.Entity("Luyenthi.Domain.Unit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ChapterId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("ChapterId");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("Luyenthi.Domain.User.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDay")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("char(36)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Provider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("char(36)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.HasIndex("Provider", "Email")
                        .IsUnique();

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("char(36)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("QuestionSetQuestion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("QuestionSetId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.HasIndex("QuestionSetId");

                    b.ToTable("QuestionSetQuestion");
                });

            modelBuilder.Entity("GradeSubjects", b =>
                {
                    b.HasOne("Luyenthi.Domain.Grade", null)
                        .WithMany()
                        .HasForeignKey("GradeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Luyenthi.Domain.Subject", null)
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Luyenthi.Domain.Chapter", b =>
                {
                    b.HasOne("Luyenthi.Domain.Grade", "Grade")
                        .WithMany()
                        .HasForeignKey("GradeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Luyenthi.Domain.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Grade");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("Luyenthi.Domain.Document", b =>
                {
                    b.HasOne("Luyenthi.Domain.Grade", "Grade")
                        .WithMany()
                        .HasForeignKey("GradeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Luyenthi.Domain.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Grade");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("Luyenthi.Domain.DocumentHistory", b =>
                {
                    b.HasOne("Luyenthi.Domain.User.ApplicationUser", "User")
                        .WithMany("DocumentHistories")
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Luyenthi.Domain.Document", "Document")
                        .WithMany("DocumentHistories")
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Document");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Luyenthi.Domain.Question", b =>
                {
                    b.HasOne("Luyenthi.Domain.Chapter", "Chapter")
                        .WithMany("Questions")
                        .HasForeignKey("ChapterId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Luyenthi.Domain.Grade", "Grade")
                        .WithMany("Questions")
                        .HasForeignKey("GradeId");

                    b.HasOne("Luyenthi.Domain.LevelQuestion", "Level")
                        .WithMany("Questions")
                        .HasForeignKey("LevelId");

                    b.HasOne("Luyenthi.Domain.Question", "Parent")
                        .WithMany("SubQuestions")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Luyenthi.Domain.Subject", "Subject")
                        .WithMany("Questions")
                        .HasForeignKey("SubjectId");

                    b.HasOne("Luyenthi.Domain.TemplateQuestion", "TemplateQuestion")
                        .WithMany("Questions")
                        .HasForeignKey("TemplateQuestionId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Luyenthi.Domain.Unit", "Unit")
                        .WithMany("Questions")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Chapter");

                    b.Navigation("Grade");

                    b.Navigation("Level");

                    b.Navigation("Parent");

                    b.Navigation("Subject");

                    b.Navigation("TemplateQuestion");

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("Luyenthi.Domain.QuestionHistory", b =>
                {
                    b.HasOne("Luyenthi.Domain.User.ApplicationUser", "User")
                        .WithMany("QuestionHistories")
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Luyenthi.Domain.DocumentHistory", "DocumentHistory")
                        .WithMany("QuestionHistories")
                        .HasForeignKey("DocumentHistoryId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Luyenthi.Domain.Question", "Question")
                        .WithMany("QuestionHistories")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DocumentHistory");

                    b.Navigation("Question");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Luyenthi.Domain.QuestionSet", b =>
                {
                    b.HasOne("Luyenthi.Domain.Document", "Document")
                        .WithMany("QuestionSets")
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Document");
                });

            modelBuilder.Entity("Luyenthi.Domain.TemplateQuestion", b =>
                {
                    b.HasOne("Luyenthi.Domain.Unit", "Unit")
                        .WithMany("TemplateQuestions")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("Luyenthi.Domain.Unit", b =>
                {
                    b.HasOne("Luyenthi.Domain.Chapter", "Chapter")
                        .WithMany("Units")
                        .HasForeignKey("ChapterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chapter");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("Luyenthi.Domain.User.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("Luyenthi.Domain.User.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Luyenthi.Domain.User.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("Luyenthi.Domain.User.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QuestionSetQuestion", b =>
                {
                    b.HasOne("Luyenthi.Domain.Question", null)
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Luyenthi.Domain.QuestionSet", null)
                        .WithMany()
                        .HasForeignKey("QuestionSetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Luyenthi.Domain.Chapter", b =>
                {
                    b.Navigation("Questions");

                    b.Navigation("Units");
                });

            modelBuilder.Entity("Luyenthi.Domain.Document", b =>
                {
                    b.Navigation("DocumentHistories");

                    b.Navigation("QuestionSets");
                });

            modelBuilder.Entity("Luyenthi.Domain.DocumentHistory", b =>
                {
                    b.Navigation("QuestionHistories");
                });

            modelBuilder.Entity("Luyenthi.Domain.Grade", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("Luyenthi.Domain.LevelQuestion", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("Luyenthi.Domain.Question", b =>
                {
                    b.Navigation("QuestionHistories");

                    b.Navigation("SubQuestions");
                });

            modelBuilder.Entity("Luyenthi.Domain.Subject", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("Luyenthi.Domain.TemplateQuestion", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("Luyenthi.Domain.Unit", b =>
                {
                    b.Navigation("Questions");

                    b.Navigation("TemplateQuestions");
                });

            modelBuilder.Entity("Luyenthi.Domain.User.ApplicationUser", b =>
                {
                    b.Navigation("DocumentHistories");

                    b.Navigation("QuestionHistories");
                });
#pragma warning restore 612, 618
        }
    }
}
