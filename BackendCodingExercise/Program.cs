// See https://aka.ms/new-console-template for more information
Console.WriteLine("Calculate Employee Montly Payslip");
Console.WriteLine("Input format is (first name, last name, annual salary, super rate (%), pay period)");
Console.WriteLine("Enter csv filename:");
string? filename = Console.ReadLine();

if (filename == null || filename.Trim() == "")
{
    Console.WriteLine("Error: You have not entered a filename!");
    return;
}

var path = Path.Combine(Directory.GetCurrentDirectory(), filename);
string filetype;

try
{
    filetype = filename.Substring(filename.LastIndexOf("."));
}
catch (ArgumentOutOfRangeException)
{
    Console.WriteLine("Error: There was no \".\" character in the filename!");
    return;
}


if (filetype != ".csv" || !File.Exists(path))
{
    Console.WriteLine("Error: You have not entered a csv file or the file does not exist!");
    return;
}


Console.WriteLine("\nOutput format is (name, pay period, gross income, income tax, net income, super)\n");
string[] lines = System.IO.File.ReadAllLines(path);
List<string> results = new() { "name,payperiod,grossIncome,incomeTax,netIncome,super" };

foreach (string line in lines)
{
    if (line.Trim() == "")
        continue;

    string personResult = ProcessLine(line);
    results.Add(personResult);
    Console.WriteLine(personResult);
}

CreateOutputFile(results);

Console.ReadKey();


static double CalculateIncomeTax(double annualSalary)
{
    double incomeTax = 0;

    if (annualSalary > 180000)
    {
        incomeTax += (annualSalary - 180000) * 0.39;
        annualSalary = 180000;
    }

    if (annualSalary >= 70000)
    {
        incomeTax += (annualSalary - 70000) * 0.33;
        annualSalary = 70000;
    }

    if (annualSalary >= 48000)
    {
        incomeTax += (annualSalary - 48000) * 0.30;
        annualSalary = 48000;
    }

    if (annualSalary >= 14000)
    {
        incomeTax += (annualSalary - 14000) * 0.175;
        annualSalary = 14000;
    }

    if (annualSalary <= 14000)
    {
        incomeTax += annualSalary * 0.105;
        annualSalary = 0;
    }

    return incomeTax / 12;
}

static string ProcessLine(string line)
{
    string[] personLine = line.Split(",");
    string firstName = personLine[0];
    string lastName = personLine[1];
    double annualSalary = Double.Parse(personLine[2]);
    int superRate = Int32.Parse(personLine[3].Substring(0, personLine[3].Length - 1));
    string payPeriod = personLine[4];

    double grossIncome = Math.Round(annualSalary / 12, 2);
    double incomeTax = Math.Round(CalculateIncomeTax(annualSalary), 2);
    double netIncome = grossIncome - incomeTax;
    double super = Math.Round(grossIncome * superRate / 100, 2);

    MonthEnum month = Enum.Parse<MonthEnum>(payPeriod, true);

    int lastDay = DateTime.DaysInMonth(DateTime.Now.Year, (int)month);


    return $"{firstName} {lastName},01 {month} - {lastDay} {month},{grossIncome:f2},{incomeTax:f2},{netIncome:f2},{super:f2}";
}

static void CreateOutputFile(List<string> results)
{
    Console.WriteLine("\nPlease wait, writing results to output file.");
    var outputFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Results.csv");
    File.WriteAllLines(outputFilePath, results);
    Console.WriteLine("Finished writing to Results.csv");
}

enum MonthEnum
{
    None,
    January,
    February,
    March,
    April,
    May,
    June,
    July,
    August,
    September,
    October,
    November,
    December
}
