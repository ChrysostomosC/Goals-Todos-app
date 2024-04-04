using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using WebApplication_10._5.Models;

namespace WebApplication_10._5.Controllers
{
    public class GoalsController : Controller
    {
        public IActionResult Index()
        {
            var client = new MongoClient();
            var collection = client.GetDatabase("goals_application").GetCollection<Goal>("goals");
            List<Goal> goals = collection.Find(g => true).ToList();

            return View(goals);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Goal goal)
        {
            var client = new MongoClient();
            var collection = client.GetDatabase("goals_application").GetCollection<Goal>("goals");
            collection.InsertOne(goal);

            return Redirect("/Goals");
        }
    }
}
