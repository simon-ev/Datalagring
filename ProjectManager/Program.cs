using Data.Services;
using Data.Contexts;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjectManager;

var services = new ServiceCollection()
    .AddDbContext<DataContext>(options =>
        options.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\VS2022Projects\\DataStorage_Assignment\\Data\\Databases\\local_database.mdf;Integrated Security=True;Connect Timeout=30",
            options => options.EnableRetryOnFailure()))
    .AddScoped<CustomerRepository>()
    .AddScoped<ProjectRepository>()
    .AddScoped<CustomerService>()
    .AddScoped<ProjectService>()
    .AddScoped<MenuDialogs>()
    .BuildServiceProvider();

var menuDialogs = services.GetRequiredService<MenuDialogs>();
await menuDialogs.MenuOptions();
