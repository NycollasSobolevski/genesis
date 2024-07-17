using Genesis.Core.Repositories;
using TestArea.Domain.Repositories;
using TestArea.Domain.Models;

namespace TestArea.Core.Repositories;

public class AnswersRepository(CNCTestContext context) 
    : BaseRepository<Answers>(context), IAnswersRepository
{

}
