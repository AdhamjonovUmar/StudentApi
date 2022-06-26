using Students.Entities;

namespace Students.Models;

public class GetTeacherModel
{
    public GetTeacherModel(Teacher teacher)
    {
        Id = teacher.Id;
        FirstName = teacher.FirstName;
        LastName = teacher.LastName;
        PhoneNumber = teacher.PhoneNumber;
        Age = teacher.Age;
        Email = teacher.Email;
    }

    public Guid Id { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string PhoneNumber { get; set; }

    public int Age { get; set; }
    
    public string Email { get; set; }
}