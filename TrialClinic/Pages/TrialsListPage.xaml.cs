using TrialClinic.Models;
using TrialClinic.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;

namespace TrialClinic.Pages
{
    public partial class TrialsListPage : ContentPage
    {
        private TrialLocalDatabase _database;

        private ObservableCollection<Trial> _trials;

        public ObservableCollection<Trial> Trials
        {
            get { return _trials; }
            set { _trials = value;

                OnPropertyChanged();
            }
        }


        public TrialsListPage(TrialLocalDatabase database)
        {
            InitializeComponent();
            _database = database;
            LoadTrials();

            BindingContext = this;
        }

        private void LoadTrials()
        {
            //var trials = _database.GetAllTrials();
            var trials = GenerateTestTrials();

            Trials = new ObservableCollection<Trial>(trials);

        }

        private List<Trial> GenerateTestTrials()
        {

            var trials = new List<Trial>();

            var trial = new Trial();
            trial.TrialName = "Trial 1";
            trial.TrialStartDate = DateTime.Now;
            trial.TrialEndDate = DateTime.Now.AddDays(30);
            trial.TrialPhase = 1;
            trial.Status = "Active";
            trial.ParticipantCount = 10;
            trial.Location = "Location, UWC Street 1, Cape Town, 4456";
            trial.TrialDescription = "Cancer";

            trials.Add(trial);

            trial = new Trial();
            trial.TrialName = "Trial 2";
            trial.TrialStartDate = DateTime.Now;
            trial.TrialEndDate = DateTime.Now.AddDays(30);
            trial.TrialPhase = 1;
            trial.Status = "Active";
            trial.ParticipantCount = 10;


            trials.Add(trial);

            trial = new Trial();
            trial.TrialName = "Trial 3";
            trial.TrialStartDate = DateTime.Now;
            trial.TrialEndDate = DateTime.Now.AddDays(30);
            trial.TrialPhase = 1;
            trial.Status = "Inactive";
            trial.ParticipantCount = 0;



            trials.Add(trial);

            trial = new Trial();
            trial.TrialName = "Trial 4";
            trial.TrialStartDate = DateTime.Now;
            trial.TrialEndDate = DateTime.Now.AddDays(30);
            trial.TrialPhase = 1;
            trial.Status = "Active";
            trial.ParticipantCount = 10;



            trials.Add(trial);

            return trials;
        }

        private async void OnTrialSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is Trial selectedTrial)
            {
                await Shell.Current.GoToAsync($"trialdetailspage?trialId={selectedTrial.TrialId}");
            }
        }

        private void Frame_LayoutChanged(object sender, EventArgs e)
        {

        }
    }
}
