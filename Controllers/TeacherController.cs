using Microsoft.AspNetCore.Mvc;
using Students.Entities;
using Students.Models;
using Students.Services;

namespace Students.Controllers;
[ApiController]
[Route("api/[controller]")]
public class TeacherController : ControllerBase
{
    private readonly ILogger<TeacherController> _logger;
    private readonly TeacherService _service;

    public TeacherController(ILogger<TeacherController> logger, TeacherService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpPost("/addteacher")]
    public async Task<IActionResult> AddTeacher([FromForm]NewTeacher newTeacher)
    {
        var teacher = new Teacher()
        {
            Id = Guid.NewGuid(),
            FirstName = newTeacher.FirstName,
            LastName = newTeacher.LastName,
            PhoneNumber = newTeacher.PhoneNumber,
            Age = newTeacher.Age,
            Email = newTeacher.Email,
        };
        var result = await _service.InsertAsync(teacher);
        var error = !result.IsSucces;
        var message = result.e is null ? "Success" : result.e.Message;
        return Ok(new { error, message, teacher });
    }

    [HttpGet("/getteacher")]
    public async Task<IActionResult> GetTeacher([FromQuery]Guid id)
    {
        var teacher = await _service.GetByIdAsync(id);
        return Ok(teacher);
    }
}