using TrialClinic.Models;
using TrialClinic.Services;
using System.Collections.Generic;
using Location = TrialClinic.Models.Location; // Add this namespace

namespace TrialClinic.Pages;

public partial class TrialDetailsPage : ContentPage
{
    private TrialLocalDatabase _database;
    private Trial _trial;
    private Location _location;
    private List<Treatment> _treatments; // Add the list of treatments

    public TrialDetailsPage(int trialId)
    {
        InitializeComponent();
        _database = new TrialLocalDatabase();
        _trial = _database.GetTrialById(trialId);
        _location = _database.GetLocationById(_trial.LocationId);
        _treatments = _database.GetTreatmentsForTrial(trialId); // Retrieve treatments

        BindingContext = this;
    }

    public Trial Trial => _trial;
    public Location Location => _location;
    public List<Treatment> Treatments => _treatments; // Make treatments accessible
}