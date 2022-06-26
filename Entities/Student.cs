using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Students.Entities;

public class Student
{
    [Key]
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }

    public ICollection<Teacher> Teachers { get; set; }    
}