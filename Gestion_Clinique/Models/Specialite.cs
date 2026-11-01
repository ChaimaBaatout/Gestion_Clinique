using System.Collections.Generic;

namespace Gestion_Clinique.Models
{
    public class Specialite
    {
        private int id;
        private string nom;
     

            private ICollection<Medecin>? Medecin{ get; set; }

        public Specialite()
        {
        }

        public Specialite(int id, string nom)
        {
            Id = id;
            Nom = nom;
        }

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
    }
}
