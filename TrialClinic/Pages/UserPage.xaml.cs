using TrialClinic.Models;
using TrialClinic.Services;
using System;
using System.Linq; // Add this import

namespace TrialClinic.Pages;

public partial class UserPage : ContentPage
{
    private TrialLocalDatabase _database;
    private List<UserType> _userTypes;

    public bool IsSigningUp { get; private set; }

    public UserPage()
    {
        InitializeComponent();
        _database = new TrialLocalDatabase();
        _userTypes = _database.GetUserTypes();

        // Populate UserTypePicker
        foreach (var userType in _userTypes)
        {
            UserTypePicker.Items.Add(userType.TypeName);
        }

        BindingContext = this;
    }

    private async void OnSignUpButtonClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(UserNameEntry.Text) ||
            string.IsNullOrEmpty(PasswordEntry.Text) ||
            string.IsNullOrEmpty(EmailEntry.Text) ||
            string.IsNullOrEmpty(PhoneNumberEntry.Text) ||
            string.IsNullOrEmpty(GenderEntry.Text) ||
            string.IsNullOrEmpty(PhysicalAddressEntry.Text) ||
            UserTypePicker.SelectedItem == null)
        {
            await DisplayAlert("Error", "Please fill all fields", "OK");
            return;
        }

        var selectedUserType = _userTypes.FirstOrDefault(ut =>
                                   ut.TypeName == UserTypePicker.SelectedItem.ToString());

        if (selectedUserType == null)
        {
            await DisplayAlert("Error", "Invalid User Type", "OK");
            return;
        }

        var newUser = new User()
        {
            UserName = UserNameEntry.Text,
            Password = PasswordEntry.Text, // Hash passwords in a real application!
            Email = EmailEntry.Text,
            PhoneNumber = PhoneNumberEntry.Text,
            Gender = GenderEntry.Text,
            PhysicalAddress = PhysicalAddressEntry.Text,
            DateOfBirth = DateOfBirthPicker.Date,
            CreatedDate = DateTime.Now,
            UserTypeId = selectedUserType.UserTypeId
        };

        _database.InsertUser(newUser);
        await DisplayAlert("Success", "User created successfully!", "OK");
    }

    private async void OnLoginButtonClicked(object sender, EventArgs e)
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
                await Navigation.PushAsync(new ParticipantPage(user));
            }
            else if (user.UserTypeId == _userTypes.First(ut => ut.TypeName == "Recruiter").UserTypeId)
            {
                await Navigation.PushAsync(new RecruiterPage(user));
            }
        }
        else
        {
            await DisplayAlert("Error", "Invalid credentials", "OK");
        }
    }

    private void OnToggleSignUpLoginButtonClicked(object sender, EventArgs e)
    {
        IsSigningUp = !IsSigningUp; // Toggle between sign-up and login
    }
}
