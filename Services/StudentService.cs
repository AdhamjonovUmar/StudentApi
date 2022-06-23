using Microsoft.EntityFrameworkCore;
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
    public Task<(bool IsSucces, Exception e)> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Student> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Student> GetByIdAsync(Guid id)
    {
        try
        {
            var student = _context.Students.FirstOrDefault(d => d.Id == id);
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

    public Task<(bool IsSucces, Exception e)> UpdateAsync(Student entity)
    {
        throw new NotImplementedException();
    }
}