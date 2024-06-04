using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using TinyCsvParser;
using TinyCsvParser.Tokenizer;
using TinyCsvParser.Tokenizer.RFC4180;
using TrialClinic.Models;
using TrialClinic.Services;
using TrialUploader.Models;

namespace TrialDataUploader
{
    class Program
    {
        private static TrialLocalDatabase _database;

        public Program(TrialLocalDatabase database)
        {
            _database = database;
        }

        static async Task Main(string[] args)
        {
            var database = new TrialLocalDatabase(new TranslationService());
            var program = new Program(database);
            await program.UploadData();
        }

        public async Task UploadData()
        {
            string csvFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "NCT06050356.csv"); // Update with the actual path to your CSV file
            ReadCsvFile(csvFilePath);

         /*   foreach (var trial in trials)
            {
                await _database.InsertTrialWithTranslations(trial);
            }
         */

            Console.WriteLine("Data upload complete.");
        }
        public static string GetDatabasePath()
        {
            string fileName = "Trialdata.db";
            string pathToDb = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            return Path.Combine(pathToDb, fileName);
        }

        public static void ReadCsvFile(string filePath)
        {
            var csvParserOptions = new CsvParserOptions(true, new QuotedStringTokenizer(','));

            var csvMapper = new TrialCsvMapping();
            var csvParser = new CsvParser<TrialUpload>(csvParserOptions, csvMapper);
            var trialUpload = new List<TrialUpload>();

            var result = csvParser.ReadFromFile(filePath, Encoding.UTF8);
            foreach (var details in result)
            {
                if (details.IsValid)
                {
                    trialUpload.Add(details.Result);
                }
            }
            foreach (var trialUploadItem in trialUpload)
            {
                var trial = new Trial();

                trial.TrialName = trialUploadItem.TrialName;

                var addressInfor = trialUploadItem.Location.Split(',');

                var location = _database.GetLocationByAll(addressInfor[0], addressInfor[1], addressInfor[2], addressInfor[3], addressInfor[4]);

                if(location != null)
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

                _database.InsertTrial(trial);

                var treatments = trialUploadItem.Treatment.Split('|');

                foreach (var treatmentItem in treatments)
                {
                    var treatmentTypeAndName = treatmentItem.Split(':');
                    var treatmentType = treatmentTypeAndName[0].Trim();
                    var treatmentName = treatmentTypeAndName[1].Trim();

                    var treatment = _database.GetTreatmentByNameAndType(treatmentName, treatmentType);

                    if (treatment != null)
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

                _database.InsertTrialWithTranslations(trial);
            }

            /*foreach (var trialUploadItem in trialUpload)
            {
                var location = new Location();

                var addressInfo = trialUploadItem.Location.Split(',');

                if (addressInfo.Length == 5)
                {
                    location.StreetAddress = addressInfo[0];
                    location.City = addressInfo[1];
                    location.Province = addressInfo[2];
                    location.PostalCode = addressInfo[3];
                    location.Country = addressInfo[4];
                }

                _database.InsertLocation(location);
            }

            foreach (var trialUploadItem in trialUpload)
            {
                var trial = new Trial();
                
                trial.TrialName = trialUploadItem.TrialName;

                var addressInfo = trialUploadItem.Location.Split(',');


                var location = _database.GetLocationByAll(addressInfo[0], addressInfo[1], addressInfo[2], addressInfo[3], addressInfo[4]);

                if (location != null)
                    trial.LocationId = location.LocationId;
               
                _database.InsertTrialWithTranslations(trial);

            }*/

         //   return null;

        }

    }

    class TrialCsvMapping : TinyCsvParser.Mapping.CsvMapping<TrialUpload>
    {
        public TrialCsvMapping()
        {
            MapProperty(0, x => x.NCTNumber);
            MapProperty(1, x => x.TrialName);
            MapProperty(2, x => x.UrlWebViewSource);
            MapProperty(3, x => x.RecruitmentStatus);
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
