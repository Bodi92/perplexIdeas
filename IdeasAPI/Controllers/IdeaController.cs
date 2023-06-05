using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IdeasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdeaController : ControllerBase
    {
        private readonly IBankIdeaDal _bankIdeaDal;
        public IdeaController(IBankIdeaDal bankIdeaDal)
        {
            _bankIdeaDal = bankIdeaDal;
        }
        // GET api/<IdeaController>
        [HttpGet]
        public List<IdeaEntry> Get()
        {
            return _bankIdeaDal.GetIdeaEntries();
        }

        // POST api/<IdeaController>
        [HttpPost]
        public HttpResponseMessage Post([FromBody] PostData postData)
        {
            if (!ModelState.IsValid)
            {
                var badResponse = new HttpResponseMessage(HttpStatusCode.BadRequest);

                // Als de validatie mislukt, retourneer een BadRequest-respons met de validatiefouten
                badResponse.Content = new StringContent("Idea entry saved successfully.");
                return badResponse;
            }
            var ideaEntry = new IdeaEntry
            {
                Subject = postData.Subject,
                Description = postData.Description,
                Type = postData.Type,
                UserName = postData.UserName,
                UserId = postData.UserId,
                StartDate = postData.StartDate,
                EndDate = postData.EndDate,
                Categories = postData.Categories
            };
            this._bankIdeaDal.SaveEntry(ideaEntry);

            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent("Idea entry saved successfully.");
            return response;
        }
    }
}
