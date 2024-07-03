using System.Linq;
using System.Threading.Tasks;
using Genesis.Domain.Models;
using Genesis.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Genesis.Core.Repositories;

public class BaseRepository<T> : IRepository<T>
    where T : IEntity
{

    protected DbContext context { get; set; }
    protected DbSet<T> table;

    public BaseRepository(DbContext context)
    {
        this.context = context;
        this.table = context.Set<T>();
    }

    public virtual T Add(T entity)
        => this.table.Add( entity ).Entity;

    public virtual async Task<T> AddAsync(T entity)
    {
        var result = await this.table.AddAsync( entity );
        return result.Entity;
    }
    public virtual IQueryable<T> Get()
        => this.table;

    public virtual IQueryable<T> GetAllNoTracking()
        => this.table.AsNoTracking();

    public virtual void Remove(T obj)
        => this.table.Remove( obj );

    public virtual void Save()
        => this.context.SaveChanges();

    public virtual Task SaveAsync()
        => this.context.SaveChangesAsync();

    public virtual T Update(T obj)
        => this.table.Update( obj ).Entity;

}