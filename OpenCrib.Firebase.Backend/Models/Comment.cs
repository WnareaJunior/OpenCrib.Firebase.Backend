using Google.Cloud.Firestore;

namespace OpenCrib.Firebase.Backend.Models
{

    [FirestoreData]
    public class Comment
    {
        public string? Id { get; set; }
        public string? Message { get; set; }
    }
}
