using Microsoft.EntityFrameworkCore;

namespace TestApp.DataContext
{
    public class ApplicationDbContext  :DbContext
        {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options) 
        {

        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Gender> Genders { get; set; }  

        public DbSet<Address> Address { get; set; } 



        
            
        
    }
    }


