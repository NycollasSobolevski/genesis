# Genesis Library

Uma biblioteca que serve como base para api's, implementando um *BaseRepository\<T : IEntity>* e *BaseService\<T : IEntity>* a qual é dada toda a aplicação básica de CRUD 

## Code Structure
### How to Use 
Creating an entity 
```Csharp
public class User : IEntity
{
    public string Name { get; set; }
}
```
IEntity only contains the '*int Id { get; set; }*' property. Because all entities must have an id.


Creating repository:
```Csharp
public class UserRepository ( dbContext context )
    : BaseRepository<User> (context) {}
```
Creating service:
```Csharp
public class UserService( UserRepository Repository ) 
    : BaseService<User> (repository) {}
```
<br>
<br>

**Responsabilities**
- **Repositories**
    - Conection to database
- **Services**
    - Business rules


## Code Generator

A .NET Tool [GenesisTool]() use this library to generate code structure for all entities in the database by conection string. 

[![](https://img.shields.io/badge/Repository--green.svg)]("https://github.com/NycollasSobolevski/genesis")