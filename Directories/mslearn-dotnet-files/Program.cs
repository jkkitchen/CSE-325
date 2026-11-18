using Newtonsoft.Json;
using System.Text;

var currentDirectory = Directory.GetCurrentDirectory();
var storesDirectory = Path.Combine(currentDirectory, "stores");

var salesTotalDir = Path.Combine(currentDirectory, "salesTotalDir");
Directory.CreateDirectory(salesTotalDir);   // Add this line of code

var salesFiles = FindFiles(storesDirectory);

var salesTotal = CalculateSalesTotal(salesFiles);

SalesSummary(salesFiles, salesTotal);

File.AppendAllText(Path.Combine(salesTotalDir, "totals.txt"), $"{salesTotal}{Environment.NewLine}");

foreach (var file in salesFiles)
{
    Console.WriteLine(file);
}

IEnumerable<string> FindFiles(string folderName)
{
    List<string> salesFiles = new List<string>();

    var foundFiles = Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories);

    foreach (var file in foundFiles)
    {
        var extension = Path.GetExtension(file);

        // The file name will contain the full path, so only check the end of it
        if (extension == ".json")
        {
            salesFiles.Add(file);
        }
    }

    return salesFiles;
}

double CalculateSalesTotal(IEnumerable<string> salesFiles)
{
    double salesTotal = 0;

    // Loop over each file path in salesFiles
    foreach (var file in salesFiles)
    {      
        // Read the contents of the file
        string salesJson = File.ReadAllText(file);

        // Parse the contents as JSON
        SalesData? data = JsonConvert.DeserializeObject<SalesData?>(salesJson);

        // Add the amount found in the Total field to the salesTotal variable
        salesTotal += data?.Total ?? 0;
    }

    return salesTotal;
}

//Add an additional function to generate a sales summary report file
void SalesSummary(IEnumerable<string> salesFiles, double salesTotal)
{
    StringBuilder report = new StringBuilder();    
    report.AppendLine("Sales Summary");
    report.AppendLine(new string('-', 20));
    report.AppendLine($"Total Sales: {salesTotal:C}");
    report.AppendLine();
    report.AppendLine("Details:");

    //Use loop to generate for each file
    foreach (string file in salesFiles)
    {
        // Calculate the sales total for this file
        var fileSalesTotal = CalculateSalesTotal(new[] { file }); //creates an array containing just the current file

        // Get the filename
        var fileName = Path.GetFileName(file);

        // Append the filename and its total to the report
        report.AppendLine($"\t{fileName}: {fileSalesTotal:C}");
    }

    //Generate file and save to folder salesTotalDir
    File.WriteAllText(
    Path.Combine(salesTotalDir, "SalesSummary.txt"),
    report.ToString()
);
}

record SalesData(double Total);

