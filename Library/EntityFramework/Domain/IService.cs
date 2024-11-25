using System.Threading.Tasks;
using Genesis.Domain.Models;

namespace Genesis.Domain.Services;

public interface IService<T>
    where T : IEntity
{
    public Task<T> AddAsync ( T entity );
    public void Add ( T entity );

    public Task<T> GetAsync ( int id ); 
    public T Get ( int id );

    public Task<T> UpdateAsync ( int id,  T entity );
    public T Update ( int id, T entity );

    public Task DeleteAsync ( int id );
    public void Delete ( int id );
}