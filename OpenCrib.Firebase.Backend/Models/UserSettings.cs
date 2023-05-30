using Google.Cloud.Firestore;

namespace OpenCrib.Firebase.Backend.Models
{

    [FirestoreData]
    public class UserSettings
    {
        public bool Active { get; set; } = true;
        public bool PrivacyMode { get; set; } = false;
    }
}
