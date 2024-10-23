﻿// <auto-generated />
using System;
using ITAM_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ITAM_DB.Migrations
{
    [DbContext(typeof(ItotContext))]
    partial class ItotContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ITAM_API.Model.Operations.Itot_Pc", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("asset_barcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("date_acquired")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("date_created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("date_updated")
                        .HasColumnType("datetime2");

                    b.Property<string>("graphics")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("li_description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("operating_system")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pc_type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("processor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ram")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("serial_no")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("size")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("storage_capacity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("storage_type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Itot_Pcs");
                });

            modelBuilder.Entity("ITAM_API.Model.Operations.Itot_Peripheral", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("asset_barcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("date_acquired")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("date_created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("date_updated")
                        .HasColumnType("datetime2");

                    b.Property<string>("li_description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("peripheral_type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("serial_no")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("size")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Itot_Peripherals");
                });

            modelBuilder.Entity("ITAM_DB.Model.Cards.Pc_Card", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("company_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("contact_no")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("date_assigned")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("date_created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("date_updated")
                        .HasColumnType("datetime2");

                    b.Property<string>("dept_no")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("emp_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("pc_id")
                        .HasColumnType("int");

                    b.Property<int>("peripheral_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Pc_Cards");
                });

            modelBuilder.Entity("ITAM_DB.Model.Cards.User_Card", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("company_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("contact_no")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("date_assigned")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("date_created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("date_updated")
                        .HasColumnType("datetime2");

                    b.Property<string>("dept_no")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("emp_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("pc_id")
                        .HasColumnType("int");

                    b.Property<int>("peripheral_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("User_Cards");
                });
#pragma warning restore 612, 618
        }
    }
}
