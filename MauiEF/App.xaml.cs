using System.Diagnostics;
using DbLibrary.Data;
using Microsoft.EntityFrameworkCore;

namespace MauiEF;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        SeedDatabase();
        MainPage = new AppShell();
    }

    private void SeedDatabase()
    {
        Debug.WriteLine("***************** START SEEDING *****************");
        if (MauiProgram.CreateMauiApp().Services.GetRequiredService<AppDbContext>() is AppDbContext appDbContext)
        {
            Debug.WriteLine("***************** Run migration *****************");
            appDbContext.Database.Migrate();

            if (!appDbContext.Groups.Any())
            {
                
                Debug.WriteLine("***************** Add Groups *****************");
                var groupOne = new Group
                {
                    Name = "GroupOne",
                    Persons = new List<Person>
                    {
                        new Person { FirstName = "Peter", LastName = "Doe"},
                        new Person { FirstName = "John", LastName = "Fox"}
                    }
                };
                appDbContext.Groups.Add(groupOne);
                appDbContext.SaveChanges();
            }
            
            Debug.WriteLine("***************** END SEEDING *****************");
        }
    }
}