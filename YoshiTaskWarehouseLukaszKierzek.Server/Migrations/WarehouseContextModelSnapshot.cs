﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YoshiTaskWarehouseLukaszKierzek.Server.Data;

#nullable disable

namespace YoshiTaskWarehouseLukaszKierzek.Server.Migrations
{
    [DbContext(typeof(WarehouseContext))]
    partial class WarehouseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("YoshiTaskWarehouseLukaszKierzek.Server.Models.DokumentPrzyjecia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Anulowany")
                        .HasColumnType("int");

                    b.Property<int?>("DostawcaId")
                        .HasColumnType("int");

                    b.Property<int?>("MagazynDocelowyId")
                        .HasColumnType("int");

                    b.Property<int>("Zatwierdzony")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DostawcaId");

                    b.HasIndex("MagazynDocelowyId");

                    b.ToTable("dokumentPrzyjecia");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Anulowany = 0,
                            DostawcaId = 1,
                            MagazynDocelowyId = 1,
                            Zatwierdzony = 0
                        },
                        new
                        {
                            Id = 2,
                            Anulowany = 0,
                            DostawcaId = 1,
                            MagazynDocelowyId = 1,
                            Zatwierdzony = 0
                        },
                        new
                        {
                            Id = 3,
                            Anulowany = 1,
                            DostawcaId = 2,
                            MagazynDocelowyId = 2,
                            Zatwierdzony = 0
                        });
                });

            modelBuilder.Entity("YoshiTaskWarehouseLukaszKierzek.Server.Models.DokumentPrzyjeciaEtykieta", b =>
                {
                    b.Property<int>("DokumentPrzyjeciaId")
                        .HasColumnType("int");

                    b.Property<int>("EtykietaId")
                        .HasColumnType("int");

                    b.HasKey("DokumentPrzyjeciaId", "EtykietaId");

                    b.HasIndex("EtykietaId");

                    b.ToTable("dokumentPrzyjeciaEtykieta");

                    b.HasData(
                        new
                        {
                            DokumentPrzyjeciaId = 1,
                            EtykietaId = 1
                        },
                        new
                        {
                            DokumentPrzyjeciaId = 1,
                            EtykietaId = 2
                        },
                        new
                        {
                            DokumentPrzyjeciaId = 2,
                            EtykietaId = 3
                        });
                });

            modelBuilder.Entity("YoshiTaskWarehouseLukaszKierzek.Server.Models.Dostawca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NazwaFirmy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("dostawca");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Adres = "adres1",
                            NazwaFirmy = "Firma1"
                        },
                        new
                        {
                            Id = 2,
                            Adres = "adres2",
                            NazwaFirmy = "Firma2"
                        },
                        new
                        {
                            Id = 3,
                            Adres = "adres3",
                            NazwaFirmy = "Firma3"
                        });
                });

            modelBuilder.Entity("YoshiTaskWarehouseLukaszKierzek.Server.Models.Etykieta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("etykieta");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nazwa = "Etykieta1"
                        },
                        new
                        {
                            Id = 2,
                            Nazwa = "Etykieta2"
                        },
                        new
                        {
                            Id = 3,
                            Nazwa = "Etykieta3"
                        });
                });

            modelBuilder.Entity("YoshiTaskWarehouseLukaszKierzek.Server.Models.Magazyn", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("magazyn");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nazwa = "Magazyn1",
                            Symbol = "Symbol1"
                        },
                        new
                        {
                            Id = 2,
                            Nazwa = "Magazyn2",
                            Symbol = "Symbol2"
                        },
                        new
                        {
                            Id = 3,
                            Nazwa = "Magazyn3",
                            Symbol = "Symbol3"
                        });
                });

            modelBuilder.Entity("YoshiTaskWarehouseLukaszKierzek.Server.Models.Towar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Cena")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("DokumnetPrzyjeciaId")
                        .HasColumnType("int");

                    b.Property<int>("Ilosc")
                        .HasColumnType("int");

                    b.Property<string>("Kod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DokumnetPrzyjeciaId");

                    b.ToTable("towar");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cena = 20.99m,
                            DokumnetPrzyjeciaId = 1,
                            Ilosc = 2,
                            Kod = "kod1",
                            Nazwa = "Towar1"
                        },
                        new
                        {
                            Id = 2,
                            Cena = 21.99m,
                            DokumnetPrzyjeciaId = 1,
                            Ilosc = 4,
                            Kod = "kod2",
                            Nazwa = "Towar2"
                        },
                        new
                        {
                            Id = 3,
                            Cena = 22.99m,
                            DokumnetPrzyjeciaId = 2,
                            Ilosc = 5,
                            Kod = "kod3",
                            Nazwa = "Towar3"
                        });
                });

            modelBuilder.Entity("YoshiTaskWarehouseLukaszKierzek.Server.Models.DokumentPrzyjecia", b =>
                {
                    b.HasOne("YoshiTaskWarehouseLukaszKierzek.Server.Models.Dostawca", "Dostawca")
                        .WithMany("DokumentyPrzyjecia")
                        .HasForeignKey("DostawcaId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("YoshiTaskWarehouseLukaszKierzek.Server.Models.Magazyn", "MagazynDocelowy")
                        .WithMany("DokumentyPrzyjecia")
                        .HasForeignKey("MagazynDocelowyId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Dostawca");

                    b.Navigation("MagazynDocelowy");
                });

            modelBuilder.Entity("YoshiTaskWarehouseLukaszKierzek.Server.Models.DokumentPrzyjeciaEtykieta", b =>
                {
                    b.HasOne("YoshiTaskWarehouseLukaszKierzek.Server.Models.DokumentPrzyjecia", "DokumentPrzyjecia")
                        .WithMany()
                        .HasForeignKey("DokumentPrzyjeciaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YoshiTaskWarehouseLukaszKierzek.Server.Models.Etykieta", "Etykieta")
                        .WithMany()
                        .HasForeignKey("EtykietaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DokumentPrzyjecia");

                    b.Navigation("Etykieta");
                });

            modelBuilder.Entity("YoshiTaskWarehouseLukaszKierzek.Server.Models.Towar", b =>
                {
                    b.HasOne("YoshiTaskWarehouseLukaszKierzek.Server.Models.DokumentPrzyjecia", "DokumentPrzyjecia")
                        .WithMany("ListaTowarow")
                        .HasForeignKey("DokumnetPrzyjeciaId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("DokumentPrzyjecia");
                });

            modelBuilder.Entity("YoshiTaskWarehouseLukaszKierzek.Server.Models.DokumentPrzyjecia", b =>
                {
                    b.Navigation("ListaTowarow");
                });

            modelBuilder.Entity("YoshiTaskWarehouseLukaszKierzek.Server.Models.Dostawca", b =>
                {
                    b.Navigation("DokumentyPrzyjecia");
                });

            modelBuilder.Entity("YoshiTaskWarehouseLukaszKierzek.Server.Models.Magazyn", b =>
                {
                    b.Navigation("DokumentyPrzyjecia");
                });
#pragma warning restore 612, 618
        }
    }
}
