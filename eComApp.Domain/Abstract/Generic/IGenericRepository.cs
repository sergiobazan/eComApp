namespace eComApp.Domain.Abstract.Generic;

public interface IGenericRepository<TEntity> where TEntity : class
{
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity?> GetByIdAsync(Guid id);
    void Add(TEntity entity); 
    void UpdateAsync(TEntity entity);
    Task DeleteAsync(Guid id);
}