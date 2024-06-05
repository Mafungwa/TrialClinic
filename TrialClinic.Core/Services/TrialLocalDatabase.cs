﻿using SQLite;
using TrialClinic.Core.Models;
using TrialClinic.Models;
using Location = TrialClinic.Models.Location;

namespace TrialClinic.Services
{
    public class TrialLocalDatabase
    {
        private SQLiteConnection _dbconnection;
        private TranslationService _translationService;

        public string GetDatabasePath()
        {
            string fileName = "Trialdata.db";
            string pathToDb = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            return Path.Combine(pathToDb, fileName);
        }

        public TrialLocalDatabase(TranslationService translationService) 
        {
            _dbconnection = new SQLiteConnection(GetDatabasePath());
            _translationService = translationService;


            _dbconnection.CreateTable<User>(CreateFlags.AutoIncPK);
            _dbconnection.CreateTable<UserType>();
            _dbconnection.CreateTable<Trial>();
            _dbconnection.CreateTable<TrialTranslation>();
            _dbconnection.CreateTable<Models.Location>();
            _dbconnection.CreateTable<Treatment>();
            _dbconnection.CreateTable<Disease>();
            _dbconnection.CreateTable<Recruitment>();
            _dbconnection.CreateTable<RecruitmentStatus>();
            _dbconnection.CreateTable<EnrollmentStatus>();
            _dbconnection.CreateTable<Enrollment>();
            _dbconnection.CreateTable<Language>();
            _dbconnection.CreateTable<ChatMessage>();
            _dbconnection.CreateTable<PrivateChat>();
            _dbconnection.CreateTable<TrialTreatment>();
            _dbconnection.CreateTable<Update>();


            SeedDatabase();

        }

        public void SeedDatabase()
        {
            if (_dbconnection.Table<UserType>().Count() ==0 ) 
            {
                _dbconnection.Insert(new UserType { TypeName = "Participant" });
                _dbconnection.Insert(new UserType { TypeName = "Recruiter" });

            }
        }

        public async Task InsertTrialWithTranslations(Trial trial)
        {
            _dbconnection.Insert(trial);

            var translations = new List<TrialTranslation>();

            var languages = new[] { "xh", "zu", "af" };
            foreach (var language in languages)
            {
                var translatedText = await _translationService.TranslateText(trial.TrialDescription, language);
                translations.Add(new TrialTranslation
                {
                    TrialId = trial.TrialId,
                    LanguageCode = language,
                    TranslatedDescription = translatedText
                });
            }

            _dbconnection.InsertAll(translations);
        }

        public List<Update> GetUpdates()
        {
            return _dbconnection.Table<Update>().OrderByDescending(u => u.Date).ToList();
        }

        public List<User> GetParticipantsForTrial(int trialId)
        {
            return _dbconnection.Table<User>().Where(u => u.TrialId == trialId).ToList();
        }

        public void RemoveParticipantFromTrial(int userId)
        {
            var user = _dbconnection.Table<User>().FirstOrDefault(u => u.UserId == userId);
            if (user != null)
            {
                user.TrialId = -1; // Or another value that represents no trial
                _dbconnection.Update(user);
            }
        }


        public List<Trial> GetTrials()
        {
            return _dbconnection.Table<Trial>().ToList();
        }

        /*public void UpdateTrial(Trial trial)
        {
            _dbconnection.Update(trial);
        }*/

        public List<User> GetParticipants()
        {
            return _dbconnection.Table<User>().ToList();
        }

        public List<TrialTranslation> GetTranslationsForTrial(int trialId)
        {
            return _dbconnection.Table<TrialTranslation>().Where(t => t.TrialId == trialId).ToList();
        }

        public void SaveChatMessage(PrivateChat chatMessage)
        {
            _dbconnection.Insert(chatMessage);
        }

        public List<PrivateChat> GetPrivateChat()
        {
            return _dbconnection.Table<PrivateChat>().ToList();
        }

        public User GetUserByCredentials(string email, string password)
        {
            return _dbconnection.Table<User>()
                       .Where(u => u.Email == email && u.Password == password)
                       .FirstOrDefault();
        }

        public List<UserType> GetUserTypes()
        {
            return _dbconnection.Table<UserType>().ToList();
        }
        public void InsertUser(User user)
        {
            _dbconnection.Insert(user);
        }

        public void DeleteUser(User user)
        {
            _dbconnection.Delete(user);
        }
        public int InsertLocation(Location location)
        {
            _dbconnection.Insert(location);

            return location.LocationId;
        }
        public Location GetLocationById(int id)
        {
            return _dbconnection.Table<Location>().Where(x => x.LocationId == id).FirstOrDefault();
        }

        public Location GetLocationByAll(string streetAddress, string city, string province, string postalCode,  string country)
        {
            return _dbconnection.Table<Location>().Where(x => x.StreetAddress == streetAddress && x.City == city && x.PostalCode == postalCode && x.Province == province && x.Country == country).FirstOrDefault();
        }

        public Treatment GetTreatmentByNameAndType(string treatmentName, string treatmentType)
        {
            return _dbconnection.Table<Treatment>().FirstOrDefault(t => t.TreatmentName == treatmentName && t.TreatmentType == treatmentType);
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