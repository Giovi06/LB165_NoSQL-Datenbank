using MongoDB.Bson;
using MongoDB.Driver;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using FHV_App;

class Programm
{
    static void Main(string[] args)
    {
        string connectionString = "mongodb://127.0.0.1:27017/?directConnection=true&serverSelectionTimeoutMS=2000&appName=mongosh+1.8.";
        MongoDBConnection connection = new(connectionString, "FHV");
        IMongoCollection<BsonDocument> vehiclesCollection = connection.GetCollection("Vehicles");

        var filter = Builders<BsonDocument>.Filter.Eq("Active", "YES");
        var projection = Builders<BsonDocument>.Projection.Include("Vehicle License Number").Include("Base Name").Exclude("_id");

        var activeVehicles = vehiclesCollection.Find(filter).Project(projection).ToList();


        foreach (var vehicle in activeVehicles)
        {
            Console.WriteLine(vehicle.ToString());
        }

        Console.WriteLine($"\n{activeVehicles.Count} Fahrzeuge gefunden!");

    }
}