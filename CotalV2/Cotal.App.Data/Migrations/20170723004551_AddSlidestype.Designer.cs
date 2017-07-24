﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Cotal.App.Data.Contexts;
using Cotal.App.Model.Models;

namespace Cotal.App.Data.Migrations
{
    [DbContext(typeof(CotalContex))]
    [Migration("20170723004551_AddSlidestype")]
    partial class AddSlidestype
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Cotal.App.Model.Models.Announcement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppCode")
                        .HasMaxLength(10);

                    b.Property<string>("Content");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("LangCode")
                        .HasColumnType("varchar(5)")
                        .HasMaxLength(5);

                    b.Property<bool>("Status");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<int>("UserId");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Announcements");
                });

            modelBuilder.Entity("Cotal.App.Model.Models.AnnouncementUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AnnouncementId");

                    b.Property<string>("AppCode")
                        .HasMaxLength(10);

                    b.Property<bool>("HasRead");

                    b.Property<string>("LangCode")
                        .HasColumnType("varchar(5)")
                        .HasMaxLength(5);

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("AnnouncementId");

                    b.ToTable("AnnouncementUsers");
                });

            modelBuilder.Entity("Cotal.App.Model.Models.ContactDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .HasMaxLength(250);

                    b.Property<string>("AppCode")
                        .HasMaxLength(10);

                    b.Property<string>("Email")
                        .HasMaxLength(250);

                    b.Property<string>("LangCode")
                        .HasColumnType("varchar(5)")
                        .HasMaxLength(5);

                    b.Property<double?>("Lat");

                    b.Property<double?>("Lng");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("Other");

                    b.Property<string>("Phone")
                        .HasMaxLength(50);

                    b.Property<bool>("Status");

                    b.Property<string>("Website")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.ToTable("ContactDetails");
                });

            modelBuilder.Entity("Cotal.App.Model.Models.Error", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppCode")
                        .HasMaxLength(10);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("LangCode")
                        .HasColumnType("varchar(5)")
                        .HasMaxLength(5);

                    b.Property<string>("Message");

                    b.Property<string>("StackTrace");

                    b.HasKey("Id");

                    b.ToTable("Errors");
                });

            modelBuilder.Entity("Cotal.App.Model.Models.Feedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppCode")
                        .HasMaxLength(10);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Email")
                        .HasMaxLength(250);

                    b.Property<string>("LangCode")
                        .HasColumnType("varchar(5)")
                        .HasMaxLength(5);

                    b.Property<string>("Message")
                        .HasMaxLength(500);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<bool>("Status");

                    b.HasKey("Id");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("Cotal.App.Model.Models.Footer", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("AppCode")
                        .HasMaxLength(10);

                    b.Property<string>("Content")
                        .IsRequired();

                    b.Property<string>("LangCode")
                        .HasColumnType("varchar(5)")
                        .HasMaxLength(5);

                    b.HasKey("Id");

                    b.ToTable("Footers");
                });

            modelBuilder.Entity("Cotal.App.Model.Models.Function", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("AppCode")
                        .HasMaxLength(10);

                    b.Property<int>("DisplayOrder");

                    b.Property<int>("FunctionType");

                    b.Property<string>("IconCss");

                    b.Property<string>("LangCode")
                        .HasColumnType("varchar(5)")
                        .HasMaxLength(5);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("ParentId")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("Status");

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Functions");
                });

            modelBuilder.Entity("Cotal.App.Model.Models.OutService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("AppCode")
                        .HasMaxLength(10);

                    b.Property<string>("Content");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<bool?>("HomeFlag");

                    b.Property<bool?>("HotFlag");

                    b.Property<string>("IconCss")
                        .HasMaxLength(100);

                    b.Property<string>("Image")
                        .HasMaxLength(256);

                    b.Property<string>("LangCode")
                        .HasColumnType("varchar(5)")
                        .HasMaxLength(5);

                    b.Property<string>("MetaDescription")
                        .HasMaxLength(256);

                    b.Property<string>("MetaKeyword")
                        .HasMaxLength(256);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<bool>("Status");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("OutServices");
                });

            modelBuilder.Entity("Cotal.App.Model.Models.Page", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("AppCode")
                        .HasMaxLength(10);

                    b.Property<string>("Content");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("LangCode")
                        .HasColumnType("varchar(5)")
                        .HasMaxLength(5);

                    b.Property<string>("MetaDescription")
                        .HasMaxLength(256);

                    b.Property<string>("MetaKeyword")
                        .HasMaxLength(256);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<bool>("Status");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("Pages");
                });

            modelBuilder.Entity("Cotal.App.Model.Models.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppCode")
                        .HasMaxLength(10);

                    b.Property<bool>("CanCreate");

                    b.Property<bool>("CanDelete");

                    b.Property<bool>("CanRead");

                    b.Property<bool>("CanUpdate");

                    b.Property<string>("FunctionId")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("LangCode")
                        .HasColumnType("varchar(5)")
                        .HasMaxLength(5);

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("FunctionId");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("Cotal.App.Model.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("AppCode")
                        .HasMaxLength(10);

                    b.Property<int>("CategoryId");

                    b.Property<string>("Content");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<bool?>("HomeFlag");

                    b.Property<bool?>("HotFlag");

                    b.Property<string>("Image")
                        .HasMaxLength(256);

                    b.Property<string>("LangCode")
                        .HasColumnType("varchar(5)")
                        .HasMaxLength(5);

                    b.Property<string>("MetaDescription")
                        .HasMaxLength(256);

                    b.Property<string>("MetaKeyword")
                        .HasMaxLength(256);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<bool>("Status");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<int?>("ViewCount");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Cotal.App.Model.Models.PostCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("AppCode")
                        .HasMaxLength(10);

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<int?>("DisplayOrder");

                    b.Property<bool?>("HomeFlag");

                    b.Property<string>("Image")
                        .HasMaxLength(256);

                    b.Property<string>("LangCode")
                        .HasColumnType("varchar(5)")
                        .HasMaxLength(5);

                    b.Property<string>("MetaDescription")
                        .HasMaxLength(256);

                    b.Property<string>("MetaKeyword")
                        .HasMaxLength(256);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<int?>("ParentId");

                    b.Property<bool>("Status");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("PostCategories");
                });

            modelBuilder.Entity("Cotal.App.Model.Models.PostTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppCode")
                        .HasMaxLength(10);

                    b.Property<string>("LangCode")
                        .HasColumnType("varchar(5)")
                        .HasMaxLength(5);

                    b.Property<int>("PostId");

                    b.Property<string>("TagId")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("TagId");

                    b.ToTable("PostTags");
                });

            modelBuilder.Entity("Cotal.App.Model.Models.Slide", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppCode")
                        .HasMaxLength(10);

                    b.Property<string>("Content");

                    b.Property<string>("Description")
                        .HasMaxLength(256);

                    b.Property<int?>("DisplayOrder");

                    b.Property<string>("Image")
                        .HasMaxLength(256);

                    b.Property<string>("LangCode")
                        .HasColumnType("varchar(5)")
                        .HasMaxLength(5);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<int>("SlideType");

                    b.Property<bool>("Status");

                    b.Property<string>("Url")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.ToTable("Slides");
                });

            modelBuilder.Entity("Cotal.App.Model.Models.SupportOnline", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppCode")
                        .HasMaxLength(10);

                    b.Property<string>("Department")
                        .HasMaxLength(50);

                    b.Property<int?>("DisplayOrder");

                    b.Property<string>("Email")
                        .HasMaxLength(50);

                    b.Property<string>("Facebook")
                        .HasMaxLength(50);

                    b.Property<string>("LangCode")
                        .HasColumnType("varchar(5)")
                        .HasMaxLength(5);

                    b.Property<string>("Mobile")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Skype")
                        .HasMaxLength(50);

                    b.Property<bool>("Status");

                    b.Property<string>("Yahoo")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("SupportOnlines");
                });

            modelBuilder.Entity("Cotal.App.Model.Models.SystemConfig", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppCode")
                        .HasMaxLength(10);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("LangCode")
                        .HasColumnType("varchar(5)")
                        .HasMaxLength(5);

                    b.Property<int?>("ValueInt");

                    b.Property<string>("ValueString")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("SystemConfigs");
                });

            modelBuilder.Entity("Cotal.App.Model.Models.Tag", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("AppCode")
                        .HasMaxLength(10);

                    b.Property<string>("LangCode")
                        .HasColumnType("varchar(5)")
                        .HasMaxLength(5);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Cotal.App.Model.Models.VisitorStatistic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppCode")
                        .HasMaxLength(10);

                    b.Property<string>("IpAddress")
                        .HasMaxLength(50);

                    b.Property<string>("LangCode")
                        .HasColumnType("varchar(5)")
                        .HasMaxLength(5);

                    b.Property<DateTime>("VisitedDate");

                    b.HasKey("Id");

                    b.ToTable("VisitorStatistics");
                });

            modelBuilder.Entity("Cotal.App.Model.Models.AnnouncementUser", b =>
                {
                    b.HasOne("Cotal.App.Model.Models.Announcement", "Announcement")
                        .WithMany("AnnouncementUsers")
                        .HasForeignKey("AnnouncementId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Cotal.App.Model.Models.Function", b =>
                {
                    b.HasOne("Cotal.App.Model.Models.Function", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("Cotal.App.Model.Models.Permission", b =>
                {
                    b.HasOne("Cotal.App.Model.Models.Function", "Function")
                        .WithMany()
                        .HasForeignKey("FunctionId");
                });

            modelBuilder.Entity("Cotal.App.Model.Models.Post", b =>
                {
                    b.HasOne("Cotal.App.Model.Models.PostCategory", "PostCategory")
                        .WithMany("Posts")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Cotal.App.Model.Models.PostTag", b =>
                {
                    b.HasOne("Cotal.App.Model.Models.Post", "Post")
                        .WithMany("PostTags")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Cotal.App.Model.Models.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId");
                });
        }
    }
}
