using Google.Cloud.Firestore;
using System;

namespace GiftOfTheGivers.Models
{
    [FirestoreData]
    public class Incident
    {
        [FirestoreProperty]
        public string Id { get; set; }

        [FirestoreProperty]
        public string Type { get; set; }   // Incident Title or Type

        [FirestoreProperty]
        public string Description { get; set; }

        [FirestoreProperty]
        public string Location { get; set; }

        [FirestoreProperty]
        public DateTime DateReported { get; set; } = DateTime.UtcNow;

        [FirestoreProperty]
        public int ReportedByCount { get; set; } = 1;
    }
}
