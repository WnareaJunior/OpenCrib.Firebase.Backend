
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
        private readonly CollectionReference _partyCollection;
        private FirestoreDb _db;
        public FirestoreDbService(string projectId)
        {
            // Initialize Firestore client
            _db = FirestoreDb.Create(projectId);
            _userCollection = _db.Collection("users");
            _partyCollection = _db.Collection("parties");
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

        public async Task<User> GetUser(string userId)
        {
            DocumentSnapshot snapshot = await _userCollection.Document(userId).GetSnapshotAsync();
            if (snapshot.Exists)
            {
                var user = snapshot.ConvertTo<User>();
                //user.UserId = snapshot.UserId;
                return user;
            }
            return null;
        }

        //To my knowledge, User creation is left to our google auth side, this web api will serve to modify already created users
        public async Task<User> CreateUser(User user)
        {
            DocumentReference documentReference = await _userCollection.AddAsync(user);
            user.UserId = documentReference.Id;
            return user;
        }

        public async Task<User> UpdateUser(string id, User updatedUser)
        {
            DocumentReference documentReference = _userCollection.Document(id);
            await documentReference.SetAsync(updatedUser, SetOptions.MergeAll);
            updatedUser.UserId = id;
            return updatedUser;
        }

        public async Task<bool> DeleteUser(string id)
        {
            DocumentReference documentReference = _userCollection.Document(id);
            DocumentSnapshot snapshot = await documentReference.GetSnapshotAsync();
            if (snapshot.Exists)
            {
                await documentReference.DeleteAsync();
                return true;
            }
            return false;
        }
       /* public async Task<bool> Unfollow(string yourId,string theirId)
        {
            DocumentReference 
            if()

        }
        public async Task<bool> FollowUser(string followerUserId, string followeeUserId)
        {
            // Logic to check if followerUserId and followeeUserId are valid and exist in the database
            // ...

            // Perform the follow action
            bool isFollowed = await _userRepository.FollowUser(followerUserId, followeeUserId);

            return isFollowed;
        }*/

        public async Task<Party> PostParty(Party party)
        {
            // Add to the parties collection with the new party object
            DocumentReference partyDocument = await _partyCollection.AddAsync(party);

            // Get the party's host userDocument using the hostId which is equal the the UserId Field in User Model
            DocumentReference userDocument = _userCollection.Document(party.HostId);

            // Update the user's parties list with the new party reference
            await userDocument.UpdateAsync("PartiesThrown", FieldValue.ArrayUnion(partyDocument));

            // check if correct user has the the party Id added to their list of parties hosted/hosting 
            DocumentSnapshot userSnapshot = await _userCollection.Document(party.HostId).GetSnapshotAsync();
           /* if (userSnapshot.Exists) {
                User user = userSnapshot.ConvertTo<User>();
                if (user != null &&
                    user.PartiesThrown != null &&
                    user.PartiesThrown.Contains(partyDocument.Id))
                {
                    return party;
                }
            }*/

            return party;

        }
        public class UserNotFoundException : Exception
        {
            public UserNotFoundException(string message) : base(message)
            {
            }
        }
    }
    
}