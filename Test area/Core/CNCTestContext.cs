using Microsoft.EntityFrameworkCore;

using Test_area.Core.Mapping;

using Test_area.Domain.Models;

namespace Test_area.Core;

public partial class CNCTestContext : DbContext
{
    public CNCTestContext() {}

    public CNCTestContext(DbContextOptions<CNCTestContext> options)
         : base(options)
    {}
    public virtual DbSet<Test> TestList { get; set; }
    public virtual DbSet<User> UserList { get; set; }
    public virtual DbSet<Answers> AnswersList { get; set; }
    protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(@"Data Source=CA-C-0065D\SQLEXPRESS;Initial Catalog=CNCTest;Integrated Security=True;TrustServerCertificate=true");
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TestClassMap());
        modelBuilder.ApplyConfiguration(new UserClassMap());
        modelBuilder.ApplyConfiguration(new AnswersClassMap());
        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
