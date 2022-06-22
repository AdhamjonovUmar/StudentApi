using System.ComponentModel.DataAnnotations;

namespace Students.Models;

public class NewStudent
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
}