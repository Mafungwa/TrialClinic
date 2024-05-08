﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using TrialClinic.Models;

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
            _dbconnection.CreateTable<UserTrial>();
            _dbconnection.CreateTable<Trial>();
            _dbconnection.CreateTable<Models.Location>();
            _dbconnection.CreateTable<TrialSite>();
            _dbconnection.CreateTable<Treatment>();
            _dbconnection.CreateTable<Results>();
            _dbconnection.CreateTable<RecruitmentEffort>();
            _dbconnection.CreateTable<EnrollmentStatus>();
            _dbconnection.CreateTable<Language>();
            _dbconnection.CreateTable<Translation>();
            _dbconnection.CreateTable<ChatMessage>();
            _dbconnection.CreateTable<PrivateChat>();


            SeedDatabase();

        }

        public void SeedDatabase()
        {
            if (_dbconnection.Table<User>().Count() ==0 ) 
            {

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

        /*public List<User> GetAllUserProfile()
        {
            return _dbconnection.Table<User>().ToList();
        }

        public User GetUserProfileById(int id)
        {
            User userProfile = _dbconnection.Table<User>().Where(x =>x.UserId == id).FirstOrDefault();
        }

        public void UpdateUserProfile(User userProfile)
        {
            _dbconnection.Update(userProfile);
        }*/
    }
}
