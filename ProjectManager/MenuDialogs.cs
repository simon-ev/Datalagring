

using Business.Services;

namespace Data;

public class MenuDialogs(CustomerService customerService, ProjectService projectService)
{
    private readonly CustomerService _customerService = customerService;
    private readonly ProjectService _projectService = projectService;

    public async Task MenuOptions()
    {
        Console.WriteLine("1. Create Customer");
        Console.WriteLine("2. Get Customers");
        Console.WriteLine("3. Get Customer By Id");
        Console.WriteLine("4. Get Customer By Name");
        Console.WriteLine("5. Update Customer");
        Console.WriteLine("6. Delete Customer");
        Console.WriteLine("7. Create Project");
        Console.WriteLine("8. Get Projects");
        Console.WriteLine("9. Get Project By Id");
        Console.WriteLine("10. Update Project");
        Console.WriteLine("11. Delete Project");
        Console.WriteLine("12. Exit");
        Console.Write("Enter your choice: ");
        var choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                await CreateCustomer();
                break;
            case "2":
                await GetCustomers();
                break;
            case "3":
                await GetCustomerById();
                break;
            case "4":
                await GetCustomerByName();
                break;
            case "5":
                await UpdateCustomer();
                break;
            case "6":
                await DeleteCustomer();
                break;
            case "7":
                await CreateProject();
                break;
            case "8":
                await GetProjects();
                break;
            case "9":
                await GetProjectById();
                break;
            case "10":
                await UpdateProject();
                break;
            case "11":
                await DeleteProject();
                break;
            case "12":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid choice");
                break;
        }
    }
}
