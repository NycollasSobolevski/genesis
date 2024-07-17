using Genesis.Core.Repositories;
using TestArea.Domain.Repositories;
using TestArea.Domain.Models;

namespace TestArea.Core.Repositories;

public class TestRepository(CNCTestContext context) 
    : BaseRepository<Test>(context), ITestRepository
{

}
