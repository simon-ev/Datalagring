
using Data.Entities;
using Data.Helpers;
using Data.Models;
using Data.Repositories;

namespace Data.Services;


public class ProjectService
{
    private readonly ProjectRepository _projectRepository;
   
    public ProjectService(ProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }
    public async Task CreateProjectAsync(Project project)
    {
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
