using Examen.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Azure.Core.HttpHeader;

namespace Examen.Infrastructure
{
    public class ExamContext: DbContext
    {
        //DBSET


        public DbSet<Client> Clients { get; set; }
        public DbSet<Colis> Colis { get; set; }
        public DbSet<Livreur> Livreurs { get; set; }
        public DbSet<Vehicule> Vehicules { get; set; }
        public DbSet<Camion> Camions { get; set; }
        public DbSet<Voiture> Voitures { get; set; }




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

           
            modelBuilder.Entity<Colis>().HasKey(c => new { c.ClientFK, c.LivreurFK, c.DateLivraison });
             

            modelBuilder.Entity<Livreur>()
                .HasMany(l => l.Vehicules)
                .WithMany(v => v.Livreurs)
                .UsingEntity(j => j.ToTable("Conduite"));

            modelBuilder.Entity<Camion>().ToTable("Camions");

            modelBuilder.Entity<Voiture>().ToTable("Voitures");



            base.OnModelCreating(modelBuilder);
        }

        //Conventions
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
        }
    }
}
