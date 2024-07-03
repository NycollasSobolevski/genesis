using Genesis.Core.Repositories;
using TestArea.Domain.Repositories;
using TestArea.Domain.Models;

namespace TestArea.Core.Repositories;

public class TestRepository(DbContext context) 
    : BaseRepository<Test>(context), ITestRepository
{

}
