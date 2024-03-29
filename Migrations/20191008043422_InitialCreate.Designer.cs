﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebCore.Models;

namespace WebCore.Migrations
{
    [DbContext(typeof(PatientContext))]
    [Migration("20191008043422_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebCore.Models.Patient", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Address")
                        .HasColumnType("varchar(250)");

                    b.Property<string>("City")
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("FirstName")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Gender")
                        .HasColumnType("char(1)");

                    b.Property<string>("LastName")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("State")
                        .HasColumnType("char(2)");

                    b.Property<string>("ZipCode")
                        .HasColumnType("char(5)");

                    b.HasKey("Id");

                    b.ToTable("patients");
                });
#pragma warning restore 612, 618
        }
    }
}
