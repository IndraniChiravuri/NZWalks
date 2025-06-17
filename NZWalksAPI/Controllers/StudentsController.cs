using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NZWalksAPI.Controllers
{
    //https://localhost:port/api/students
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private static readonly string[] StudentsNames = { "John", "Paul", "Indrani", "Chiravuri"};

        //GET:https://localhost:port/api/students
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            return Ok(StudentsNames);
        }
    }
}
