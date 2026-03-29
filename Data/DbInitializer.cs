using Sit727MvcApp.Models;

namespace Sit727MvcApp.Data;

public static class DbInitializer
{
    public static void Seed(AppDbContext context)
    {
        if (context.Books.Any())
        {
            return;
        }

        context.Books.AddRange(
            new Book { Title = "Cloud Automation Technologies", Author = "SIT727" },
            new Book { Title = "Kubernetes Basics", Author = "Student Demo" },
            new Book { Title = "MVC Web Development", Author = "ASP.NET Core" });

        context.SaveChanges();
    }
}
