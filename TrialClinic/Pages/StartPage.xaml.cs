namespace TrialClinic.Pages;

public partial class StartPage : ContentPage
{
	public StartPage()
	{
		InitializeComponent();
        Routing.RegisterRoute("Disclaimer", typeof(Disclaimer));
    }

    private static async void ImageButton_OnClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("Disclaimer");
    }
}