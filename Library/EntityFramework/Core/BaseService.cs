using System;
using System.Linq;
using System.Threading.Tasks;
using Genesis.Entity.Core.Repositories;
using Genesis.Domain.Models;
using Genesis.Domain.Repositories;
using Genesis.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace Genesis.Entity.Core.Service;

public class BaseService<T> : IService<T>
    where T : TEntity
{

    protected readonly IRepository<T> repository;

    protected BaseService( BaseRepository<T> _repository )
        => this.repository = _repository;


    public void Add(T entity)
    {
        var objectIfExists = this.repository!
            .GetAllNoTracking()
            .SingleOrDefault( dbObject => dbObject.Id == entity.Id );

        if ( objectIfExists is not null )
            throw new Exception("Object exists");

        this.repository.Add( entity );
        this.repository.Save( );
    }

    public async Task<T> AddAsync(T entity)
    {
        var objectIfExists = await this.repository!
            .GetAllNoTracking()
            .SingleOrDefaultAsync( dbObject => dbObject.Id == entity.Id );

        if ( objectIfExists is not null )
            throw new Exception("Object exists");

        var obj = this.repository.Add( entity );
        await this.repository.SaveAsync( );
        return obj;
    }

    public void Delete(T entity)
    {
        var objectIfExists = this.repository!
            .GetAllNoTracking()
            .SingleOrDefault( dbObject => dbObject.Id == entity.Id );

        if( objectIfExists is null )
            throw new Exception("Object not exists");
        
        this.repository.Remove( objectIfExists );
        this.repository.Save( );
    }

    public async Task DeleteAsync(T entity)
    {
        var objectIfExists = await this.repository!
            .GetAllNoTracking()
            .SingleOrDefaultAsync( dbObject => dbObject.Id == entity.Id );

        if( objectIfExists is null )
            throw new Exception("Object not exists");
        
        this.repository.Remove( objectIfExists );
        await this.repository.SaveAsync( );
    }

    public T Get(T entity)
    {
        var objectIfExists = this.repository!
            .GetAllNoTracking()
            .SingleOrDefault( dbObject => dbObject.Id == entity.Id );

        if ( objectIfExists is null )
            throw new Exception("Object not exists");

        return objectIfExists;
    }

    public async Task<T> GetAsync(T entity)
    {
        var objectIfExists = await this.repository!
            .GetAllNoTracking()
            .SingleOrDefaultAsync( dbObject => dbObject.Id == entity.Id );

        if ( objectIfExists is null )
            throw new Exception("Object not exists");

        return objectIfExists;
    }

    public T Update( int id, T entity )
    {
        var objectIfExists = this.repository!
            .GetAllNoTracking()
            .SingleOrDefault( dbObject => dbObject.Id == id );
        
        if ( objectIfExists is null )
            throw new Exception("Object not exists");

        var updated = this.repository.Update(entity);
        this.repository.Save();
        return updated;
    }   

    public async Task<T> UpdateAsync( int id, T entity )
    {
        var objectIfExists = await this.repository!
            .GetAllNoTracking()
            .SingleOrDefaultAsync( dbObject => dbObject.Id == id );
        
        if ( objectIfExists is null )
            throw new Exception("Object not exists");

        var updated = this.repository.Update(entity);
        await this.repository.SaveAsync();
        return updated;
    }
}