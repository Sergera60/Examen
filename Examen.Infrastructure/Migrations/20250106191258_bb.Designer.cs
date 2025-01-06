﻿// <auto-generated />
using System;
using Examen.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Examen.Infrastructure.Migrations
{
    [DbContext(typeof(ExamContext))]
    [Migration("20250106191258_bb")]
    partial class bb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Fournisseur", b =>
                {
                    b.Property<int>("FournisseurId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FournisseurId"));

                    b.Property<string>("Adresse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FournisseurId");

                    b.ToTable("Fournisseur");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Intervention", b =>
                {
                    b.Property<int>("PneuKey")
                        .HasColumnType("int");

                    b.Property<int>("OuvrierKey")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateDebut")
                        .HasColumnType("datetime2");

                    b.Property<double>("Cout")
                        .HasColumnType("float");

                    b.Property<DateTime>("DateFin")
                        .HasColumnType("datetime2");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("PneuKey", "OuvrierKey", "DateDebut");

                    b.HasIndex("OuvrierKey");

                    b.ToTable("Intervention");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Marque", b =>
                {
                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Reputation")
                        .HasColumnType("int");

                    b.HasKey("Nom");

                    b.ToTable("Marque");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Ouvrier", b =>
                {
                    b.Property<int>("OuvrierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OuvrierId"));

                    b.Property<int>("Experience")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Qualifie")
                        .HasColumnType("bit");

                    b.HasKey("OuvrierId");

                    b.ToTable("Ouvrier");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Pneu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Diametre")
                        .HasColumnType("real");

                    b.Property<DateTime?>("Fabrication")
                        .HasColumnType("datetime2");

                    b.Property<string>("marqueNom")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("marqueNom");

                    b.ToTable("Pneu");
                });

            modelBuilder.Entity("FournisseurMarque", b =>
                {
                    b.Property<int>("FournisseursFournisseurId")
                        .HasColumnType("int");

                    b.Property<string>("MarquesNom")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("FournisseursFournisseurId", "MarquesNom");

                    b.HasIndex("MarquesNom");

                    b.ToTable("MarqueFournTable", (string)null);
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Intervention", b =>
                {
                    b.HasOne("Examen.ApplicationCore.Domain.Ouvrier", "Ouvrier")
                        .WithMany("Interventions")
                        .HasForeignKey("OuvrierKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Examen.ApplicationCore.Domain.Pneu", "Pneu")
                        .WithMany("Interventions")
                        .HasForeignKey("PneuKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ouvrier");

                    b.Navigation("Pneu");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Pneu", b =>
                {
                    b.HasOne("Examen.ApplicationCore.Domain.Marque", "marque")
                        .WithMany("Pneus")
                        .HasForeignKey("marqueNom")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("marque");
                });

            modelBuilder.Entity("FournisseurMarque", b =>
                {
                    b.HasOne("Examen.ApplicationCore.Domain.Fournisseur", null)
                        .WithMany()
                        .HasForeignKey("FournisseursFournisseurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Examen.ApplicationCore.Domain.Marque", null)
                        .WithMany()
                        .HasForeignKey("MarquesNom")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Marque", b =>
                {
                    b.Navigation("Pneus");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Ouvrier", b =>
                {
                    b.Navigation("Interventions");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Pneu", b =>
                {
                    b.Navigation("Interventions");
                });
#pragma warning restore 612, 618
        }
    }
}
