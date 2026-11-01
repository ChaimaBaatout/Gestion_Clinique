namespace Gestion_Clinique.Models
{
    public class Utilisateur
    {
        private int id;
        private string nom;
        private string prenom;
        private string email;
        private string motDePasse;

        public Utilisateur(int id, string nom, string prenom, string email, string motDePasse)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            Email = email;
            MotDePasse = motDePasse;
        }
        public Utilisateur(Utilisateur u)
        {
            this.Id = u.id;
            this.Nom = u.nom;
            this.Prenom = u.prenom;
            this.Email = u.email;
            this.MotDePasse = u.motDePasse;
        }
        public Utilisateur()
        {
           
        }
        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Email { get => email; set => email = value; }
        public string MotDePasse { get => motDePasse; set => motDePasse = value; }
       
    }
}
