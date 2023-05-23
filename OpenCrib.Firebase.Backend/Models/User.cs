using Google.Cloud.Firestore;
using System.IO;
using System.Net;

namespace OpenCrib.Firebase.Backend.Models
{
    [FirestoreData]
    public class User
    {
        [FirestoreDocumentId]
        public string? UserId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string? Email { get; set; }

        public int HostRating { get; set; } = 0;

        public int GuestRating { get; set; } = 0;

        public List<string>? Followers { get; set; }

        public List<string>? Following { get; set; }

        public List<string>? Friends { get; set; }

        public List<string>? PartiesAttended { get; set; }

        public List<string>? PartiesThrown { get; set; } 

        public string? PhoneNumber { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }
        
        public DateTime DOB { get; set; }
       
        public Address? Address { get; set; }


      
    }

}