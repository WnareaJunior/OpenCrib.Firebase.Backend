using Microsoft.AspNetCore.Mvc;
using Google.Cloud.Firestore;
using OpenCrib.Firebase.Backend.Models;
using OpenCrib.Firebase.Backend.Services;
using Microsoft.AspNetCore.Authorization;

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
        
        [HttpGet("GetAllUsers")]
        public async Task<List<User>> GetAll()
        {
           
            return await  _firestoreDbService.GetAllUsers();
        }

        [HttpGet("GetUser{userId}")]
        public async Task<IActionResult> GetUser(string userId)
        {
            
            User user = await _firestoreDbService.GetUser(userId);
            if(user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }
/*
        [HttpPost("follow")]
        [Authorize] // Requires authentication (token)
        public async Task<IActionResult> FollowUser(string followeeUserId)
        {
            string followerUserId = User.Identity.Name; // Extract the user ID from the authenticated token

           // bool isFollowed = await _firestoreDbService.FollowUser(followerUserId, followeeUserId);

            if (isFollowed)
            {
                return Ok("User followed successfully.");
            }
            else
            {
                return BadRequest("Unable to follow user.");
            }
        }*/

    }

    [ApiController]
    [Route("[controller]")]
    public class PartyController : ControllerBase
    {
        private readonly FirestoreDbService _firestoreDbService;
        private readonly string ProjectId = "opencrib-74dcd";
        public PartyController()
        {
            _firestoreDbService = new FirestoreDbService(ProjectId);
        }

        //
        // Posts a party
        //

        [HttpPost("PostParty")]
        public async Task<IActionResult> PostParty(Party party)
        {
            Party created = await _firestoreDbService.PostParty(party);

            if (created != null)
            {
                return Ok(party);
            }
            return BadRequest();
        }

    }
}