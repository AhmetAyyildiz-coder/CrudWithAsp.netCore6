﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using crud.Models;

#nullable disable

namespace crud.Migrations
{
    [DbContext(typeof(IslemDbModel))]
    partial class IslemDbModelModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("crud.Models.Islem", b =>
                {
                    b.Property<int>("islemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("islemId"), 1L, 1);

                    b.Property<string>("AliciIsim")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("BankaIsim")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("HesapNumarasi")
                        .IsRequired()
                        .HasColumnType("nvarchar(12)");

                    b.Property<int>("Miktar")
                        .HasColumnType("int");

                    b.Property<string>("SwiftCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(11)");

                    b.Property<DateTime>("Tarih")
                        .HasColumnType("datetime2");

                    b.HasKey("islemId");

                    b.ToTable("Islemler");
                });
#pragma warning restore 612, 618
        }
    }
}
