using System.Threading.Tasks;
using Genesis.Domain.Models;
using System.Linq;

namespace Genesis.Domain.Repositories;

public interface IRepository<T>
    where T : TEntity
{
    IQueryable<T> Get();
    IQueryable<T> GetAllNoTracking();
    T Add(T obj);
    void Remove(T obj);
    T Update(T obj);
    void Save();
    Task SaveAsync();

}