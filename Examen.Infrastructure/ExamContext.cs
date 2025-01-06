using Examen.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static Azure.Core.HttpHeader;

namespace Examen.Infrastructure
{
    public class ExamContext: DbContext
    {
        //DBSET



        //OnConfiguring
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                                          Initial Catalog=ExamDB;
                                          Integrated Security=true;
                                          MultipleActiveResultSets=true");

            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        //FluentAPI
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pneu>()
                .HasMany(p => p.Interventions)
                 .WithOne(i => i.Pneu)
               .HasForeignKey(i => i.PneuKey);

            modelBuilder.Entity<Ouvrier>()
                .HasMany(o => o.Interventions)
                .WithOne(i => i.Ouvrier)
                .HasForeignKey(i => i.OuvrierKey);


            modelBuilder.Entity<Intervention>()
            .HasKey(t => new
            {
                t.PneuKey,
                t.OuvrierKey,
                t.DateDebut
            });

            //configurer la table d'association représentant la relatiob entre marque et fournisseur pour qu'elle soit nommée MarqueFournTable
            modelBuilder.Entity<Marque>()
                .HasMany(m => m.Fournisseurs)
                .WithMany(f => f.Marques)
                .UsingEntity(j => j.ToTable("MarqueFournTable"));




            base.OnModelCreating(modelBuilder);
        }

        //Conventions
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
        }
    }
}
