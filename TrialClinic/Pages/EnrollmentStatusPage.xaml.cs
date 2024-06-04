using TrialClinic.Models;
using TrialClinic.Services;

namespace TrialClinic.Pages;

public partial class EnrollmentStatusPage : ContentPage
{
    private TrialLocalDatabase _database;
    private User _user;

    public EnrollmentStatusPage(User user, int trialId, TrialLocalDatabase database)
    {
        InitializeComponent();
        _database = database;
        _user = user;

        LoadEnrollmentStatuses(trialId);
    }

    private void LoadEnrollmentStatuses(int trialId)
    {
        var enrollments = _database.GetEnrollmentsForUser(_user.UserId, trialId);
        EnrollmentStatusListView.ItemsSource = enrollments;
        foreach (var enrollment in enrollments)
        {
            var status = _database.GetEnrollmentStatusById(enrollment.EnrollmentStatusId);
            // Display status.Status and enrollment.EnrollmentDate in your UI
        }
    }
    
}
