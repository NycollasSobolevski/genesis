using System.Collections.Generic;
using System.Threading.Tasks;
using Genesis.Domain.Models;

namespace Genesis.Domain.Services;

public interface IService<T> : IService<T,T>
    where T : IEntity, IConverter<T>;

public interface IService<T, TDto>
    where T : IEntity, IConverter<TDto>
{
    public TDto Add ( T entity );
    public Task<TDto> AddAsync ( T entity );

    public TDto Get ( int id );
    public Task<TDto> GetAsync ( int id ); 

    public IEnumerable<TDto> GetAll ();
    public Task<IEnumerable<TDto>> GetAllAsync();

    public IEnumerable<TDto> GetAll (int page, int limit);
    public Task<IEnumerable<TDto>> GetAllAsync (int page, int limit);

    public TDto Update ( int id, T entity );
    public Task<TDto> UpdateAsync ( int id,  T entity );

    public void Delete ( int id );
    public Task DeleteAsync ( int id );
}