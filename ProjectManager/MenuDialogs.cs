using Data.Models;
using Data.Services;


namespace ProjectManager;

public class MenuDialogs(CustomerService customerService, ProjectService projectService)
{
    private readonly CustomerService _customerService = customerService;
    private readonly ProjectService _projectService = projectService;

    public async Task MenuOptions()
    {
        while (true)
        {
            Console.WriteLine("1. Create New Customer");
            Console.WriteLine("2. Create New Project");
            Console.WriteLine("3. Get All Customers");
            Console.WriteLine("4. Get All Projects");
            Console.WriteLine("5. Get Customer by Name");
            Console.WriteLine("6. Get Project by Name");
            Console.Write("Enter your choice: ");
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    await CreateCustomer();
                    break;
                case "2":
                    await CreateNewProject();
                    break;
                case "3":
                    await GetAllCustomers();
                    break;
                case "4":
                    await GetAllProjects();
                    break;
                case "5":
                    await GetCustomerById();
                    break;
                case "6":
                    await GetProjectById();
                    break;
              
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }

    }

    public async Task GetProjectById()
    {
        Console.Write("Enter Project Name ");
        if (int.TryParse(Console.ReadLine(), out int projectId))
        {
            var project = await _projectService.GetProjectByIdAsync(projectId);
            if (project == null)
            {
                Console.WriteLine("Project not found.");
                Console.ReadLine();
                return;
            }

            await EditProject(project);
        }
        
    }

    public async Task GetAllProjects()
    {
        //Skriven av chatgpt för att hämta alla projekt och sedan kunna redigera dem
        var projects = await _projectService.GetProjectsAsync();
        if (!projects.Any())
        {
            Console.WriteLine("No projects found.");
            Console.ReadLine();
            return;
        }

        Console.WriteLine("Projects:");
        foreach (var proj in projects)
        {
            var product = proj.ProductId.HasValue ? $"Product ID: {proj.ProductId.Value}" : "No product associated";

            Console.WriteLine($"- {proj.Title} (Start: {proj.StartDate:yyyy-MM-dd}, End: {proj.EndDate:yyyy-MM-dd})");
        }

        Console.Write("Enter the Project Name to edit (or press Enter to go back): ");
        var projectName = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(projectName))
        {
            return;
        }

        var project = projects.FirstOrDefault(p => p.Title.Equals(projectName, StringComparison.OrdinalIgnoreCase));
        if (project == null)
        {
            Console.WriteLine("Project not found.");
            Console.ReadLine();
            return;
        }

