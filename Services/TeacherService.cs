using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
    public async Task<(bool IsSucces, Exception e)> DeleteAsync(Guid id)
    {
        try
        {
            var teacher = await GetByIdAsync(id);
            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Teacher was deleted with {id} id");
            return(true, null);
        }
        catch (Exception e)
        {
            _logger.LogError($"Student was not deleted.\nException: {e.Message}");
            return(false, e);
        }
    }

    public async Task<List<Teacher>> GetAllAsync()
    {
        return _context.Teachers.Include(p => p.Students).ToList();
    }

    public async Task<Teacher> GetByIdAsync(Guid id)
    {
        try
        {
            var teacher = _context.Teachers.Include(p => p.Students).FirstOrDefault(d => d.Id == id);
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

    public async Task<(bool IsSucces, Exception e)> UpdateAsync(Teacher entity)
    {
        try
        {
            _context.Teachers.Update(entity);
            await _context.SaveChangesAsync();
            return(true, null);
        }
        catch (Exception e)
        {
            _logger.LogError($"Teacher was not updated.\nError: {e.Message}");
            return(false, e);
        }
    }
}