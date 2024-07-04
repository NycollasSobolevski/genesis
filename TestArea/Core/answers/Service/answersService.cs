using Genesis.Core.Services;
using Genesis.Core.Repositories;
using TestArea.Domain.Models;
using TestArea.Domain.Services;

namespace TestArea.Core.Services;

public class AnswersService(BaseRepository<Answers> repository)
    : BaseService<Answers> (repository), IAnswersService
{

}
