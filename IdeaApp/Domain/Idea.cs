using Domain.DtoPresentation;
using Domain.Interfaces;
using Microsoft.Practices.EnterpriseLibrary.Common.Utility;

namespace Domain
{
    public class Idea
    {
        private int id;
        private string subject;
        private string description;
        private Type type;
        private string username;
        private int userId;
        private DateTime? startDate;
        private DateTime? endDate;
        private string categories;
        private IBankIdeas _bankIdeas;
        public int Id { get { return id; } private set { id = value; } }
        public string Subject { get { return subject; } private set { subject = value; } }
        public string Description { get { return description; } private set { description = value; } }  
        public Type Type { get { return type; } private set { type = value; } }
        public string Username { get { return username; } private set { username = value; } }
        public int UserId { get { return userId; } private set { userId = value; } }
        public DateTime? StartDate { get { return startDate;} private set { startDate = value; } }  
        public DateTime? EndDate { get { return endDate;} private set { endDate = value; } }
        public string Categories { get {  return categories; } private set { categories = value; } }
        

        public void SaveIdea(IdeaPresentationDto ideaPresentationDto)
        {
            this._bankIdeas.SaveIdea(
                new DtoInfrastructure.IdeaInfrastructureDto
                {
                    UserId = ideaPresentationDto.UserId,
                    UserName = ideaPresentationDto.UserName,
                    Subject = ideaPresentationDto.Subject,
                    Description = ideaPresentationDto.Description,
                    Type = ideaPresentationDto.Type,
                    StartDate = ideaPresentationDto.StartDate,
                    EndDate = ideaPresentationDto.EndDate,
                    Categories = ideaPresentationDto.Categories
                });
        }
    }
}
