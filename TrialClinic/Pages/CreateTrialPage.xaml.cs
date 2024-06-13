using TrialClinic.Models;
using TrialClinic.Services;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
using System;
using TrialClinic.Core;

namespace TrialClinic.Pages;

public partial class CreateTrialPage : ContentPage
{
    private TrialLocalDatabase _database;
    public CreateTrialPage(TrialLocalDatabase database)
    {
        InitializeComponent();
        _database = database;
    }


    private async void OnSelectCsvButton(object sender, EventArgs e)
    {
        try
        {


            var pickerResults = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Select a CSV file",
                FileTypes = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
                {
                    {DevicePlatform.Android, new[] {"text/csv"} },
                }),

                //FileTypes = FilePickerFileType.Csv,

            }); ;
            
            if(pickerResults != null)
            {
                var stream = await pickerResults.OpenReadAsync();
                await ProcessCsvFile(stream);
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
        }
    }

    private async Task ProcessCsvFile(Stream csvStream)
    {
        var csvUploader = new TrialCsvUploader(_database);
        await csvUploader.UploadData(csvStream);
        await DisplayAlert("Success", "CSV file processed and data uploaded to database!", "OK");
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

        if (!int.TryParse(DiseaseIdEntry.Text, out int diseaseId))
        {
            await DisplayAlert("Error", "Invalid disease ID", "OK");
            return;
        }

        string url = URLWebViewSourceEntry.Text;
        bool isValidUrl = Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult)
            && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

        if (!isValidUrl)
        {
            await DisplayAlert("Error", "Invalid URL", "OK");
            return;
        }



        var trial = new Trial
        {
            NCTNumber = NCTNumberEntry.Text,
            TrialName = TrialNameEntry.Text,
            URL = URLWebViewSourceEntry.Text,
            TrialPhase = trialPhase,
            Sex = SexEntry.Text,
            Age = AgeEntry.Text,
            TrialStartDate = TrialStartDatePicker.Date,
            TrialEndDate = TrialEndDatePicker.Date,
            LocationId = locationId,
            DiseaseId = diseaseId,
            TrialDescription = TrialDescriptionEditor.Text,
            Status = Status.Text,
        };

        await _database.InsertTrialWithTranslations(trial);
        await DisplayAlert("Success", "Trial created and translations generated!", "OK");
    }
}
