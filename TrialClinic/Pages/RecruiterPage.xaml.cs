using TrialClinic.Models;

namespace TrialClinic.Pages;

public partial class RecruiterPage : ContentPage
{
    private User _user;

    public RecruiterPage(User user)
    {
        InitializeComponent();
        _user = user;

        // Do something with _user
    }
}
