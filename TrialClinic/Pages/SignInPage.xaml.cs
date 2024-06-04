using TrialClinic.Models;
using TrialClinic.Services;

namespace TrialClinic.Pages;

public partial class SignInPage : ContentPage
{
    private TrialLocalDatabase _database;

    public SignInPage(TrialLocalDatabase database)
    {
        InitializeComponent();

        _database = database;
    }

    private async void OnSigninButtonClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(EmailEntry.Text) || string.IsNullOrEmpty(PasswordEntry.Text))
        {
            await DisplayAlert("Error", "Please enter email and password", "OK");
            return;
        }

        var user = _database.GetUserByCredentials(EmailEntry.Text, PasswordEntry.Text);

        if (user != null)
        {
            if (user.Role == "Participant")
            {
                await Shell.Current.GoToAsync("participantpage");
            }
            else if (user.Role == "Recruiter")
            {
                // Get the trial associated with the recruiter
                var trial = _database.GetTrialByRecruiterId(user.UserId);

                // Navigate to the trial page
                await Shell.Current.GoToAsync($"trialpage?trialId={trial.TrialId}");
            }
        }
        else
        {
            await DisplayAlert("Error", "Invalid credentials", "OK");
        }
    }
}
