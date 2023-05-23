using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Components.Web;
using OpenCrib.Firebase.Backend.Models;

namespace OpenCrib.Firebase.Backend.Converters
{
    /* public class UserConverter : IFirestoreConverter<User>
     {
         public User FromFirestore(FirestoreDb db, DocumentSnapshot snapshot)
         {
             Dictionary<string, object> data = snapshot.ToDictionary();

             User user = new User
             {
                 UserId = snapshot.Id,
                 Username = (string)data["Username"],
                 Password = (string)data["Password"],
                 Email = (string)data["Email"],
                 HostRating = (int)data["HostRating"],
                 GuestRating = (int)data["GuestRating"],
                 Followers = (List<string>)data["Followers"],
                 Following = (List<string>)data["Following"],
                 Friends = (List<string>)data["Friends"],
                 PartiesAttended = (List<string>)data["PartiesAttended"],
                 PartiesThrown = (List<string>)data["PartiesThrown"],
                 PhoneNumber = (string)data["PhoneNumber"],
                 Latitude = (double?)data["Latitude"],
                 Longitude = (double?)data["Longitude"],
                 DOB = (DateTime)data["DOB"],
                 Address = snapshot.GetValue<Address>("Address")
             };

             return user;
         }

         public User FromFirestore(object value)
         {
             throw new NotImplementedException();
         }

         public Object ToFirestore(User value)
         {
             Dictionary<string, object> data = new Dictionary<string, object>
             {
                 { "Username", value.Username },
                 { "Password", value.Password },
                 { "Email", value.Email },
                 { "HostRating", value.HostRating },
                 { "GuestRating", value.GuestRating },
                 { "Followers", value.Followers },
                 { "Following", value.Following },
                 { "Friends", value.Friends },
                 { "PartiesAttended", value.PartiesAttended },
                 { "PartiesThrown", value.PartiesThrown },
                 { "PhoneNumber", value.PhoneNumber },
                 { "Latitude", value.Latitude },
                 { "Longitude", value.Longitude },
                 { "DOB", value.DOB },
                 { "Address", value.Address }
             };

             //reference.SetAsync(data);
             return value;
         }


     }*/
}
