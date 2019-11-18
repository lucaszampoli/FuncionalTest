using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProductApi.Model
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string ProductName { get; set; }

        public string Industry { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}