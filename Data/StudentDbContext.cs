using Microsoft.EntityFrameworkCore;
using Students.Entities;

namespace Students.Data;

public class StudentDbContext : DbContext
{
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Student> Students { get; set; }
    
    public StudentDbContext(DbContextOptions<StudentDbContext> options)
        : base(options) { }
}