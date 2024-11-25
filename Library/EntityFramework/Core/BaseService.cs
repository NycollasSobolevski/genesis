using System;
using System.Linq;
using System.Threading.Tasks;
using Genesis.Core.Repositories;
using Genesis.Domain.Models;
using Genesis.Domain.Repositories;
using Genesis.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace Genesis.Core.Services;

public class BaseService<T>(BaseRepository<T> repository) : IService<T>
    where T : IEntity
{

    protected readonly IRepository<T> Repository = repository;


    public virtual void Add(T entity)
    {
        var objectIfExists = this.Repository!
            .GetAllNoTracking()
            .SingleOrDefault( dbObject => dbObject.Id == entity.Id );

        if ( objectIfExists is not null )
            throw new Exception("Object exists");

        this.Repository.Add( entity );
        this.Repository.Save( );
    }

    public virtual async Task<T> AddAsync(T entity)
    {
        var objectIfExists = await this.Repository!
            .GetAllNoTracking()
            .SingleOrDefaultAsync( dbObject => dbObject.Id == entity.Id );

        if ( objectIfExists is not null )
            throw new Exception("Object exists");

        var obj = this.Repository.Add( entity );
        await this.Repository.SaveAsync( );
        return obj;
    }

    public virtual T Get(int id)
    {
        var objectIfExists = this.Repository!
            .GetAllNoTracking()
            .SingleOrDefault( dbObject => dbObject.Id == id );

        if ( objectIfExists is null )
            throw new Exception("Object not exists");

        return objectIfExists;
    }

    public virtual async Task<T> GetAsync(int id)
    {
        var objectIfExists = await this.Repository!
            .GetAllNoTracking()
            .SingleOrDefaultAsync( dbObject => dbObject.Id == id );

        if ( objectIfExists is null )
            throw new Exception("Object not exists");

        return objectIfExists;
    }
    
    public virtual T Update( int id, T entity )
    {
        var objectIfExists = this.Repository!
            .GetAllNoTracking()
            .SingleOrDefault( dbObject => dbObject.Id == id );
        
        if ( objectIfExists is null )
            throw new Exception("Object not exists");

        var updated = this.Repository.Update(entity);
        this.Repository.Save();
        this.Repository.Detach(updated);
        return updated;
    }   

    public virtual async Task<T> UpdateAsync( int id, T entity )
    {
        var objectIfExists = await this.Repository!
            .GetAllNoTracking()
            .SingleOrDefaultAsync( dbObject => dbObject.Id == id );
        
        if ( objectIfExists is null )
            throw new Exception("Object not exists");

        var updated = this.Repository.Update(entity);
        
        await this.Repository.SaveAsync();
        this.Repository.Detach(updated);
        return updated;
    }
    
    public virtual void Delete(int id)
    {
        var objectIfExists = this.Repository!
            .GetAllNoTracking()
            .SingleOrDefault( dbObject => dbObject.Id == id );

        if( objectIfExists is null )
            throw new Exception("Object not exists");
        
        this.Repository.Remove( objectIfExists );
        this.Repository.Save( );
    }

    public virtual async Task DeleteAsync(int id)
    {
        var objectIfExists = await this.Repository!
            .GetAllNoTracking()
            .SingleOrDefaultAsync( dbObject => dbObject.Id == id );

        if( objectIfExists is null )
            throw new Exception("Object not exists");
        
        this.Repository.Remove( objectIfExists );
        await this.Repository.SaveAsync( );
    }

}