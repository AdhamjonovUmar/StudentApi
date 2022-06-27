using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Students.Data;
using Students.Entities;

namespace Students.Services;

public class StudentService : IEntityService<Student>
{
    private readonly ILogger<StudentService> _logger;
    private readonly StudentDbContext _context;

    public StudentService(ILogger<StudentService> logger, StudentDbContext context)
    {
        _logger = logger;
        _context = context;   
    }
    public async Task<(bool IsSucces, Exception e)> DeleteAsync(Guid id)
    {
        try
        {
            var student = await GetByIdAsync(id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Student was deleted with {id} id");
            return(true, null);
        }
        catch (Exception e)
        {
            _logger.LogError($"Student was not deleted.\nException: {e.Message}");
            return(false, e);
        }
    }

    public async Task<List<Student>> GetAllAsync()
    {
        return _context.Students.Include(p => p.Teachers).ToList();
    }

    public async Task<Student> GetByIdAsync(Guid id)
    {
        try
        {
            var student = _context.Students.Include(p => p.Teachers).FirstOrDefault(d => d.Id == id);
            return student;
        }
        catch(Exception e)
        {
            _logger.LogError(e.Message);
            return null;
        }
    }

    public async Task<(bool IsSucces, Exception e)> InsertAsync(Student entity)
    {
        try
        {
            await _context.Students.AddAsync(entity);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"New student was added to database with {entity.Id}");
            return(true, null);
        }
        catch (Exception e)
        {
            _logger.LogError($"New student was not added. Exception:\n{e.Message}");
            return(false, e);
        }
    }

    public async Task<(bool IsSucces, Exception e)> UpdateAsync(Student entity)
    {
        try
        {
            _context.Students.Update(entity);
            await _context.SaveChangesAsync();
            return(true, null);
        }
        catch (Exception e)
        {
            _logger.LogError($"Student was not updated.\n Error {e.Message}");
            return(false, e);
        }
    }

    public async Task<(bool IsSuccess, Exception e)> AddTeacherAsync(Guid id, Guid teacherId)
    {
        try
        {
            var teacher = await _context.Teachers.FirstOrDefaultAsync(d => d.Id == teacherId);
            if(teacher == default) throw new Exception("Teacher doesn't exist");
            var student = await GetByIdAsync(id);
            student.Teachers.Add(teacher);
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
            _logger.LogInformation("Ok");
            return (true, null);
        }
        catch (Exception e)
        {
            _logger.LogError($"Something went wrong:\n{e.Message}");
            return (false, e);
        }
    }
}