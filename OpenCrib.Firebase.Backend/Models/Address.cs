using Google.Cloud.Firestore;
using System.IO;
using System.Net;


namespace OpenCrib.Firebase.Backend.Models
{

    [FirestoreData]
    public class Address
    {


       
        public string AddressLine1 { get; set; }

        public string? AddressLine2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string PostalCode { get; set; }

    }
}
