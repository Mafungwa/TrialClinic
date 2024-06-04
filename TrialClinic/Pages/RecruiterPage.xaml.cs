using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using TrialClinic.Models;
using TrialClinic.Services;

namespace TrialClinic.Pages;

public partial class RecruiterPage : ContentPage
{
    private readonly TrialLocalDatabase _database;

    private User _user;
    public int ActiveTrialsCount { get; private set; }
    public int CompletedTrialsCount { get; private set; }
    public int ParticipantsCount { get; private set; }
    public ObservableCollection<User> Participants { get; private set; }
    public RecruiterPage(TrialLocalDatabase database)
    {
        InitializeComponent();
        _database = database;
        LoadDashboardOverview();
        Participants = new ObservableCollection<User>();
        BindingContext = this;

    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadParticipants();
        LoadDashboardOverview();
    }

    private void LoadParticipants()
    {
        Participants.Clear();
        var participants = _database.GetParticipants();
        foreach (var participant in participants)
        {
            Participants.Add(participant);
        }
    }


    private void LoadDashboardOverview()
    {
        var trials = _database.GetTrials();
        foreach (var trial in trials)
        {
            trial.ParticipantCount = _database.GetParticipantsForTrial(trial.TrialId).Count;
        }

        ActiveTrialsCount = trials.Count(t => t.Status == "Active");
        CompletedTrialsCount = trials.Count(t => t.Status == "Completed");
        ParticipantsCount = _database.GetParticipants().Count;

        OnPropertyChanged(nameof(ActiveTrialsCount));
        OnPropertyChanged(nameof(CompletedTrialsCount));
        OnPropertyChanged(nameof(ParticipantsCount));
    }


    private void LoadParticipantsForTrial(int trialId)
    {
        Participants.Clear();
        var participants = _database.GetParticipantsForTrial(trialId);
        foreach (var participant in participants)
        {
            Participants.Add(participant);
        }
    }
    private async void OnCreateTrialButtonClicked(object sender, EventArgs e)
    {
        // Navigate to the page that allows creating a new trial
        await Shell.Current.GoToAsync("createtrialpage");
    }
}
