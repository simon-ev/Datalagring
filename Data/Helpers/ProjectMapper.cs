using Data.Entities;
using Data.Models;


//Gjord av Chatgpt för åstadkomma en omvandling mellan Project och ProjectEntity

namespace Data.Helpers
{
    public static class ProjectMapper
    {
        public static ProjectEntity MapToEntity(Project model)
        {
            return new ProjectEntity
            {
                ProjectId = model.ProjectId,
                Title = model.Title,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                ProjectManager = model.ProjectManager,
                CustomerId = model.CustomerId,
                Service = model.Service,
                TotalCost = model.TotalCost,
                StatusId = model.StatusId
            };
        }

        public static Project MapToModel(ProjectEntity entity)
        {
            return new Project
            {
                ProjectId = entity.ProjectId,
                Title = entity.Title,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                ProjectManager = entity.ProjectManager,
                CustomerId = entity.CustomerId,
                Service = entity.Service,
                TotalCost = entity.TotalCost,
                StatusId = entity.StatusId
            };
        }
    }
}
