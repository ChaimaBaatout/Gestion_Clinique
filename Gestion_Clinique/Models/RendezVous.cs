namespace Gestion_Clinique.Models
{
    public class RendezVous
    {
      
        private string date;
        private string heure;
        private bool valider;

        public int MedecinId { get; set; }
        public virtual Medecin Medecin { get; set; }
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }

        public RendezVous()
        {
        }

        public RendezVous(int id, string date, string heure, bool valider)
        {
            Id = id;
            Date = date;
            Heure = heure;
            Valider = valider;
        }

        public int Id { get => id; set => id = value; }
        public string Date { get => date; set => date = value; }
        public string Heure { get => heure; set => heure = value; }
        public bool Valider { get => valider; set => valider = value; }
    }
}
