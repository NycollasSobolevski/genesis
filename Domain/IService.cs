using System.Threading.Tasks;
using Genesis.Domain.Models;

namespace Genesis.Domain.Services;

public interface IService<T>
    where T : TEntity
{
    public Task<T> AddAsync ( T entity );
    public void Add ( T entity );

    public Task<T> GetAsync ( T entity ); 
    public T Get ( T entity );

    public Task<T> UpdateAsync ( int id,  T entity );
    public T Update ( int id, T entity );

    public Task DeleteAsync ( T entity );
    public void Delete ( T entity );
}