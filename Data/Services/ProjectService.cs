using System.Linq;
using Data.Entities;
using Data.Helpers;
using Data.Models;
using Data.Repositories;

namespace Data.Services;


public class ProjectService(ProjectRepository projectRepository, CustomerRepository customerRepository)
{
    private readonly ProjectRepository _projectRepository = projectRepository;
    private readonly CustomerRepository _customerRepository = customerRepository;

    public async Task<int> GetProjectCountAsync()
    {
        var projects = await _projectRepository.GetAllAsync();
        return projects.Count();
    }
    public async Task CreateProjectAsync(Project project)
    {
        

        //Chatgpt för att skapa en ny customer om namnet man har angett inte finns i databasen när man skapar ett nytt projekt
        var existingCustomer = await _customerRepository.GetAsync(c => c.CustomerName == project.CustomerName);

        if (existingCustomer == null)
        {

            var newCustomer = new CustomerEntity { CustomerName = project.CustomerName };
            await _customerRepository.AddAsync(newCustomer);
            project.CustomerId = newCustomer.Id;
        }
        else
        {
            project.CustomerId = existingCustomer.Id;
        }


        var projectEntity = ProjectMapper.MapToEntity(project);
        await _projectRepository.AddAsync(projectEntity);
    }

    public async Task<IEnumerable<Project>> GetProjectsAsync()
    {
        var projectEntities = await _projectRepository.GetAllAsync();
        return projectEntities.Select(ProjectMapper.MapToModel);
    }
    public async Task<Project?> GetProjectByIdAsync(int id)
    {
        var projectEntity = await _projectRepository.GetAsync(x => x.ProjectId == id);
        return projectEntity != null ? ProjectMapper.MapToModel(projectEntity) : null;
    }
    public async Task<bool> UpdateProjectAsync(Project project)
    {
        var projectEntity = ProjectMapper.MapToEntity(project);
        await _projectRepository.UpdateAsync(projectEntity);
        return true;
    }
    public async Task<bool> DeleteProjectAsync(int id)
    {
        var projectEntity = await _projectRepository.GetAsync(x => x.ProjectId == id);
        if (projectEntity == null)
        {
            return false;
        }
        await _projectRepository.RemoveAsync(projectEntity);
        return true;
    }
}
