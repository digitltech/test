using MongoDB.Bson.Serialization.Attributes;


namespace Test.Core
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }

        //string[] Genres = new string[] { "Комедия", "Усасы", "Трейлер" };
        public string[] Genres  { get; set; }
    }
}
