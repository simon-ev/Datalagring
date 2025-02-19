using Data.Services;
using Data.Contexts;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Data;

var services = new ServiceCollection()
    .AddDbContext<DataContext>(options =>
        options.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ProjectManagerDb;Trusted_Connection=True;"))
    .AddScoped<CustomerRepository>()
    .AddScoped<ProjectRepository>()
    .AddScoped<CustomerService>()
    .AddScoped<ProjectService>()
    .AddScoped<MenuDialogs>()
    .BuildServiceProvider();

var menuDialogs = services.GetRequiredService<MenuDialogs>();
await menuDialogs.MenuOptions();
