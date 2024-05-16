using TrialClinic.Models;
using TrialClinic.Services;
using System.Collections.ObjectModel;
using Location = TrialClinic.Models.Location;

namespace TrialClinic.Pages;

public partial class TrialCreationPage : ContentPage
{
    private TrialLocalDatabase _database;
    public ObservableCollection<Location> Locations { get; set; } = new ObservableCollection<Location>();
    public Location SelectedLocation { get; set; }

    public TrialCreationPage()
    {
        InitializeComponent();
        _database = new TrialLocalDatabase();

        // Load locations from the database
        LoadLocations();

        BindingContext = this;
    }

    private void LoadLocations()
    {
        Locations.Clear();
        foreach (var location in _database.GetAllLocations())
        {
            Locations.Add(location);
        }
    }

    private async void OnCreateTrialButtonClicked(object sender, EventArgs e)
    {
        if (SelectedLocation == null)
        {
            await DisplayAlert("Error", "Please select a location.", "OK");
            return;
        }

        var newTrial = new Trial
        {
            TrialName = TrialNameEntry.Text,
            TrialPhase = int.Parse(TrialPhaseEntry.Text),
            TrialStartDate = TrialStartDatePicker.Date,
            TrialEndDate = TrialEndDatePicker.Date,
            LocationId = SelectedLocation.LocationId,
            TrialDescription = TrialDescriptionEditor.Text
        };

        _database.InsertTrial(newTrial);

        // Navigate to the TrialDetailsPage for the newly created trial
        await Navigation.PushAsync(new TrialDetailsPage(newTrial.TrialId));
    }
}