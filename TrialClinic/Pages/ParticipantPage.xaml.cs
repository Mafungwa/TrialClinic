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
}
