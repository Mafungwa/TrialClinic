using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using TrialClinic.Models;
using Location = TrialClinic.Models.Location;

namespace TrialClinic.Services
{
    public class TrialLocalDatabase
    {
        private SQLiteConnection _dbconnection;

        public string GetDatabasePath()
        {
            string fileName = "Trialdata.db";
            string pathToDb = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            return Path.Combine(pathToDb, fileName);
        }

        public TrialLocalDatabase() 
        {
            _dbconnection = new SQLiteConnection(GetDatabasePath());


            _dbconnection.CreateTable<User>();
            _dbconnection.CreateTable<UserType>();
            _dbconnection.CreateTable<Trial>();
            _dbconnection.CreateTable<Models.Location>();
            _dbconnection.CreateTable<Treatment>();
            _dbconnection.CreateTable<Results>();
            _dbconnection.CreateTable<Recruitment>();
            _dbconnection.CreateTable<RecruitmentStatus>();
            _dbconnection.CreateTable<EnrollmentStatus>();
            _dbconnection.CreateTable<Enrollment>();
            _dbconnection.CreateTable<Language>();
            _dbconnection.CreateTable<Translation>();
            _dbconnection.CreateTable<ChatMessage>();
            _dbconnection.CreateTable<PrivateChat>();
            _dbconnection.CreateTable<TrialTreatment>();


            SeedDatabase();

        }

        public void SeedDatabase()
        {
            if (_dbconnection.Table<User>().Count() ==0 ) 
            {
                _dbconnection.Insert(new UserType { TypeName = "Participant" });
                _dbconnection.Insert(new UserType { TypeName = "Recruiter" });

            }
        }

        public void SaveChatMessage(PrivateChat chatMessage)
        {
            _dbconnection.Insert(chatMessage);
        }

        public List<PrivateChat> GetPrivateChat()
        {
            return _dbconnection.Table<PrivateChat>().ToList();
        }

        public User GetUserByCredentials(string username, string password)
        {
            return _dbconnection.Table<User>()
                   .Where(u => u.UserName == username && u.Password == password)
                   .FirstOrDefault();
        }

        public List<UserType> GetUserTypes()
        {
            return _dbconnection.Table<UserType>().ToList();
        }





        /*public List<User> GetAllUserProfile()
        {
            return _dbconnection.Table<User>().ToList();
        }

        public User GetUserProfileById(int id)
        {
            return _dbconnection.Table<User>().Where(x => x.UserId == id).FirstOrDefault();
        }

        /*public void UpdateUserProfile(User userProfile)
        {
            _dbconnection.Update(userProfile);
        }*/
        public void InsertUser(User user)
        {
            _dbconnection.Insert(user);
        }

        public void DeleteUser(User user)
        {
            _dbconnection.Delete(user);
        }
        public void InsertLocation(Location location)
        {
            _dbconnection.Insert(location);
        }
        public Location GetLocationById(int id)
        {
            return _dbconnection.Table<Location>().Where(x => x.LocationId == id).FirstOrDefault();
        }

        public List<Location> GetAllLocations()
        {
            return _dbconnection.Table<Location>().ToList();
        }

        public Trial GetTrialById(int id)
        {
            return _dbconnection.Table<Trial>().Where(x =>x.TrialId == id).FirstOrDefault();
        }

        public void InsertTrial(Trial trial)
        {
            _dbconnection.Insert(trial);
        }

        public void InsertTreatment(Treatment treatment)
        {
            _dbconnection.Insert(treatment);
        }

        public void InsertTrialTreatment(TrialTreatment trialTreatment)
        {
            _dbconnection.Insert(trialTreatment);
        }

        public List<Treatment> GetTreatmentsForTrial(int trialId)
        {
            var trialTreatmentIds = _dbconnection.Table<TrialTreatment>()
                                               .Where(tt => tt.TrialId == trialId)
                                               .Select(tt => tt.TreatmentId)
                                               .ToList();

            return _dbconnection.Table<Treatment>()
                                .Where(t => trialTreatmentIds.Contains(t.TreatmentId))
                                .ToList();
        }


        public List<Enrollment> GetEnrollmentsForUser(int userId, int trialId)
        {
            return _dbconnection.Table<Enrollment>().Where(e => e.UserId == userId && e.TrialId == trialId).ToList();
        }


        public EnrollmentStatus GetEnrollmentStatusById(int id)
        {
            return _dbconnection.Table <EnrollmentStatus>().FirstOrDefault(es => es.EnrollmentStatusId == id);
        }

        public List<Recruitment> GetRecruitersForUser(int userId, int trialId)
        {
            return _dbconnection.Table<Recruitment>().Where(r => r.UserId == userId && r.TrialId == trialId).ToList();
        }

        public RecruitmentStatus GetRecruitmentStatusById(int id)
        {
            return _dbconnection.Table<RecruitmentStatus>().FirstOrDefault(rs => rs.RecruitmentStatusId == id);
        }

        internal IEnumerable<ChatMessage> GetMessagesByForum(int currentTrialId)
        {
            throw new NotImplementedException();
        }

        internal void SaveChatMessage(ChatMessage message)
        {
            throw new NotImplementedException();
        }
    }


}
