using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Students.Data;
using Students.Entities;

namespace Students.Services;

public class TeacherService : IEntityService<Teacher>
{
    private readonly ILogger<TeacherService> _logger;
    private readonly StudentDbContext _context;

    public TeacherService(ILogger<TeacherService> logger, StudentDbContext context)
    {
        _logger =logger;
        _context = context;
    }
    public Task<(bool IsSucces, Exception e)> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Teacher> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Teacher> GetByIdAsync(Guid id)
    {
        try
        {
            var teacher = _context.Teachers.FirstOrDefault(d => d.Id == id);
            return teacher;
        }
        catch(Exception e)
        {
            _logger.LogError(e.Message);
            return null;
        }
    }

    public async Task<(bool IsSucces, Exception e)> InsertAsync(Teacher entity)
    {
        try
        {
            await _context.Teachers.AddAsync(entity);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"New teacher was added to database with {entity.Id}");
            return(true, null);
        }
        catch (Exception e)
        {
            _logger.LogError($"New teacher was not added. Exception:\n{e.Message}");
            return(false, e);
        }
    }

    public Task<(bool IsSucces, Exception e)> UpdateAsync(Teacher entity)
    {
        throw new NotImplementedException();
    }
}