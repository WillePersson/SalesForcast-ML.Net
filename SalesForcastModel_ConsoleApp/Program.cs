using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using SalesForcastModel_ConsoleApp;

public class Program
{
	public static void Main(string[] args)
	{
		string inputFilePath = "C:\\Users\\laymt\\source\\ML-And-AI\\SalesForcast-ML.Net\\SalesForcastModel_ConsoleApp\\month_13_company_sales.csv";

		var month13Data = LoadMonth13Data(inputFilePath);

		bool exit = false;

		while (!exit)
		{
			// Display a simple menu
			Console.WriteLine("===================================");
			Console.WriteLine("Company Sales Prediction Menu");
			Console.WriteLine("===================================");
			Console.WriteLine("1. View predicted sales for a company");
			Console.WriteLine("2. Exit");
			Console.Write("Enter your choice: ");
			var choice = Console.ReadLine();

			switch (choice)
			{
				case "1":

					Console.Clear();
					Console.Write("Enter CompanyID to predict: ");
					var companyIdInput = Console.ReadLine();

					if (float.TryParse(companyIdInput, out float companyId))
					{
						var companyData = month13Data.FirstOrDefault(c => c.CompanyID == companyId);

						if (companyData != null)
						{
							var predictionResult = SalesForcastModel.Predict(companyData);

							// Display the prediction results
							Console.WriteLine("\n=== Predicted Sales for Company ===");
							Console.WriteLine($"CompanyID: {companyData.CompanyID}");
							Console.WriteLine($"Month: {companyData.Month}");
							Console.WriteLine($"NumberOfEmployees: {companyData.NumberOfEmployees}");
							Console.WriteLine($"MarketingBudget: {companyData.MarketingBudget}");
							Console.WriteLine($"IndustryType: {companyData.IndustryType}");
							Console.WriteLine($"HistoricalSales: {companyData.HistoricalSales}");
							Console.WriteLine($"Predicted ProjectedSales: {predictionResult.Score}\n");
						}
						else
						{
							Console.WriteLine($"No data found for CompanyID {companyId}.");
						}
					}
					else
					{
						Console.WriteLine("Invalid CompanyID entered.");
					}
					break;

				case "2":
					exit = true;
					break;

				default:
					Console.WriteLine("Invalid choice. Please select again.");
					break;
			}
		}

		Console.WriteLine("Exiting the program. Goodbye!");
	}

	private static List<SalesForcastModel.ModelInput> LoadMonth13Data(string filePath)
	{
		var config = new CsvConfiguration(System.Globalization.CultureInfo.InvariantCulture)
		{
			HasHeaderRecord = true
		};

		using (var reader = new StreamReader(filePath))
		using (var csv = new CsvReader(reader, config))
		{
			return csv.GetRecords<SalesForcastModel.ModelInput>().ToList();
		}
	}
}
