namespace TrialClinic.Pages;

public partial class Disclaimer : ContentPage
{
    public Disclaimer()
    {
        InitializeComponent();
    }

    private async void SignUpButton_onClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("userpage");
    }

    private async void SignInButton_onClicked(Object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("signinpage");
    }
}
