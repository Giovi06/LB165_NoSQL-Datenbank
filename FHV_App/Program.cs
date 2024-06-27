using MongoDB.Bson;
using MongoDB.Driver;
using System;
using FHV_App;

class Programm
{
    [Obsolete]
    public static async Task Main()
    {

        string connectionString = "mongodb://127.0.0.1:27017/?directConnection=true&serverSelectionTimeoutMS=2000&appName=mongosh+1.8.";
        MongoDBConnection connection = new(connectionString, "FHV");
        IMongoCollection<BsonDocument> vehiclesCollection = connection.GetCollection("Vehicles");








        bool answer;
        answer = ValidateYesOrNo(GetUserInput("Möchtest du neue Daten importieren? \n Ja oder Nein? [Y/N]"));

        if (answer)
        {
            ImportCSV importCSV = new();
            bool done = true;
            done = await importCSV.ImportData(vehiclesCollection);

            while (done)
            {
                Console.WriteLine("Daten werden importiert...");
            }
        }
        else if (!answer)
        {
            answer = ValidateYesOrNo(GetUserInput("Möchtest du die Fahrzeuge anhand der Kriterien anzeigen? \n Ja oder Nein? [Y/N]"));

            if (!answer)
            {
                Console.WriteLine("Programm wird beendet!");
                System.Environment.Exit(0);
            }
        }


        Vehicle vehicle1 = new();
        var projectionBuidler = Builders<BsonDocument>.Projection.Exclude("_id");
        var filterBuilder = Builders<BsonDocument>.Filter;
        var projection1 = projectionBuidler;
        var filter1 = filterBuilder.Empty;

        string UserProjectionQuestion = "Möchtest du Wert anzeigen? \n Ja oder Nein? [Y/N]";

        Console.WriteLine("Gib pro angezeigtes Kriterium dein Wert ein. \n Wenn nichts eingegeben wird, wird dieses Kriterium nicht berücksichtigt.");

        vehicle1.Active = ValidateuserInput(GetUserInput("Aktiv: [YES/NO]"));
        bool answer2 = ValidateYesOrNo(GetUserInput(UserProjectionQuestion));
        if (answer2)
        {
            var projection = Builders<BsonDocument>.Projection.Include("Active");
            projection1 = Builders<BsonDocument>.Projection.Combine(projection1, projection);
        }
        vehicle1.VehicleLicenseNumber = ValidateuserInput(GetUserInput("Fahrzeugnummer: [1234567]"));
        answer2 = ValidateYesOrNo(GetUserInput(UserProjectionQuestion));
        if (answer2)
        {
            var projection = Builders<BsonDocument>.Projection.Include("Vehicle License Number");
            projection1 = Builders<BsonDocument>.Projection.Combine(projection1, projection);
        }
        vehicle1.Name = ValidateuserInput(GetUserInput("Name: [Max Mustermann]"));
        answer2 = ValidateYesOrNo(GetUserInput(UserProjectionQuestion));
        if (answer2)
        {
            var projection = Builders<BsonDocument>.Projection.Include("Name");
            projection1 = Builders<BsonDocument>.Projection.Combine(projection1, projection);
        }
        vehicle1.LicenseType = ValidateuserInput(GetUserInput("Lizenztyp: [FOR HIRE VEHICLE]"));
        answer2 = ValidateYesOrNo(GetUserInput(UserProjectionQuestion));
        if (answer2)
        {
            var projection = Builders<BsonDocument>.Projection.Include("License Type");
            projection1 = Builders<BsonDocument>.Projection.Combine(projection1, projection);
        }
        vehicle1.ExpirationDate = ValidateuserInput(GetUserInput("Ablaufdatum: (ExpirationDate) [MM/dd/YYYY]"));
        answer2 = ValidateYesOrNo(GetUserInput(UserProjectionQuestion));
        if (answer2)
        {
            var projection = Builders<BsonDocument>.Projection.Include("Expiration Date");
            projection1 = Builders<BsonDocument>.Projection.Combine(projection1, projection);
        }
        vehicle1.DmvLicensePlateNumber = ValidateuserInput(GetUserInput("Fahrzeugnummer (DMV License Plate Number):"));
        answer2 = ValidateYesOrNo(GetUserInput(UserProjectionQuestion));
        if (answer2)
        {
            var projection = Builders<BsonDocument>.Projection.Include("DMV License Plate Number");
            projection1 = Builders<BsonDocument>.Projection.Combine(projection1, projection);
        }
        vehicle1.VehicleVinNumber = ValidateuserInput(GetUserInput("Fahrzeugnummer (Vehicle VIN Number) [ASdasd2134df]:"));
        answer2 = ValidateYesOrNo(GetUserInput(UserProjectionQuestion));
        if (answer2)
        {
            var projection = Builders<BsonDocument>.Projection.Include("Vehicle VIN Number");
            projection1 = Builders<BsonDocument>.Projection.Combine(projection1, projection);
        }
        vehicle1.VehicleYear = int.Parse(ValidateuserInput(GetUserInput("Fahrzeugjahr (Vehicle Year) [YYYY]:")) ?? "0");
        answer2 = ValidateYesOrNo(GetUserInput(UserProjectionQuestion));
        if (answer2)
        {
            var projection = Builders<BsonDocument>.Projection.Include("Vehicle Year");
            projection1 = Builders<BsonDocument>.Projection.Combine(projection1, projection);
        }
        vehicle1.BaseNumber = ValidateuserInput(GetUserInput("Basenummer [B1234567]:"));
        answer2 = ValidateYesOrNo(GetUserInput(UserProjectionQuestion));
        if (answer2)
        {
            var projection = Builders<BsonDocument>.Projection.Include("Base Number");
            projection1 = Builders<BsonDocument>.Projection.Combine(projection1, projection);
        }
        vehicle1.BaseName = ValidateuserInput(GetUserInput("Basename [Base Name]:"));
        answer2 = ValidateYesOrNo(GetUserInput(UserProjectionQuestion));
        if (answer2)
        {
            var projection = Builders<BsonDocument>.Projection.Include("Base Name");
            projection1 = Builders<BsonDocument>.Projection.Combine(projection1, projection);
        }
        vehicle1.BaseType = ValidateuserInput(GetUserInput("Base Type [Base Type]:"));
        answer2 = ValidateYesOrNo(GetUserInput(UserProjectionQuestion));
        if (answer2)
        {
            var projection = Builders<BsonDocument>.Projection.Include("Base Type");
            projection1 = Builders<BsonDocument>.Projection.Combine(projection1, projection);
        }
        vehicle1.Veh = ValidateuserInput(GetUserInput("Veh [AAA]:"));
        answer2 = ValidateYesOrNo(GetUserInput(UserProjectionQuestion));
        if (answer2)
        {
            var projection = Builders<BsonDocument>.Projection.Include("VEH");
            projection1 = Builders<BsonDocument>.Projection.Combine(projection1, projection);
        }
        vehicle1.BaseTelephoneNumber = ValidateuserInput(GetUserInput("Telefonnummer: (BaseTelephoneNumber) [123456789]:"));
        answer2 = ValidateYesOrNo(GetUserInput(UserProjectionQuestion));
        if (answer2)
        {
            var projection = Builders<BsonDocument>.Projection.Include("Base Telephone Number");
            projection1 = Builders<BsonDocument>.Projection.Combine(projection1, projection);
        }
        vehicle1.BaseAddress = ValidateuserInput(GetUserInput("Adresse (BaseAddress) [1515 THIRD STREET SAN FRANCISCO CA 94158]:"));
        answer2 = ValidateYesOrNo(GetUserInput(UserProjectionQuestion));
        if (answer2)
        {
            var projection = Builders<BsonDocument>.Projection.Include("Base Address");
            projection1 = Builders<BsonDocument>.Projection.Combine(projection1, projection);
        }
        vehicle1.Reason = ValidateuserInput(GetUserInput("Grund (Reason): [RENEWAL]"));
        answer2 = ValidateYesOrNo(GetUserInput(UserProjectionQuestion));
        if (answer2)
        {
            var projection = Builders<BsonDocument>.Projection.Include("Reason");
            projection1 = Builders<BsonDocument>.Projection.Combine(projection1, projection);
        }
        vehicle1.LastDateUpdated = ValidateuserInput(GetUserInput("Letztes Datum (LastDateUpdated) [MM/dd/YYYY]:"));
        answer2 = ValidateYesOrNo(GetUserInput(UserProjectionQuestion));
        if (answer2)
        {
            var projection = Builders<BsonDocument>.Projection.Include("Last Date Updated");
            projection1 = Builders<BsonDocument>.Projection.Combine(projection1, projection);
        }
        vehicle1.LastTimeUpdated = ValidateuserInput(GetUserInput("Letzte Zeit (LastTimeUpdated) [HH:mm]:"));
        answer2 = ValidateYesOrNo(GetUserInput(UserProjectionQuestion));
        if (answer2)
        {
            var projection = Builders<BsonDocument>.Projection.Include("Last Time Updated");
            projection1 = Builders<BsonDocument>.Projection.Combine(projection1, projection);
        }

        if (!string.IsNullOrWhiteSpace(vehicle1.Active))
        {
            var activeFilter = filterBuilder.Eq("Active", vehicle1.Active);
            filter1 &= activeFilter;
        }
        if (!string.IsNullOrWhiteSpace(vehicle1.VehicleLicenseNumber))
        {
            var vehicleLicenseNumberFilter = filterBuilder.Eq("Vehicle License Number", vehicle1.VehicleLicenseNumber);
            filter1 &= vehicleLicenseNumberFilter;
        }
        if (!string.IsNullOrWhiteSpace(vehicle1.Name))
        {
            var nameFilter = filterBuilder.Eq("Name", vehicle1.Name);
            filter1 &= nameFilter;
        }
        if (!string.IsNullOrWhiteSpace(vehicle1.LicenseType))
        {
            var licenseTypeFilter = filterBuilder.Eq("License Type", vehicle1.LicenseType);
            filter1 &= licenseTypeFilter;
        }
        if (!string.IsNullOrWhiteSpace(vehicle1.ExpirationDate))
        {
            var expirationDateFilter = filterBuilder.Eq("Expiration Date", vehicle1.ExpirationDate);
            filter1 &= expirationDateFilter;
        }
        if (!string.IsNullOrWhiteSpace(vehicle1.DmvLicensePlateNumber))
        {
            var dmvLicensePlateNumberFilter = filterBuilder.Eq("DMV License Plate Number", vehicle1.DmvLicensePlateNumber);
            filter1 &= dmvLicensePlateNumberFilter;
        }
        if (!string.IsNullOrWhiteSpace(vehicle1.VehicleVinNumber))
        {
            var vehicleVinNumberFilter = filterBuilder.Eq("Vehicle VIN Number", vehicle1.VehicleVinNumber);
            filter1 &= vehicleVinNumberFilter;
        }
        if (vehicle1.VehicleYear != 0)
        {
            var vehicleYearFilter = filterBuilder.Eq("Vehicle Year", vehicle1.VehicleYear);
            filter1 &= vehicleYearFilter;
        }
        if (!string.IsNullOrWhiteSpace(vehicle1.BaseNumber))
        {
            var baseNumberFilter = filterBuilder.Eq("Base Number", vehicle1.BaseNumber);
            filter1 &= baseNumberFilter;
        }
        if (!string.IsNullOrWhiteSpace(vehicle1.BaseName))
        {
            var baseNameFilter = filterBuilder.Eq("Base Name", vehicle1.BaseName);
            filter1 &= baseNameFilter;
        }
        if (!string.IsNullOrWhiteSpace(vehicle1.BaseType))
        {
            var baseTypeFilter = filterBuilder.Eq("Base Type", vehicle1.BaseType);
            filter1 &= baseTypeFilter;
        }
        if (!string.IsNullOrWhiteSpace(vehicle1.Veh))
        {
            var vehFilter = filterBuilder.Eq("VEH", vehicle1.Veh);
            filter1 &= vehFilter;
        }
        if (!string.IsNullOrWhiteSpace(vehicle1.BaseTelephoneNumber))
        {
            var baseTelephoneNumberFilter = filterBuilder.Eq("Base Telephone Number", vehicle1.BaseTelephoneNumber);
            filter1 &= baseTelephoneNumberFilter;
        }
        if (!string.IsNullOrWhiteSpace(vehicle1.BaseAddress))
        {
            var baseAddressFilter = filterBuilder.Eq("Base Address", vehicle1.BaseAddress);
            filter1 &= baseAddressFilter;
        }
        if (!string.IsNullOrWhiteSpace(vehicle1.Reason))
        {
            var reasonFilter = filterBuilder.Eq("Reason", vehicle1.Reason);
            filter1 &= reasonFilter;
        }
        if (!string.IsNullOrWhiteSpace(vehicle1.LastDateUpdated))
        {
            var lastDateUpdatedFilter = filterBuilder.Eq("Last Date Updated", vehicle1.LastDateUpdated);
            filter1 &= lastDateUpdatedFilter;
        }
        if (!string.IsNullOrWhiteSpace(vehicle1.LastTimeUpdated))
        {
            var lastTimeUpdatedFilter = filterBuilder.Eq("Last Time Updated", vehicle1.LastTimeUpdated);
            filter1 &= lastTimeUpdatedFilter;
        }

        var activeVehiclesFiltered = await vehiclesCollection.Find(filter1).Project(projection1).ToListAsync();

        Console.WriteLine($"Fahrzeuge gefunden: \n");

        Parallel.ForEach(activeVehiclesFiltered, vehicle =>
        {
            ProcessVehicle(vehicle);
        });

        Console.WriteLine($"\n {activeVehiclesFiltered.Count} Fahrzeuge gefunden!");

    }
    public static void ProcessVehicle(BsonDocument vehicle)
    {
        Console.WriteLine(vehicle.ToString());
    }

    public static bool ValidateYesOrNo(string answer)
    {
        if (answer == null)
        {
            return false;
        }
        else if (answer.Equals("y", StringComparison.CurrentCultureIgnoreCase))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static string GetUserInput(string message)
    {
        Console.WriteLine(message);
        return Console.ReadLine() ?? "";
    }
    public static string? ValidateuserInput(string userInput)
    {
        if (string.IsNullOrEmpty(userInput))
        {
            return null;
        }
        else
        {
            return userInput;
        }
    }
}