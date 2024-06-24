using MongoDB.Bson;
using MongoDB.Driver;
using System;
using FHV_App;

class Programm
{
    public static void Main()
    {

        string connectionString = "mongodb://127.0.0.1:27017/?directConnection=true&serverSelectionTimeoutMS=2000&appName=mongosh+1.8.";
        MongoDBConnection connection = new(connectionString, "FHV");
        IMongoCollection<BsonDocument> vehiclesCollection = connection.GetCollection("Vehicles");

        Console.WriteLine("Möchtest du die Fahrzeuge anhand der Kriterien anzeigen?");
        Console.WriteLine("Ja oder Nein? [Y/N]");

        bool answer = GetYesOrNo(Console.ReadLine() ?? "");

        if (!answer)
        {
            Console.WriteLine("Programm wird beendet!");
            System.Environment.Exit(0);
        }

        Vehicle vehicle1 = new();

        Console.WriteLine("Gib pro angezeigtes kriterium dein Wert ein. Wenn nichts eingegeben wird wird dieses Kriterium nicht berücksichtigt.");

        vehicle1.Active = ValidateuserInput(GetUserInput("Aktiv: [YES/NO]"));
        vehicle1.VehicleLicenseNumber = ValidateuserInput(GetUserInput("Fahrzeugnummer: [1234567]"));
        vehicle1.Name = ValidateuserInput(GetUserInput("Name: [Max Mustermann]"));
        vehicle1.LicenseType = ValidateuserInput(GetUserInput("Lizenztyp: [FOR HIRE VEHICLE]"));
        vehicle1.ExpirationDate = ValidateuserInput(GetUserInput("Ablaufdatum: (ExpirationDate) [MM/dd/YYYY]"));
        vehicle1.DmvLicensePlateNumber = ValidateuserInput(GetUserInput("Fahrzeugnummer (DMV License Plate Number):"));
        vehicle1.VehicleVinNumber = ValidateuserInput(GetUserInput("Fahrzeugnummer (Vehicle VIN Number) [ASdasd2134df]:"));
        vehicle1.VehicleYear = int.Parse(ValidateuserInput(GetUserInput("Fahrzeugjahr (Vehicle Year) [YYYY]:")) ?? "0");
        vehicle1.BaseNumber = ValidateuserInput(GetUserInput("Basenummer [B1234567]:"));
        vehicle1.BaseName = ValidateuserInput(GetUserInput("Basename [Base Name]:"));
        vehicle1.BaseType = ValidateuserInput(GetUserInput("Base Type [Base Type]:"));
        vehicle1.Veh = ValidateuserInput(GetUserInput("Veh [AAA]:"));
        vehicle1.BaseTelephoneNumber = ValidateuserInput(GetUserInput("Telefonnummer: (BaseTelephoneNumber) [123456789]:"));
        vehicle1.BaseAddress = ValidateuserInput(GetUserInput("Adresse (BaseAddress) [1515 THIRD STREET SAN FRANCISCO CA 94158]:"));
        vehicle1.Reason = ValidateuserInput(GetUserInput("Grund (Reason): [RENEWAL]"));
        vehicle1.LastDateUpdated = ValidateuserInput(GetUserInput("Letztes Datum (LastDateUpdated) [MM/dd/YYYY]:"));
        vehicle1.LastTimeUpdated = ValidateuserInput(GetUserInput("Letzte Zeit (LastTimeUpdated) [HH:mm]:"));

        var filterBuilder = Builders<BsonDocument>.Filter;
        var filter1 = filterBuilder.Empty;
        
        if(!string.IsNullOrWhiteSpace(vehicle1.Active))
        {
            var activeFilter = filterBuilder.Eq("Active", vehicle1.Active);
            filter1 &= activeFilter;
        }
        if(!string.IsNullOrWhiteSpace(vehicle1.VehicleLicenseNumber))
        {
            var vehicleLicenseNumberFilter = filterBuilder.Eq("Vehicle License Number", vehicle1.VehicleLicenseNumber);
            filter1 &= vehicleLicenseNumberFilter;
        }
        if(!string.IsNullOrWhiteSpace(vehicle1.Name))
        {
            var nameFilter = filterBuilder.Eq("Name", vehicle1.Name);
            filter1 &= nameFilter;
        }
        if(!string.IsNullOrWhiteSpace(vehicle1.LicenseType))
        {
            var licenseTypeFilter = filterBuilder.Eq("License Type", vehicle1.LicenseType);
            filter1 &= licenseTypeFilter;
        }
        if(!string.IsNullOrWhiteSpace(vehicle1.ExpirationDate))
        {
            var expirationDateFilter = filterBuilder.Eq("Expiration Date", vehicle1.ExpirationDate);
            filter1 &= expirationDateFilter;
        }
        if(!string.IsNullOrWhiteSpace(vehicle1.DmvLicensePlateNumber))
        {
            var dmvLicensePlateNumberFilter = filterBuilder.Eq("DMV License Plate Number", vehicle1.DmvLicensePlateNumber);
            filter1 &= dmvLicensePlateNumberFilter;
        }
        if(!string.IsNullOrWhiteSpace(vehicle1.VehicleVinNumber))
        {
            var vehicleVinNumberFilter = filterBuilder.Eq("Vehicle VIN Number", vehicle1.VehicleVinNumber);
            filter1 &= vehicleVinNumberFilter;
        }
        if(vehicle1.VehicleYear != 0)
        {
            var vehicleYearFilter = filterBuilder.Eq("Vehicle Year", vehicle1.VehicleYear);
            filter1 &= vehicleYearFilter;
        }
        if(!string.IsNullOrWhiteSpace(vehicle1.BaseNumber))
        {
            var baseNumberFilter = filterBuilder.Eq("Base Number", vehicle1.BaseNumber);
            filter1 &= baseNumberFilter;
        }
        if(!string.IsNullOrWhiteSpace(vehicle1.BaseName))
        {
            var baseNameFilter = filterBuilder.Eq("Base Name", vehicle1.BaseName);
            filter1 &= baseNameFilter;
        }
        if(!string.IsNullOrWhiteSpace(vehicle1.BaseType))
        {
            var baseTypeFilter = filterBuilder.Eq("Base Type", vehicle1.BaseType);
            filter1 &= baseTypeFilter;
        }
        if(!string.IsNullOrWhiteSpace(vehicle1.Veh))
        {
            var vehFilter = filterBuilder.Eq("VEH", vehicle1.Veh);
            filter1 &= vehFilter;
        }
        if(!string.IsNullOrWhiteSpace(vehicle1.BaseTelephoneNumber))
        {
            var baseTelephoneNumberFilter = filterBuilder.Eq("Base Telephone Number", vehicle1.BaseTelephoneNumber);
            filter1 &= baseTelephoneNumberFilter;
        }
        if(!string.IsNullOrWhiteSpace(vehicle1.BaseAddress))
        {
            var baseAddressFilter = filterBuilder.Eq("Base Address", vehicle1.BaseAddress);
            filter1 &= baseAddressFilter;
        }
        if(!string.IsNullOrWhiteSpace(vehicle1.Reason))
        {
            var reasonFilter = filterBuilder.Eq("Reason", vehicle1.Reason);
            filter1 &= reasonFilter;
        }
        if(!string.IsNullOrWhiteSpace(vehicle1.LastDateUpdated))
        {
            var lastDateUpdatedFilter = filterBuilder.Eq("Last Date Updated", vehicle1.LastDateUpdated);
            filter1 &= lastDateUpdatedFilter;
        }
        if(!string.IsNullOrWhiteSpace(vehicle1.LastTimeUpdated))
        {
            var lastTimeUpdatedFilter = filterBuilder.Eq("Last Time Updated", vehicle1.LastTimeUpdated);
            filter1 &= lastTimeUpdatedFilter;
        }
        

        var activeVehiclesFiltered = vehiclesCollection.Find(filter1).ToList();

        Console.WriteLine(activeVehiclesFiltered.Count + " Fahrzeuge gefunden!");

    }

    public static bool GetYesOrNo(string answer)
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