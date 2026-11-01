using System.Collections.Generic;

namespace Gestion_Clinique.Models
{
    public class Medecin : Utilisateur
    {
      
        private int prix_visite;
        private bool activate;
        private string cIN;

        public virtual ICollection<RendezVous>? RendezVous { get; set; }
        public int SpecialiteId { get; set; }
        public virtual Specialite Specialite { get; set; }

        public int DateDeTravailId { get; set; }
        public int RendezVousId { get; set; }
        public virtual DateDeTravail DateDeTravail { get; set; }
        public Medecin()
        {
        }

        public Medecin(int id, string nom, string prenom, string email, string motDePasse, int prix_visite, bool activate, string cIN):base(id,nom, prenom,email,motDePasse)
        {
          
            Prix_visite = prix_visite;
            Activate = activate;
            CIN = cIN;
        }

   
        public int Prix_visite { get => prix_visite; set => prix_visite = value; }
        public bool Activate { get => activate; set => activate = value; }
        public string CIN { get => cIN; set => cIN = value; }
    }
}
