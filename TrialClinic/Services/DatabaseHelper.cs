using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TrialClinic.Core;


namespace TrialClinic.Services
{
    // In MauiProgram.cs or another appropriate file in the MAUI project
    public class DatabaseHelper
    {
      
        private SQLiteConnection _dbconnection;
        public string GetDatabasePath()
        {
            string fileName = "Trialdata.db";
            string pathToDb = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            return Path.Combine(pathToDb, fileName);
        }

        public void ExtractDbEmbeddedResource()
        {
            var assembly = typeof(MauiProgram).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("TrialClinic.EmbeddedDb.Trialdata.db");

            var path = GetDatabasePath();

            if (stream != null)
            {
                using (BinaryReader br = new BinaryReader(stream))
                {
                    using (FileStream fs = new FileStream(path, FileMode.Create))
                    {
                        BinaryWriter bw = new BinaryWriter(fs);
                        byte[] bytes = new byte[stream.Length];
                        stream.Read(bytes, 0, bytes.Length);
                        bw.Write(bytes);
                    }
                }
            }
        }

        public DatabaseHelper()
        {
           
            if (!File.Exists(GetDatabasePath()))
            {
                ExtractDbEmbeddedResource();

                _dbconnection = new SQLiteConnection(GetDatabasePath());
            }
            
        }
    }

}
