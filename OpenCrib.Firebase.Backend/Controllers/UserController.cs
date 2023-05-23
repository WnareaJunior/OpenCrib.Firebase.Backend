using Microsoft.AspNetCore.Mvc;
using Google.Cloud.Firestore;
using OpenCrib.Firebase.Backend.Models;
using OpenCrib.Firebase.Backend.Services;

namespace OpenCrib.Firebase.Backend.Controllers
{

    //opencrib-74dcd
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly FirestoreDbService _firestoreDbService;
        private readonly string ProjectId = "opencrib-74dcd";
        public UserController()
        {
            _firestoreDbService = new FirestoreDbService(ProjectId);
        }


        //
        // Returns all Users in the collection
        //
        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<List<User>> GetAll()
        {
            return await  _firestoreDbService.GetAllUsers();
        }
    }
}