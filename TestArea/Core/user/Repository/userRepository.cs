using Genesis.Core.Repositories;
using TestArea.Domain.Repositories;
using TestArea.Domain.Models;

namespace TestArea.Core.Repositories;

public class UserRepository(CNCTestContext context) 
    : BaseRepository<User>(context), IUserRepository
{

}
