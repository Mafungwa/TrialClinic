using TrialClinic.Models;
using TrialClinic.Services;

namespace TrialClinic.Pages;

public partial class SignInPage : ContentPage
{
    private TrialLocalDatabase _database;
    private List<UserType> _userTypes;

    public SignInPage(TrialLocalDatabase database)
    {
        InitializeComponent();

        _database = database;
        _userTypes = _database.GetUserTypes();
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
            if (user.UserTypeId == _userTypes.First(ut => ut.TypeName == "Participant").UserTypeId)
            {
                await Shell.Current.GoToAsync("home");
            }
            else if (user.UserTypeId == _userTypes.First(ut => ut.TypeName == "Recruiter").UserTypeId)
            {
                await Shell.Current.GoToAsync("recruiter");
            }
        }
        else
        {
            await DisplayAlert("Error", "Invalid credentials", "OK");
        }


    }
}
