using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Students.Entities;
using Students.Models;
using Students.Services;

namespace Students.Controllers;
[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private readonly ILogger<StudentController> _logger;
    private readonly StudentService _service;

    public StudentController(ILogger<StudentController> logger, StudentService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpPost("/addstudent")]
    public async Task<IActionResult> AddStudent([FromForm]NewStudent newStudent) 
    {
        var student = new Student()
        {
            Id = Guid.NewGuid(),
            FirstName = newStudent.FirstName,
            LastName = newStudent.LastName,
            PhoneNumber = newStudent.PhoneNumber,
            Age  = newStudent.Age,
            Email = newStudent.Email,
            Address = newStudent.Address
        };
        var result = await _service.InsertAsync(student);
        var error = !result.IsSucces;
        var message = result.e is null ? "Success" : result.e.Message;
        return Ok(new {error, message, student});
    }

    [HttpGet("/getstudent")]
    public async Task<IActionResult> GetStudent([FromQuery]Guid id)
    {
        var student = await _service.GetByIdAsync(id);
        return Ok(student);
    }
}