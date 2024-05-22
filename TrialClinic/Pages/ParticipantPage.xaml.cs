using TrialClinic.Models;

namespace TrialClinic.Pages;

public partial class ParticipantPage : ContentPage
{
    private User _user;

    public ParticipantPage(User user)
    {
        InitializeComponent();
        _user = user;

        // Do something with _user
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ChatMessagePage());
    }
}
