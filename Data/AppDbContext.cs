using Microsoft.EntityFrameworkCore;
using Sit727MvcApp.Models;

namespace Sit727MvcApp.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Book> Books => Set<Book>();
}
