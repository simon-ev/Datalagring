
using Data.Repositories;
using ProjectManager.Models;

namespace Business.Services;

public class ProjectService
{
    private readonly ProjectRepository _projectRepository;
    public ProjectService(ProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }
    public async Task CreateProjectAsync(Project project)
    {
        await _projectRepository.AddAsync(project);
    }
    public async Task<IEnumerable<Project>> GetProjectsAsync()
    {
        return await _projectRepository.GetAllAsync();
    }
    public async Task<Project?> GetProjectByIdAsync(int id)
    {
        return await _projectRepository.GetAsync(x => x.ProjectId == id);
    }
    public async Task<bool> UpdateProjectAsync(Project project)
    {
        return await _projectRepository.UpdateAsync(project);
    }
    public async Task<bool> DeleteProjectAsync(int id)
    {
        return await _projectRepository.DeleteAsync(id);
    }
}
