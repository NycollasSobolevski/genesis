using Genesis.Domain.Models;

namespace Test_area.Domain.Models;

public partial class Answers : IEntity
{
  public string? Student { get; set; }
  public string? Answer { get; set; }
  public int Attempts { get; set; }
  public System.TimeSpan Time { get; set; }
  public int IdTest { get; set; }
  public bool IsActive { get; set; }
  public int? Grade { get; set; }
}