        await EditProject(project);
    }

    public async Task EditProject(Project project)
    {
        Console.WriteLine($"Editing Project: {project.Title}");

        Console.Write("Enter new name (leave blank to keep current): ");
        var newTitle = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newTitle)) project.Title = newTitle;

        Console.Write("Enter new status (leave blank to keep current): ");
        var newStatus = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newStatus)) project.Status = newStatus;

        Console.Write("Enter new project manager (leave blank to keep current): ");
        var newProjectManager = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newProjectManager)) project.ProjectManager = newProjectManager;

        await _projectService.UpdateProjectAsync(project);
        Console.WriteLine("Project updated successfully!");
        Console.ReadLine();
    }
    public async Task CreateCustomer()
    {
        Console.Write("Enter Customer Name: ");
        var customerName = Console.ReadLine();
        var customerRegistrationForm = new CustomerRegistrationForm
        {
            CustomerName = customerName!
        };
        await _customerService.CreateCustomerAsync(customerRegistrationForm);
        Console.WriteLine("Customer created successfully! Press Enter to return to the main menu...");
        Console.ReadLine();
    }

    public async Task CreateNewProject()
    {
        Console.Clear();
        Console.Write("Enter Project Name: ");
        var title = Console.ReadLine();

        Console.Write("Enter Customer Name: ");
        var customerName = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(customerName))
        {
            Console.WriteLine("Customer name cannot be empty.");
            return;
        }

        var customer = await _customerService.GetCustomerByNameAsync(customerName);
        if (customer == null)
        {
            Console.WriteLine("Customer not found. A new customer will be created.");
            var customerRegistrationForm = new CustomerRegistrationForm
            {
                CustomerName = customerName
            };
            await _customerService.CreateCustomerAsync(customerRegistrationForm);
            customer = await _customerService.GetCustomerByNameAsync(customerName);
        }

        Console.Write("Enter Project Manager Name: ");
        var projectManager = Console.ReadLine();

        Console.Write("Enter Project Description: ");
        var description = Console.ReadLine();

        DateTime startDate;
        while (true)
        {
            Console.Write("Enter Project Start Date (yyyy-MM-dd): ");
            if (DateTime.TryParse(Console.ReadLine(), out startDate))
            {
                break;
            }
            Console.WriteLine("Invalid date format. Please enter a valid date (yyyy-MM-dd).");
        }

        DateTime endDate;
        while (true)
        {
            Console.Write("Enter Project End Date (yyyy-MM-dd): ");
            if (DateTime.TryParse(Console.ReadLine(), out endDate))
            {
                if (endDate >= startDate)
                {
                    break;
                }
                Console.WriteLine("End date must be after the start date.");
            }
            else
            {
                Console.WriteLine("Invalid date format. Please enter a valid date (yyyy-MM-dd).");
            }
        }

        Console.Write("Enter Project Status (e.g. Not Started, Active, On Hold, Completed): ");
        var status = Console.ReadLine();

        Console.Write("Enter Service: ");
        var service = Console.ReadLine();

        Console.Write("Enter Total Cost: ");
        if (!decimal.TryParse(Console.ReadLine(), out var totalCost))
        {
            Console.WriteLine("Invalid input for Total Cost. Please enter a numeric value.");

        }

        var project = new Project
        {
            Title = title!,
            CustomerName = customer!.CustomerName,
            CustomerId = customer.Id,
            ProjectManager = projectManager!,
            Description = description,
            StartDate = startDate,
            EndDate = endDate,
            Status = status!,
            Service = service!,
            TotalCost = (int)totalCost,
        };

        await _projectService.CreateProjectAsync(project);
        Console.WriteLine("Project created successfully!");
        Console.ReadLine();
    }
    public async Task GetAllCustomers()
    {
        var customers = await _customerService.GetCustomersAsync();
        if (!customers.Any())
        {
            Console.WriteLine("No customers found.");
            Console.ReadLine();
            return;
        }

        foreach (var customer in customers)
        {
            Console.WriteLine($"ID: {customer!.Id}, Name: {customer.CustomerName}");
        }

        Console.Write("Enter the Customer ID to edit (or press Enter to go back): ");
        var input = Console.ReadLine();
        if (int.TryParse(input, out int customerId))
        {
            await EditCustomer(customerId);
        }
    }

    public async Task GetCustomerById()
    {
        Console.Write("Enter Customer Name: ");
        if (int.TryParse(Console.ReadLine(), out int customerId))
        {
            await EditCustomer(customerId);
        }
        else
        {
            Console.WriteLine("Invalid Name. Press Enter to return.");
            Console.ReadLine();
        }
    }

    public async Task EditCustomer(int customerId)
    {
        var customer = await _customerService.GetCustomerByIdAsync(customerId);
        if (customer == null)
        {
            Console.WriteLine("Customer not found.");
            Console.ReadLine();
            return;
        }

        Console.WriteLine($"Editing Customer: {customer.CustomerName}");
        Console.Write("Enter new name (leave blank to keep current): ");
        var newName = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(newName))
        {
            customer.CustomerName = newName;
            await _customerService.UpdateCustomerAsync(customer);
            Console.WriteLine("Customer updated successfully!");
        }
        else
        {
            Console.WriteLine("No changes made.");
        }

        Console.WriteLine("Press Enter to return to the main menu...");
        Console.ReadLine();
    }
}
