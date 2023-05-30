using Google.Cloud.Firestore;
using System.Collections;
using System.Collections;

namespace OpenCrib.Firebase.Backend.Models
{

    [FirestoreData]
    public class Party
    {
        [FirestoreDocumentId]
        public string? PartyId { get; set; }
        public Address? Address { get; set; }
        public List<Comment> Comments { get; set; }
        public DateTime? Date { get; set; }
        public string HostId { get; set; }
        public string HostUsername { get; set; }    
        public string PartyName { get; set; }
        public List<string>? Rsvps { get; set; }
        public List<string>? Tags { get; set; }
        public int views { get; set; } = 0;

    }
}
