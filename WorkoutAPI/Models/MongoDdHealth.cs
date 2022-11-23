using MongoDB.Bson;

namespace Models
{
    public class MongoDdHealth
    {
        public ObjectId _id { get; set; }
        public bool CanRead { get; set; }
    }
}
