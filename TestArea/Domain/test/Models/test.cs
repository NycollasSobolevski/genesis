using Genesis.Domain.Models;

namespace TestArea.Domain.Models;

public partial class Test : IEntity
{
  public string? Code { get; set; }
  public string? Title { get; set; }
  public string? Description { get; set; }
  public int Attempts { get; set; }
  public string? Question { get; set; }
  public string? Answer { get; set; }
  public bool IsActive { get; set; }
  public int? Errors { get; set; }
}
