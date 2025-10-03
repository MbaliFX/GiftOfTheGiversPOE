using Google.Cloud.Firestore;
using GiftOfTheGivers.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GiftOfTheGivers.Services
{
    public class FirestoreService
    {
        private readonly FirestoreDb _firestoreDb;
        private const string CollectionName = "Incidents";

        public FirestoreService()
        {
            string path = Path.Combine(AppContext.BaseDirectory, "App_Data", "firebase-adminsdk.json");
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
            _firestoreDb = FirestoreDb.Create("your-project-id"); // Replace with your Firebase project ID
        }

        public async Task AddIncidentAsync(Incident incident)
        {
            // Firestore automatically generates an ID
            await _firestoreDb.Collection(CollectionName).AddAsync(incident);
        }

        public async Task<List<Incident>> GetIncidentsAsync()
        {
            var snapshot = await _firestoreDb.Collection(CollectionName).GetSnapshotAsync();
            return snapshot.Documents.Select(d =>
            {
                var incident = d.ConvertTo<Incident>();
                incident.Id = d.Id; // Assign Firestore document ID
                return incident;
            }).ToList();
        }

        public async Task<Incident?> GetIncidentAsync(string id)
        {
            var doc = await _firestoreDb.Collection(CollectionName).Document(id).GetSnapshotAsync();
            return doc.Exists ? doc.ConvertTo<Incident>() : null;
        }

        public async Task UpdateIncidentAsync(string id, Incident incident)
        {
            await _firestoreDb.Collection(CollectionName).Document(id).SetAsync(incident, SetOptions.Overwrite);
        }

        public async Task DeleteIncidentAsync(string id)
        {
            await _firestoreDb.Collection(CollectionName).Document(id).DeleteAsync();
        }
    }
}
