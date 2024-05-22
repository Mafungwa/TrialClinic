using TrialClinic.Models;
using TrialClinic.Pages;
using TrialClinic.Services;

namespace TrialClinic
{
    public partial class MainPage : ContentPage
    {
        private TrialLocalDatabase _database;

        private User _currentUser;

        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PrivateChatPage());   
        }

        private void myButton_Click(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ChatMessagePage());
        }

}
    }
