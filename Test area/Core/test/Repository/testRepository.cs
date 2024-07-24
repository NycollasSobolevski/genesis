using Genesis.Core.Repositories;
using Test_area.Domain.Repositories;
using Test_area.Domain.Models;

namespace Test_area.Core.Repositories;

public class TestRepository(CNCTestContext context) 
    : BaseRepository<Test>(context), ITestRepository
{

}
