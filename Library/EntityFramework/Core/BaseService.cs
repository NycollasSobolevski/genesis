using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Genesis.Core.Repositories;
using Genesis.Domain.Models;
using Genesis.Domain.Repositories;
using Genesis.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace Genesis.Core.Services;

public class BaseService<T>(BaseRepository<T> repository) 
    : BaseService<T,T>(repository)
        where T : IEntity, IConverter<T>;

public class BaseService<T, TDto>(BaseRepository<T> repository) : IService<T, TDto>
    where T : IEntity, IConverter<TDto>
{

    protected readonly IRepository<T> Repository = repository;


    public virtual TDto Add(T entity)
    {
        var objectIfExists = this.Repository!
            .GetAllNoTracking()
            .SingleOrDefault( dbObject => dbObject.Id == entity.Id );

        if ( objectIfExists is not null )
            throw new Exception("Object exists");

        TDto res = this.Repository.Add( entity ).Convert();
        this.Repository.Save( );

        return res;
    }

    public virtual async Task<TDto> AddAsync(T entity)
    {
        var objectIfExists = await this.Repository!
            .GetAllNoTracking()
            .SingleOrDefaultAsync( dbObject => dbObject.Id == entity.Id );

        if ( objectIfExists is not null )
            throw new Exception("Object exists");

        var obj = this.Repository.Add( entity );
        await this.Repository.SaveAsync( );
        return obj.Convert();
    }

    public virtual TDto Get(int id)
    {
        var objectIfExists = this.Repository!
            .GetAllNoTracking()
            .SingleOrDefault( dbObject => dbObject.Id == id );

        if ( objectIfExists is null )
            throw new Exception("Object not exists");

        return objectIfExists.Convert();
    }

    public virtual async Task<TDto> GetAsync(int id)
    {
        var objectIfExists = await this.Repository!
            .GetAllNoTracking()
            .SingleOrDefaultAsync( dbObject => dbObject.Id == id );

        if ( objectIfExists is null )
            throw new Exception("Object not exists");

        return objectIfExists.Convert();
    }

	public IEnumerable<TDto> GetAll()
        => this.Repository.GetAllNoTracking().Select(e => e.Convert()).ToList() ?? [];

    public async Task<IEnumerable<TDto>> GetAllAsync()
        => await this.Repository.GetAllNoTracking().Select(e => e.Convert()).ToListAsync() ?? [];

	public IEnumerable<TDto> GetAll(int page, int limit)
		=> [.. this.Repository.GetAllNoTracking().Skip( page * limit ).Take( limit ).Select(e => e.Convert())];

	public async Task<IEnumerable<TDto>> GetAllAsync(int page, int limit)
	    => await this.Repository.GetAllNoTracking().Skip(page * limit).Take( limit ).Select(e => e.Convert()).ToListAsync();

	public virtual TDto Update( int id, T entity )
    {
        var objectIfExists = this.Repository!
            .GetAllNoTracking()
            .SingleOrDefault( dbObject => dbObject.Id == id );
        
        if ( objectIfExists is null )
            throw new Exception("Object not exists");

        var updated = this.Repository.Update(entity);
        this.Repository.Save();
        this.Repository.Detach(updated);
        return updated.Convert();
    }   

    public virtual async Task<TDto> UpdateAsync( int id, T entity )
    {
        var objectIfExists = await this.Repository!
            .GetAllNoTracking()
            .SingleOrDefaultAsync( dbObject => dbObject.Id == id );
        
        if ( objectIfExists is null )
            throw new Exception("Object not exists");

        var updated = this.Repository.Update(entity);
        
        await this.Repository.SaveAsync();
        this.Repository.Detach(updated);
        return updated.Convert();
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