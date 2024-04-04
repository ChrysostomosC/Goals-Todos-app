using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Diagnostics;
using WebApplication_10._5.Models;

namespace WebApplication_10._5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var client = new MongoClient();
            var todosCollection = client.GetDatabase("goals_application").GetCollection<Todo>("todos");
            List<Todo> todos = todosCollection.Find(t => true).ToList();

            var goalsCollection = client.GetDatabase("goals_application").GetCollection<Goal>("goals");
            List<Goal> goals = goalsCollection.Find(t => true).ToList();

            HomeIndexViewModel model = new HomeIndexViewModel();
            model.Todos = todos;
            model.Goals = goals;

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
