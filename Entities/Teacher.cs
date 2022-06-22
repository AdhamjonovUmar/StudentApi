using System.ComponentModel.DataAnnotations;

namespace Students.Entities;

public class Teacher
{
    [Key]
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
}