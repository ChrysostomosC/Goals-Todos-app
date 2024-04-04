using MongoDB.Bson;

namespace WebApplication_10._5.Models
{
    public class Todo
    {
        public ObjectId Id { get; set; }
        public string Title { get; set; }
    }
}
