using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrialClinic.Core.Models;
using TrialClinic.Models;
using TrialClinic.Services;
using TinyCsvParser;
using TinyCsvParser.Tokenizer;
using TrialUploader.Models;
using TrialUploader.Utilities;

namespace TrialClinic.Core
{
    public class TrialCsvUploader
    {
        private static TrialLocalDatabase _database;
        public TrialCsvUploader(TrialLocalDatabase database)
        {
            _database = database;
        }

      /*  static async Task Main(string[] args)
        {
            var database = new TrialLocalDatabase(new TranslationService());
            var program = new TrialCsvUploader(database);
            //string csvFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "NCT06050356.csv");
            //await program.UploadData(csvFilePath);
        }
      */
        public async Task UploadData(Stream csvStream)
        {
            if (csvStream == null)
            {
                Console.WriteLine("No CSV file selected");
                return;
            }
            //string csvFilePath = filePath;
            //if (!File.Exists(csvFilePath))
            //{
            //    Console.WriteLine("CSV file not found at path: " + csvFilePath);
            //    return;
            //}

            ReadCsvFile(csvStream);

            //ExistingUser();

            Console.WriteLine("Data upload complete.");

        }

        public static string GetDatabasePath()
        {
            string fileName = "Trialdata.db";
            string pathToDb = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            return Path.Combine(pathToDb, fileName);
        }

        public static List<TrialUpload> ReadCsvFile(Stream csvStream)
        {
            var trialUpload = new List<TrialUpload>();
            //var users = _database.GetAllUsers();

            //foreach (var user in users)
            //{
            //    _database.InsertUser(user);
            //}

            var csvParserOptions = new CsvParserOptions(true, new QuotedStringTokenizer(','));

            var csvMapper = new TrialCsvMapping();
            var csvParser = new CsvParser<TrialUpload>(csvParserOptions, csvMapper);
            
            using (var reader = new StreamReader(csvStream))
            {
                var csvData = reader.ReadToEnd();
                var result = csvParser.ReadFromString(new CsvReaderOptions(new[] { Environment.NewLine }), csvData);
                foreach (var details in result)
                {
                    if (details.IsValid)
                    {
                        trialUpload.Add(details.Result);
                    }
                }
            }

            

            foreach (var trialUploadItem in trialUpload)
            {
                var trialPhase = ExtractNumber.GetNumber(trialUploadItem.TrialPhase);


                var trial = new Trial
                {

                    TrialName = trialUploadItem.TrialName,
                    NCTNumber = trialUploadItem.NCTNumber,
                    URL = trialUploadItem.URL,
                    TrialDescription = trialUploadItem.TrialDescription,
                    Sex = trialUploadItem.Sex,
                    Age = trialUploadItem.Age,
                    TrialPhase = trialPhase,
                    TrialStartDate = trialUploadItem.TrialStartDate,
                    Status = trialUploadItem.Status,
                    TrialEndDate = trialUploadItem.TrialEndDate,
                };

                var disease = new Disease
                {
                    Condition = trialUploadItem.Condition,
                };

                _database.InsertDisease(disease);

                trial.DiseaseId = disease.DiseaseId;

                trial.TrialName = trialUploadItem.TrialName;

                var addressInfor = trialUploadItem.Location.Split(',');

                var location = _database.GetLocationByAll(addressInfor[0], addressInfor[1], addressInfor[2], addressInfor[3], addressInfor[4]);

                if (location == null)
                {
                    location = new Location
                    {
                        StreetAddress = addressInfor[0],
                        City = addressInfor[1],
                        Province = addressInfor[2],
                        PostalCode = addressInfor[3],
                        Country = addressInfor[4],
                    };
                    _database.InsertLocation(location);
                }

                trial.LocationId = location.LocationId;

                //_database.InsertTrial(trial);


                var treatments = trialUploadItem.Treatment.Split('|');

                foreach (var treatmentItem in treatments)
                {
                    var treatmentTypeAndName = treatmentItem.Split(':');
                    var treatmentType = treatmentTypeAndName[0].Trim();
                    var treatmentName = treatmentTypeAndName[1].Trim();

                    var treatment = _database.GetTreatmentByNameAndType(treatmentName, treatmentType);

                    if (treatment == null)
                    {
                        treatment = new Treatment
                        {
                            TreatmentType = treatmentType,
                            TreatmentName = treatmentName,
                        };
                        _database.InsertTreatment(treatment);
                    }

                    var trialTreatment = new TrialTreatment
                    {
                        TrialId = trial.TrialId,
                        TreatmentId = treatment.TreatmentId,
                    };
                    _database.InsertTrialTreatment(trialTreatment);
                }

                //       _database.InsertTrial(trial);
                _database.InsertTrialWithTranslations(trial);
            }
            return trialUpload;
        }



    }

    class TrialCsvMapping : TinyCsvParser.Mapping.CsvMapping<TrialUpload>
    {
        public TrialCsvMapping()
        {
            MapProperty(0, x => x.NCTNumber);
            MapProperty(1, x => x.TrialName);
            MapProperty(2, x => x.URL);
            MapProperty(3, x => x.Status);
            MapProperty(4, x => x.TrialDescription);
            MapProperty(5, x => x.Condition);
            MapProperty(6, x => x.Treatment);
            MapProperty(7, x => x.Sex);
            MapProperty(8, x => x.Age);
            MapProperty(9, x => x.TrialPhase);
            MapProperty(10, x => x.TrialStartDate);
            MapProperty(11, x => x.TrialEndDate);
            MapProperty(12, x => x.Location);
        }

        //Test
    }
}
