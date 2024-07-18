using Microsoft.EntityFrameworkCore;

namespace W3_D2_01.Models
{
    public class StudentContext:DbContext
    {
        public StudentContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
    }
}
