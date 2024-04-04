using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using WebApplication_10._5.Models;

namespace WebApplication_10._5.Controllers
{
    public class TodosController : Controller
    {
        public IActionResult Index()
        {
            var client = new MongoClient();
            var collection = client.GetDatabase("goals_application").GetCollection<Todo>("todos");
            List<Todo> todos = collection.Find(t => true).ToList();

            return View(todos);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Todo todo)
        {
            var client = new MongoClient();
            var collection = client.GetDatabase("goals_application").GetCollection<Todo>("todos");
            collection.InsertOne(todo);

            return Redirect("/Todos");
        }

        [HttpPost]
        public IActionResult Delete(string Id)
        {
            ObjectId todoId = new ObjectId(Id);
            var client = new MongoClient();
            var collection = client.GetDatabase("goals_application").GetCollection<Todo>("todos");
            collection.DeleteOne(t => t.Id == todoId);

            return Redirect("/Todos");
        }
    }
}
