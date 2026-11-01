using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Gestion_Clinique.Models;

namespace Gestion_Clinique.Data
{
    public class Gestion_CliniqueContext : DbContext
    {
        public Gestion_CliniqueContext (DbContextOptions<Gestion_CliniqueContext> options)
            : base(options)
        {
        }

        public DbSet<Gestion_Clinique.Models.Utilisateur> Utilisateur { get; set; }

        public DbSet<Gestion_Clinique.Models.Medecin> Medecin { get; set; }

        public DbSet<Gestion_Clinique.Models.Patient> Patient { get; set; }

        public DbSet<Gestion_Clinique.Models.RendezVous> RendezVous { get; set; }

        public DbSet<Gestion_Clinique.Models.DateDeTravail> DateDeTravail { get; set; }

        public DbSet<Gestion_Clinique.Models.Specialite> Specialite { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<RendezVous>()
                        .HasOne(bc => bc.Medecin)
                        .WithMany(b => b.RendezVous)
                        .HasForeignKey(bc => bc.MedecinId)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RendezVous>()
                    .HasOne(bc => bc.Patient)
                    .WithMany(x => x.RendezVous)
                    .HasForeignKey(bc => bc.PatientId)
                    .OnDelete(DeleteBehavior.Restrict);




        }
    }
}
