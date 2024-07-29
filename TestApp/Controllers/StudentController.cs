using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using TestApp.Repository;

namespace TestApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IstudentRepository _StudentRepo;
        private readonly ILogger<StudentController> _logger;


        public StudentController(IstudentRepository studentRepo, ILogger<StudentController> logger)
        {
            _StudentRepo = studentRepo;
            _logger = logger;
        }

        [Route("[action]")]
        [HttpGet("getallstudents")]
        public async Task <IActionResult> GetAllStudentAsync()
        {
            _logger.LogInformation("Received request to fetch all students.");

            var students = await _StudentRepo.GetAllStudentsAsync();

            if (students == null || !students.Any())
            {
                _logger.LogWarning("No students found.");
                return   NotFound("No students found.");
            }


            _logger.LogInformation("Returning {Count} students.", students.Count);
            return   Ok(students);
            //return Ok(_StudentRepo.GetAllStudents());

                
        }
    }  

    
}
