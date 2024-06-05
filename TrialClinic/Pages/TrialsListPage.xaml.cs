using TrialClinic.Models;
using TrialClinic.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace TrialClinic.Pages
{
    public partial class TrialsListPage : ContentPage
    {
        private TrialLocalDatabase _database;

        public TrialsListPage(TrialLocalDatabase database)
        {
            InitializeComponent();
            _database = database;
            LoadTrials();
        }

        private void LoadTrials()
        {
            var trials = _database.GetAllTrials();
            TrialsListView.ItemsSource = trials;
        }

        private async void OnTrialSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is Trial selectedTrial)
            {
                await Shell.Current.GoToAsync($"trialdetailspage?trialId={selectedTrial.TrialId}");
            }
        }
    }
}
