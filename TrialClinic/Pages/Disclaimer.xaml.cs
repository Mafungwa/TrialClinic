namespace TrialClinic.Pages;

public partial class Disclaimer : ContentPage
{
    public Disclaimer()
    {
        InitializeComponent();
        Routing.RegisterRoute("userpage", typeof(UserPage));
        Routing.RegisterRoute("signinpage", typeof(SignInPage));

    }

    private async void ImageButton_SignUpClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("userpage");
    }

   
    private async void ImageButton_SignInClicked(object sender, EventArgs e)

    {
        await Shell.Current.GoToAsync("signinpage");
    }
}
