using System.Collections.Generic;

namespace Gestion_Clinique.Models
{
    public class DateDeTravail
    {
        public int ID { get; set; }
        public string Jours { get; set; }
        private string HeurDebut { get; set; }
        public string HeurFin { get; set; }

        private ICollection<Medecin>? Medecins { get; set; }
        public DateDeTravail(int iD, string jours, string heurDebut, string heurFin)
        {
            ID = iD;
            Jours = jours;
            HeurDebut = heurDebut;
            HeurFin = heurFin;
        }

        public DateDeTravail()
        {
        }
    }
}
