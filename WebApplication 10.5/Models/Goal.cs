using MongoDB.Bson;

namespace WebApplication_10._5.Models
{
    public class Goal
    {
        public ObjectId Id { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
    }
}
