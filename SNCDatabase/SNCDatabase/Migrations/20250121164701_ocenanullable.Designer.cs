﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SNCDatabase.DB;

#nullable disable

namespace SNCDatabase.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250121164701_ocenanullable")]
    partial class ocenanullable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("SNCDatabase.Models.Admin", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("Ime")
                        .HasColumnType("longtext");

                    b.Property<string>("Prezime")
                        .HasColumnType("longtext");

                    b.Property<string>("Sifra")
                        .HasColumnType("longtext");

                    b.Property<string>("UID")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.ToTable("Admini");
                });

            modelBuilder.Entity("SNCDatabase.Models.Dekorater", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("BrojTelefona")
                        .HasColumnType("longtext");

                    b.Property<int>("Cena")
                        .HasColumnType("int");

                    b.Property<DateTime>("DatumOsnivanja")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Lokacija")
                        .HasColumnType("longtext");

                    b.Property<string>("Naziv")
                        .HasColumnType("longtext");

                    b.Property<float?>("Ocena")
                        .HasColumnType("float");

                    b.Property<string>("Opis")
                        .HasColumnType("longtext");

                    b.Property<string>("Sifra")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SigurnosniKod")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UID")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.ToTable("Dekorateri");
                });

            modelBuilder.Entity("SNCDatabase.Models.Fotograf", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("BrojTelefona")
                        .HasColumnType("longtext");

                    b.Property<int>("Cena")
                        .HasColumnType("int");

                    b.Property<int>("CenaPoSlici")
                        .HasColumnType("int");

                    b.Property<DateTime>("DatumOsnivanja")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Lokacija")
                        .HasColumnType("longtext");

                    b.Property<string>("Naziv")
                        .HasColumnType("longtext");

                    b.Property<float?>("Ocena")
                        .HasColumnType("float");

                    b.Property<string>("Opis")
                        .HasColumnType("longtext");

                    b.Property<string>("Sifra")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SigurnosniKod")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UID")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.ToTable("Fotografi");
                });

            modelBuilder.Entity("SNCDatabase.Models.Gosti", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Ime")
                        .HasColumnType("longtext");

                    b.Property<int>("MladenciID")
                        .HasColumnType("int");

                    b.Property<string>("Prezime")
                        .HasColumnType("longtext");

                    b.Property<int>("brojStola")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Gosti");
                });

            modelBuilder.Entity("SNCDatabase.Models.Jelovnik", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("ImeJela")
                        .HasColumnType("longtext");

                    b.Property<int>("Kolicina")
                        .HasColumnType("int");

                    b.Property<int>("RestoranID")
                        .HasColumnType("int");

                    b.Property<string>("TipJela")
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.ToTable("Jelovnici");
                });

            modelBuilder.Entity("SNCDatabase.Models.Korisnik", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("AdminID")
                        .HasColumnType("int");

                    b.Property<int>("DekoraterID")
                        .HasColumnType("int");

                    b.Property<int>("FotografID")
                        .HasColumnType("int");

                    b.Property<int>("MladenciID")
                        .HasColumnType("int");

                    b.Property<int>("PoslasticarID")
                        .HasColumnType("int");

                    b.Property<int>("RestoranID")
                        .HasColumnType("int");

                    b.Property<string>("Tip")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UID")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.ToTable("Korisnici");
                });

            modelBuilder.Entity("SNCDatabase.Models.MailCuvanje", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.ToTable("MailCuvanje");
                });

            modelBuilder.Entity("SNCDatabase.Models.Mladenci", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("BrojTelefona")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("Ime")
                        .HasColumnType("longtext");

                    b.Property<string>("ImePartneta")
                        .HasColumnType("longtext");

                    b.Property<string>("Prezime")
                        .HasColumnType("longtext");

                    b.Property<string>("PrezimePartnera")
                        .HasColumnType("longtext");

                    b.Property<string>("Sifra")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.ToTable("Mladenci");
                });

            modelBuilder.Entity("SNCDatabase.Models.OceneDekorater", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("DekoraterID")
                        .HasColumnType("int");

                    b.Property<float>("Ocena")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.ToTable("OceneDekorateri");
                });

            modelBuilder.Entity("SNCDatabase.Models.OceneFotograf", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("FotografID")
                        .HasColumnType("int");

                    b.Property<float>("Ocena")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.ToTable("OceneFotografi");
                });

            modelBuilder.Entity("SNCDatabase.Models.OcenePoslasticar", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ID"));

                    b.Property<float>("Ocena")
                        .HasColumnType("float");

                    b.Property<int>("PoslasticarID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("OcenePoslasticari");
                });

            modelBuilder.Entity("SNCDatabase.Models.OceneRestoran", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ID"));

                    b.Property<float>("Ocena")
                        .HasColumnType("float");

                    b.Property<int>("RestoranID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("OceneRestorani");
                });

            modelBuilder.Entity("SNCDatabase.Models.Poslasticar", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("BrojTelefona")
                        .HasColumnType("longtext");

                    b.Property<int>("Cena")
                        .HasColumnType("int");

                    b.Property<DateTime>("DatumOsnivanja")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Lokacija")
                        .HasColumnType("longtext");

                    b.Property<string>("Naziv")
                        .HasColumnType("longtext");

                    b.Property<float?>("Ocena")
                        .HasColumnType("float");

                    b.Property<string>("Opis")
                        .HasColumnType("longtext");

                    b.Property<string>("Sifra")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SigurnosniKod")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UID")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.ToTable("Poslasticari");
                });

            modelBuilder.Entity("SNCDatabase.Models.Restoran", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("BrojTelefona")
                        .HasColumnType("longtext");

                    b.Property<int>("Cena")
                        .HasColumnType("int");

                    b.Property<DateTime>("DatumOsnivanja")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Lokacija")
                        .HasColumnType("longtext");

                    b.Property<string>("Naziv")
                        .HasColumnType("longtext");

                    b.Property<float?>("Ocena")
                        .HasColumnType("float");

                    b.Property<string>("Opis")
                        .HasColumnType("longtext");

                    b.Property<bool>("PraviTortu")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Sifra")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SigurnosniKod")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UID")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.ToTable("Restorani");
                });

            modelBuilder.Entity("SNCDatabase.Models.SacuvanDekorater", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("DekoraterID")
                        .HasColumnType("int");

                    b.Property<string>("UID")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.ToTable("SacuvaniDekorateri");
                });

            modelBuilder.Entity("SNCDatabase.Models.SacuvanFotograf", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("FotografID")
                        .HasColumnType("int");

                    b.Property<string>("UID")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.ToTable("SacuvaniFotografi");
                });

            modelBuilder.Entity("SNCDatabase.Models.SacuvanPoslasticar", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("PoslasticarID")
                        .HasColumnType("int");

                    b.Property<string>("UID")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.ToTable("SacuvaniPoslasticari");
                });

            modelBuilder.Entity("SNCDatabase.Models.SacuvanRestoran", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("RestoranID")
                        .HasColumnType("int");

                    b.Property<string>("UID")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.ToTable("SacuvaniRestorani");
                });

            modelBuilder.Entity("SNCDatabase.Models.SigurnosniKod", b =>
                {
                    b.Property<int>("SigKod")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("SigKod"));

                    b.HasKey("SigKod");

                    b.ToTable("SigurnosniKodovi");
                });

            modelBuilder.Entity("SNCDatabase.Models.SlikeDekorater", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("DekoraterID")
                        .HasColumnType("int");

                    b.Property<string>("DekoraterUID")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("SLIKE")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("SlikeDekoratera");
                });

            modelBuilder.Entity("SNCDatabase.Models.SlikeFotograf", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("FotografID")
                        .HasColumnType("int");

                    b.Property<string>("FotografUID")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("SLIKE")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("SlikeFotografa");
                });

            modelBuilder.Entity("SNCDatabase.Models.SlikePoslasticar", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("PoslasticarID")
                        .HasColumnType("int");

                    b.Property<string>("PoslasticarUID")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("SLIKE")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("SlikePoslasticara");
                });

            modelBuilder.Entity("SNCDatabase.Models.SlikeRestoran", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("RestoranID")
                        .HasColumnType("int");

                    b.Property<string>("RestoranUID")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("SLIKE")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("SlikeRestorana");
                });

            modelBuilder.Entity("SNCDatabase.Models.SlobodanTermin", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("DekoraterID")
                        .HasColumnType("int");

                    b.Property<int?>("FotografID")
                        .HasColumnType("int");

                    b.Property<int?>("PoslasticarID")
                        .HasColumnType("int");

                    b.Property<int?>("RestoranID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Termin")
                        .HasColumnType("datetime(6)");

                    b.HasKey("ID");

                    b.ToTable("SlobodniTermini");
                });

            modelBuilder.Entity("SNCDatabase.Models.ZakazanJelovnik", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Cena")
                        .HasColumnType("int");

                    b.Property<float>("Gramaza")
                        .HasColumnType("float");

                    b.Property<string>("ImeJela")
                        .HasColumnType("longtext");

                    b.Property<int>("MladenciID")
                        .HasColumnType("int");

                    b.Property<string>("TipJela")
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.ToTable("ZakazaniJelovnici");
                });

            modelBuilder.Entity("SNCDatabase.Models.Zakazano", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CenaPoslasticara")
                        .HasColumnType("int");

                    b.Property<int>("CenaRestorana")
                        .HasColumnType("int");

                    b.Property<int>("DekoraterID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DekoraterTermin")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("FotografID")
                        .HasColumnType("int");

                    b.Property<DateTime>("FotografTermin")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("MladenciID")
                        .HasColumnType("int");

                    b.Property<string>("NazivTorte")
                        .HasColumnType("longtext");

                    b.Property<int>("PoslasticarID")
                        .HasColumnType("int");

                    b.Property<DateTime>("PoslasticarTermin")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("RestoranID")
                        .HasColumnType("int");

                    b.Property<DateTime>("RestoranTermin")
                        .HasColumnType("datetime(6)");

                    b.HasKey("ID");

                    b.ToTable("Zakazano");
                });
#pragma warning restore 612, 618
        }
    }
}
