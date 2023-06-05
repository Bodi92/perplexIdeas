using Domain.DtoInfrastructure;
using Domain.Interfaces;
using System.Net.Http.Headers;
using System.Text;


namespace Infrastructure
{
    public class BankIdea : IBankIdeas
    {
        public void SaveIdea(IdeaInfrastructureDto ideaInfrastructureDto)
        {
            try
            {
                var apiUrl = "http://localhost:5000/api/Idea";

                var json = Newtonsoft.Json.JsonConvert.SerializeObject(ideaInfrastructureDto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            }
            catch (Exception ex) {
                throw ex;    
            }
        }
    }
}
