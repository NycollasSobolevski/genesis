using Genesis.Domain.Models;

namespace Test_area.Domain.Models;

public partial class User : IEntity
{
  public string? Name { get; set; }
  public string? Identification { get; set; }
  public string? Password { get; set; }
  public string? Salt { get; set; }
  public bool Admin { get; set; }
  public bool IsActive { get; set; }
}
