using TrialClinic.Models;
using TrialClinic.Services;
using System;
using System.Linq; // Add this import

namespace TrialClinic.Pages;

public partial class UserPage : ContentPage
{
    private TrialLocalDatabase _database;

    public bool IsSigningUp { get; private set; }

    public UserPage(TrialLocalDatabase database)
    {
        InitializeComponent();

        _database = database;
        //   _database = new TrialLocalDatabase();
        RolePicker.ItemsSource = new List<string> { "Recruiter", "Participant" };
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
            RolePicker.SelectedItem == null)
        {
            await DisplayAlert("Error", "Please fill all fields", "OK");
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
            Role = RolePicker.SelectedItem.ToString()

        };

        _database.InsertUser(newUser);
        await DisplayAlert("Success", "User created successfully!", "OK");

       await Shell.Current.GoToAsync("signinpage");

        //await Navigation.PushAsync(new SignInPage(_database));
    }
}
