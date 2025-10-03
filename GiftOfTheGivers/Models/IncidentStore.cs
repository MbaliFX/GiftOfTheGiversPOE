using System.Collections.Generic;

namespace GiftOfTheGivers.Models
{
    public static class IncidentStore
    {
        private static List<Incident> _incidents = new List<Incident>();

        public static List<Incident> GetAll() => _incidents;

        public static void DateReported(Incident incident)
        {
            _incidents.Add(incident); // ID will come from Firestore
        }
    }
}
