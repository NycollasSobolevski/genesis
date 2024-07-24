using Genesis.Core.Services;
using Genesis.Core.Repositories;
using Test_area.Domain.Models;
using Test_area.Domain.Services;

namespace Test_area.Core.Services;

public class TestService(BaseRepository<Test> repository)
    : BaseService<Test> (repository), ITestService
{

}
