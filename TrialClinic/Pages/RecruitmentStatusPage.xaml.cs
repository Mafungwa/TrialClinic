using TrialClinic.Models;
using TrialClinic.Services;

namespace TrialClinic.Pages;

public partial class RecruitmentStatusPage : ContentPage
{
    private TrialLocalDatabase _database;
    private User _user;

    public RecruitmentStatusPage(User user, int trialId, TrialLocalDatabase database)
    {
        InitializeComponent();
        _database = database;
        _user = user;

        LoadRecruitmentStatuses(trialId);
    }

    private void LoadRecruitmentStatuses(int trialId)
    {
        var recruiters = _database.GetRecruitersForUser(_user.UserId, trialId);
        foreach (var recruiter in recruiters)
        {
            var status = _database.GetRecruitmentStatusById(recruiter.RecruitmentStatusId);
            // Display status.Status in your UI
        }
    }
    
}
