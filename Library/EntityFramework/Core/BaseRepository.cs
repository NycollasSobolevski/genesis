using System.Linq;
using System.Threading.Tasks;
using Genesis.Domain.Models;
using Genesis.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Genesis.Entity.Core.Repositories;

public class BaseRepository<T> : IRepository<T>
    where T : TEntity
{

    protected DbContext context { get; set; }
    protected DbSet<T> table;

    public T Add(T entity)
        => this.table.Add( entity ).Entity;

    public async Task<T> AddAsync(T entity)
    {
        var result = await this.table.AddAsync( entity );
        return result.Entity;
    }
    public IQueryable<T> Get()
        => this.table;

    public IQueryable<T> GetAllNoTracking()
        => this.table.AsNoTracking();

    public void Remove(T obj)
        => this.table.Remove( obj );

    public void Save()
        => this.context.SaveChanges();

    public Task SaveAsync()
        => this.context.SaveChangesAsync();

    public T Update(T obj)
        => this.table.Update( obj ).Entity;

}