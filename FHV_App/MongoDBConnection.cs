using MongoDB.Bson;
using MongoDB.Driver;

namespace FHV_App {
    public class MongoDBConnection {
        
        private readonly IMongoDatabase _database;

        public MongoDBConnection(string connectionString, string databaseName) {
            var dbClient = new MongoClient(connectionString);
            _database = dbClient.GetDatabase(databaseName);
        }

        public IMongoCollection<BsonDocument> GetCollection(string collectionName) {
            return _database.GetCollection<BsonDocument>(collectionName);
        }
    }
}
