using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;
using Newtonsoft.Json;
using csvReader.Interface.csvReader;

namespace csvReader.Endpoints.csvReader
{
    public class ReaderGetAll
    {
        public static string Template => "/reader";

        public static string[] Methods => new string[] { HttpMethod.Get.ToString() };

        public static Delegate Handle => Action;

        public static IResult Action()
        {
            var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                HasHeaderRecord = true,
                Delimiter = ";"
            };
            using var streamReader = File.OpenText("C:\\.net\\csvReader\\Infra\\Files\\csv\\funcionarios.csv");
            using var csvReader = new CsvReader(streamReader, csvConfig);

            var result = csvReader.GetRecords<ReaderResponse>().ToList();

            var jsonString = JsonConvert.SerializeObject(result);

            return Results.Ok(jsonString);
        }
    }
}
