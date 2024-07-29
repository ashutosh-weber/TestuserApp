

namespace TestApp.Repository


    
{
    public interface IstudentRepository
    {
       Task <List<Student>> GetAllStudentsAsync();
        
    }
}
