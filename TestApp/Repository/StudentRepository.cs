using Microsoft.EntityFrameworkCore;
using TestApp.DataContext;

namespace TestApp.Repository
{
    public class StudentRepository : IstudentRepository
    {

        private readonly ApplicationDbContext _dbcontext;
        private readonly ILogger<StudentRepository> _logger;

        public StudentRepository(ApplicationDbContext dbcontext, ILogger<StudentRepository> logger)
        {
            _dbcontext = dbcontext;
            _logger = logger;
        }

        public  async  Task<List<Student>> GetAllStudentsAsync()
        {
            _logger.LogInformation("Fetching all students from the database.");

            //var   students =   _dbcontext.Students.ToList();

            var students = await _dbcontext.Students
                .Include(s => s.Gender)    
                .Include(s => s.Address)  
                .ToListAsync();

            _logger.LogInformation("Fetched {Count} students.", students.Count);
             return students;

        }


    }


}
