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
            Routing.RegisterRoute("trialdetailspage", typeof(TrialDetailsPage));
            Routing.RegisterRoute("signinpage", typeof(SignInPage));
            Routing.RegisterRoute("recruiterpage", typeof(RecruiterPage));
            Routing.RegisterRoute("createtrialpage", typeof(CreateTrialPage));
            Routing.RegisterRoute("trialslistpage", typeof(TrialsListPage));
        }

    }
}
