using System;
using System.Threading.Tasks;

namespace Students.Services;

public interface IEntityService<TEntity> where TEntity : class
{
    Task<(bool IsSucces, Exception e)> InsertAsync(TEntity entity);
    Task<(bool IsSucces, Exception e)> UpdateAsync(TEntity entity);
    Task<TEntity> GetByIdAsync(Guid id);
    Task<TEntity> GetAllAsync();
    Task<(bool IsSucces, Exception e)> DeleteAsync(Guid id);
}