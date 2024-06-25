using CsvHelper;
using CsvHelper.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Globalization;

namespace FHV_App
{
    public class ImportCSV
    {
        [Obsolete]
        public async Task<bool> ImportData(IMongoCollection<BsonDocument> collection)
        {
            string filePath = GetFilePath();
            var records = ReadCsvFile(filePath);
            var bsonDocuments = ConvertToBsonDocuments(records);

            // Daten in MongoDB einfügen oder aktualisieren
            foreach (var document in bsonDocuments)
            {
                var filterx = Builders<BsonDocument>.Filter.Eq("DMV License Plate Number", document["DMV License Plate Number"]);
                var updateOptions = new UpdateOptions { IsUpsert = true }; // Insert if not exists
                var result = await collection.ReplaceOneAsync(filterx, document, updateOptions);
                Console.WriteLine($"Daten erfolgreich importiert! \n {result}");
                return true;
            }
            return false;
            
        }
        public static string GetFilePath()
        {
            string? filePath;
            do
            {
                try
                {
                    Console.WriteLine("Geben Sie den Pfad zur CSV-Datei ein:");
                    filePath = Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    filePath = null;
                }
                filePath = ValidatePath(filePath);
                
            } while (filePath == null);
            return filePath;
        }
        public static string? ValidatePath(string? filePath)
        {
            if (filePath == null || !filePath.EndsWith(".csv") || !System.IO.File.Exists(filePath))
                {
                    Console.WriteLine("Bitte geben Sie einen gültigen Pfad ein!");
                    return null;
                }
            else
            {
                return filePath;
            }
        }
        public static List<Vehicle> ReadCsvFile(string filePath)
        {
            using var reader = new StreamReader(filePath);
            using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HeaderValidated = null,
                MissingFieldFound = null,
                Delimiter = ","
            });
            var records = new List<Vehicle>();
            csv.Read();
            csv.ReadHeader();
            while (csv.Read())
            {
                var record = new Vehicle
                {
                    Active = csv.GetField<string>("Active"),
                    VehicleLicenseNumber = csv.GetField<string>("Vehicle License Number"),
                    Name = csv.GetField<string>("Name"),
                    LicenseType = csv.GetField<string>("License Type"),
                    ExpirationDate = csv.GetField<string>("Expiration Date"),
                    DmvLicensePlateNumber = csv.GetField<string>("DMV License Plate Number"),
                    VehicleVinNumber = csv.GetField<string>("Vehicle VIN Number"),
                    VehicleYear = csv.GetField<int>("Vehicle Year"),
                    BaseNumber = csv.GetField<string>("Base Number"),
                    BaseName = csv.GetField<string>("Base Name"),
                    BaseType = csv.GetField<string>("Base Type"),
                    Veh = csv.GetField<string>("VEH"),
                    BaseTelephoneNumber = csv.GetField<string>("Base Telephone Number"),
                    BaseAddress = csv.GetField<string>("Base Address"),
                    Reason = csv.GetField<string>("Reason"),
                    LastDateUpdated = csv.GetField<string>("Last Date Updated"),
                    LastTimeUpdated = csv.GetField<string>("Last Time Updated")
                };
                records.Add(record);
            }
            return records;
        }
        public static List<BsonDocument> ConvertToBsonDocuments(List<Vehicle> records)
        {
            var bsonDocuments = new List<BsonDocument>();
            foreach (var record in records)
            {
                var document = new BsonDocument
                {
                    { "Active", record.Active },
                    { "Vehicle License Number", record.VehicleLicenseNumber },
                    { "Name", record.Name },
                    { "License Type", record.LicenseType },
                    { "Expiration Date", record.ExpirationDate },
                    { "DMV License Plate Number", record.DmvLicensePlateNumber },
                    { "Vehicle VIN Number", record.VehicleVinNumber },
                    { "Vehicle Year", record.VehicleYear },
                    { "Base Number", record.BaseNumber },
                    { "Base Name", record.BaseName },
                    { "Base Type", record.BaseType },
                    { "VEH", record.Veh },
                    { "Base Telephone Number", record.BaseTelephoneNumber },
                    { "Base Address", record.BaseAddress },
                    { "Reason", record.Reason },
                    { "Last Date Updated", record.LastDateUpdated },
                    { "Last Time Updated", record.LastTimeUpdated }
                };
                bsonDocuments.Add(document);
            }
            return bsonDocuments;
        }
    }
}