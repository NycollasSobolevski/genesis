using Genesis.Domain.Models;

namespace TestArea.Domain.Models;

public partial class Test : TEntity
{
    public global::System.Int32 Id {get;set;}
    public string
    ? Code {get;set;}
    public System.String? Title {get;set;}
    public System.String? Description {get;set;}
    public System.Int32 Attempts {get;set;}
    public System.String? Question {get;set;}
    public System.String? Answer {get;set;}
    public System.Boolean IsActive {get;set;}
    public System.Int32? Errors {get;set;}
}