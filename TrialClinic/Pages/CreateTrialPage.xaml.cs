using TrialClinic.Models;
using TrialClinic.Services;
using Microsoft.Maui.Controls;
using System;

namespace TrialClinic.Pages;

public partial class CreateTrialPage : ContentPage
{
	private TrialLocalDatabase _database;
	public CreateTrialPage(TrialLocalDatabase database)
	{
		InitializeComponent();
		_database = database;
	}

	private async void OnCreateTrialButtonClicked(object sender, EventArgs e)
	{
		if (!int.TryParse(TrialPhaseEntry.Text, out int trialPhase))
		{
			await DisplayAlert("Error", "Invalid trial phase", "OK");
			return;
		}

		if (!int.TryParse(LocationIdEntry.Text, out int locationId))
		{
			await DisplayAlert("Error", "Invalid location ID", "OK");
			return;
		}

		var trial = new Trial
		{
			TrialName = TrialNameEntry.Text,
			TrialPhase = trialPhase,
			TrialStartDate = TrialStartDatePicker.Date,
			TrialEndDate = TrialEndDatePicker.Date,
			LocationId = locationId,
			TrialDescription = TrialDescriptionEditor.Text
		};

		await _database.InsertTrialWithTranslations(trial);
		await DisplayAlert("Success", "Trial created and translations generated!", "OK");
	}
}