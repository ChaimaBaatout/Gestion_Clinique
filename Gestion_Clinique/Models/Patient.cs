using System.Collections.Generic;

namespace Gestion_Clinique.Models
{
    public class Patient : Utilisateur
    {
        
        private int cNSS;
        private string date_Naissance;


        public ICollection<RendezVous>? RendezVous { get; set; }

        public Patient()
        {
        }

        public Patient(int id, string nom, string prenom, string email, string motDePasse, int cNSS, string date_Naissance):base(id,nom,prenom,email,motDePasse)
        {
            Id = id;
            CNSS = cNSS;
            Date_Naissance = date_Naissance;
           
        }
        
        public int CNSS { get => CNSS; set => CNSS = value; }
        public string Date_Naissance { get => Date_Naissance; set => Date_Naissance = value; }
       
    }
}
