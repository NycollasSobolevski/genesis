using System.Threading.Tasks;
using Genesis.Domain.Models;
using System.Linq;

namespace Genesis.Domain.Repositories;

public interface IRepository<T>
    where T : IEntity
{
    IQueryable<T> Get();
	IQueryable<T> GetAllNoTracking();
    T Add(T obj);
    T Update(T obj);
    void Remove(T obj);
    void Detach(T obj);
    void Save();
    Task SaveAsync();

}