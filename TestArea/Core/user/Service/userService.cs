using Genesis.Core.Services;
using Genesis.Core.Repositories;
using TestArea.Domain.Models;
using TestArea.Domain.Services;

namespace TestArea.Core.Services;

public class UserService(BaseRepository<User> repository)
    : BaseService<User> (repository), IUserService
{

}
