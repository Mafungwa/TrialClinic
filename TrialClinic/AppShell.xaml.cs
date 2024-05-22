using TrialClinic.Pages;

namespace TrialClinic
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            RegisterRoutes();
        }

        public void RegisterRoutes()
        {
            Routing.RegisterRoute("userpage", typeof(UserPage));
            Routing.RegisterRoute("participantpage", typeof(ParticipantPage));
            Routing.RegisterRoute("signinpage", typeof(SignInPage));
            Routing.RegisterRoute("recruiterpage", typeof(RecruiterPage));

        }

    }
}
