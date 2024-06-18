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
            set
            {
                _trials = value;
                OnPropertyChanged(nameof(Trials)); // Notify the UI that the Trials property has changed.
            }
        }

        public TrialsListPage(TrialLocalDatabase database)
        {
            InitializeComponent();
            _database = database;
            Trials = new ObservableCollection<Trial>(); // Initialize the Trials collection.
            LoadTrials();
            BindingContext = this; // Set the BindingContext to enable data binding in XAML.
        }

        private void LoadTrials()
        {
            // Assuming _database.GetAllTrials() fetches the trials from the database.
            var trialsFromDb = _database.GetAllTrials();
            foreach (var trial in trialsFromDb)
            {
                Trials.Add(trial); // Add each trial to the Trials collection.
            }
        }

        private async void OnTrialSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is Trial selectedTrial)
            {
                var param = new ShellNavigationQueryParameters();
                param["Trial"] = selectedTrial;

                await Shell.Current.GoToAsync($"trialdetailspage",param);
            }
        }
    }
}
