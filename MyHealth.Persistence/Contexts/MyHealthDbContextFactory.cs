using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MyHealth.Persistence.Contexts;

namespace MyHealth.Persistence.Contexts;

public class MyHealthDbContextFactory : IDesignTimeDbContextFactory<MyHealthDbContext>
{
    public MyHealthDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<MyHealthDbContext>();

        optionsBuilder.UseSqlServer(
            "Server=(localdb)\\MSSQLLocalDB;Database=MyHealthDb;Trusted_Connection=True;MultipleActiveResultSets=true");

        return new MyHealthDbContext(optionsBuilder.Options);
    }
}