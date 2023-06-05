using IdeaApp.Models;
using Microsoft.AspNetCore.Mvc;
using Factory;
using Domain;
using Domain.DtoPresentation;
using Microsoft.AspNetCore.Authorization;

namespace IdeaApp.Controllers
{
    public class IdeaController : Controller
    {
        private readonly ILogger<IdeaController> _logger;
        private readonly IWebHostEnvironment _hostEnvironment;
        private BankIdeasFactory _bankIdeasFactory;
        private Idea _idea;

        public IdeaController(ILogger<IdeaController> logger , IWebHostEnvironment hostEnvironment, BankIdeasFactory bankIdeasFactory, Idea idea)
        {
            _logger = logger;
            _hostEnvironment = hostEnvironment;
            _bankIdeasFactory = bankIdeasFactory;
            _idea = idea;
        }

        // GET: Ideas creator page
        [HttpGet]
        [Route("/Ideas/Create")]
        public IActionResult Create()
        {
            var model = new IdeasViewModel(); 
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult CreateEntry(IdeasViewModel ideasViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(ideasViewModel);
            }
            var ideaPreDto = new IdeaPresentationDto
            {
                UserId      = ideasViewModel.UserId,
                UserName    = ideasViewModel.UserName,
                Subject     = ideasViewModel.Subject,
                Description = ideasViewModel.Description,
                Type        = ideasViewModel.Type.ToString(),
                StartDate   = ideasViewModel.StartDate,
                EndDate     = ideasViewModel.EndDate,
                Categories  = ideasViewModel.Categories
            };
            _idea.SaveIdea(ideaPreDto);
            return RedirectToAction(nameof(Index));
        }
    }
}