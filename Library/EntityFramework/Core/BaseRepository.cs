using System.Linq;
using System.Threading.Tasks;
using Genesis.Domain.Models;
using Genesis.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Genesis.Core.Repositories;

public class BaseRepository<T>(DbContext context) : IRepository<T>
    where T : IEntity
{

    protected DbContext Context { get; set; } = context;
    protected DbSet<T> Table = context.Set<T>();

    public virtual T Add(T entity)
        => this.Table.Add( entity ).Entity;

    public virtual async Task<T> AddAsync(T entity)
    {
        var result = await this.Table.AddAsync( entity );
        return result.Entity;
    }
    public virtual IQueryable<T> Get()
        => this.Table;

    public virtual IQueryable<T> GetAllNoTracking()
        => this.Table.AsNoTracking();

	public virtual void Remove(T obj)
        => this.Table.Remove( obj );

    public void Detach(T obj)
        => this.Context.Entry(obj).State = EntityState.Detached;

    public virtual void Save()
        => this.Context.SaveChanges();

    public virtual Task SaveAsync()
        => this.Context.SaveChangesAsync();

    public virtual T Update(T obj)
        => this.Table.Update( obj ).Entity;
    

}