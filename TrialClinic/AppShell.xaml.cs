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
            Routing.RegisterRoute("participantpage", typeof(ParticipantPage));
            Routing.RegisterRoute("recruiterpage", typeof(RecruiterPage));
            Routing.RegisterRoute("home", typeof(Home));
            Routing.RegisterRoute("chatmessagepage", typeof(ChatMessagePage));
          

        }

    }
}
