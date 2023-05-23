
using Google.Cloud.Firestore;
using OpenCrib.Firebase.Backend.Converters;
using OpenCrib.Firebase.Backend.Models;
using System;
using System.Text.Json;

namespace OpenCrib.Firebase.Backend.Services
{
    public class FirestoreDbService
    {
        private readonly CollectionReference _userCollection;
        private FirestoreDb _db;
        public FirestoreDbService(string projectId)
        {
            // Initialize Firestore client
            _db = FirestoreDb.Create(projectId);
            _userCollection = _db.Collection("users");
            //FirestoreDb.ConverterRegistry.AddConverter(new UserConverter());
        }

        public async Task<List<User>> GetAllUsers()
        {
            List<User> users = new List<User>();

            CollectionReference collectionRef = _userCollection;

            Query query = collectionRef.Limit(10);
            // Get all documents in the collection
            QuerySnapshot querySnapshot = await query.GetSnapshotAsync();

            // Iterate over the documents
            foreach (DocumentSnapshot docSnapshot in querySnapshot.Documents)
            {
                // Deserialize the document snapshot into an instance of the Person class
                User user = docSnapshot.ConvertTo<User>();

                users.Add(user);
             
            }

            return users;
        }
    }
    
}