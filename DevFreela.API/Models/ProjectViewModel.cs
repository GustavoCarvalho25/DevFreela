﻿using DevFreela.API.Entities;

namespace DevFreela.API.Models
{
    public class ProjectViewModel
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public int IdClient { get; private set; }
        public int IdFreelancer { get; private set; }
        public string ClientName { get; private set; }
        public string FreelancerName { get; private set; }
        public decimal TotalCost { get; private set; }
        public List<string>? Comments { get; private set; }

        public ProjectViewModel(
            int id,
            string title,
            string description,
            int idClient,
            int idFreelancer,
            string clientName,
            string freelancerName,
            decimal totalCost,
            List<ProjectComment> comments)
        {
            Id = id;
            Title = title;
            Description = description;
            IdClient = idClient;
            IdFreelancer = idFreelancer;
            ClientName = clientName;
            FreelancerName = freelancerName;
            TotalCost = totalCost;
            Comments = comments.Select(c => c.Content).ToList();
        }

        public static ProjectViewModel FromEntity(Project project)
        => new ProjectViewModel(
                project.Id,
                project.Title,
                project.Description,
                project.IdClient,
                project.IdFreelancer,
                project.Client.FullName,
                project.Freelancer.FullName,
                project.TotalCost,
                project.Comments
            );
    }
}
