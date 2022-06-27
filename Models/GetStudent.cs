using Students.Entities;

namespace Students.Models;

public class GetStudent
{
    public GetStudent(Student student)
    {
        Id = student.Id;
        FirstName = student.FirstName;
        LastName = student.LastName;
        PhoneNumber = student.PhoneNumber;
        Age = student.Age;
        Email = student.Email;
        Address = student.Address;
    }

    public Guid Id { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string PhoneNumber { get; set; }

    public int Age { get; set; }
    
    public string Email { get; set; }
    
    public string Address { get; set; }
}