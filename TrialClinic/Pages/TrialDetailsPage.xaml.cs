using TrialClinic.Models;
using TrialClinic.Services;
using Location = TrialClinic.Models.Location;

namespace TrialClinic.Pages;


[QueryProperty(nameof(Trial),"Trial")]
public partial class TrialDetailsPage : ContentPage
{
    private TrialLocalDatabase _database;
    private Trial _trial;
    //private Location _location;
    //private List<Treatment> _treatments;
    private TrialTreatment _trialtreatment;
    //private List<TrialTranslation> _translations;
    //private int _trialId;

    public Trial Trial
    {
        get { return _trial; }
        set { _trial = value; }
    }

    public TrialTreatment TrialTreatment
    {
        get { return _trialtreatment; }
        set { _trialtreatment = value;

            OnPropertyChanged();
        }
    }


    public TrialDetailsPage(TrialLocalDatabase database)
    {
        InitializeComponent();
        _database = database;
        //_translations = new List<TrialTranslation>();
        BindingContext = this;
    }

    /*public int TrialId
    {
        get { return _trialId; }
        set
        {
            _trialId = value;
            //LoadTrialDetails(); // Reload trial details whenever TrialId changes
        }
    }*/

    /*private async void InitializeTrialData()
    {
        var trial = new Trial
        {
            TrialId = 1, // Ensure this ID is unique and not conflicting
            TrialDescription = "This is a test trial description for testing purposes.",
            TrialName = "Test Trial",
            TrialStartDate = DateTime.Now,
            TrialEndDate = DateTime.Now.AddMonths(6),
            RecruiterId = 1, // Replace with an appropriate recruiter ID
            LocationId = 1, // Replace with an appropriate location ID
            Status = "Active",
            //EligibilityCriteria = "Must be 18 years or older. Must not have any chronic illnesses.",
            TrialPhase = 1,
        };

        await _database.InsertAndTestTrialWithTranslations(trial);

        var translations = _database.GetTranslationsForTrial(trial.TrialId);
        Console.WriteLine($"After insertion, loaded {translations.Count} translations for trial {trial.TrialId}");
    }*/

    /*private void LoadTrialDetails()
    {
        var trial = _database.GetTrialById(TrialId);
        if (trial != null)
        {
            TrialTreatment = _database.GetTrialTreatmentById(trial.TrialId);
            _translations = _database.GetTranslationsForTrial(trial.TrialId);

            Console.WriteLine($"Loaded {_translations.Count} translations for trial {trial.TrialId}");
            foreach (var translation in _translations)
            {
                Console.WriteLine($"Language: {translation.LanguageCode}, Description: {translation.TranslatedDescription}");
            }

            UpdateDisplayedLanguage("en"); // Initially display English description
        }
    }*/

    /*private void UpdateDisplayedLanguage()
    {
        if (languageCode == "en")
        {
            // Display the original English description
            var trial = _database.GetTrialById(TrialId);
            TrialDescriptionLabel.Text = trial.Description;
        }
        else
        {
            var translation = _translations.FirstOrDefault(t => t.LanguageCode == languageCode);
            if (translation != null)
            {
                // Update UI elements with translated content
                TrialDescriptionLabel.Text = translation.TranslatedDescription;
            }
            else
            {
                // Handle case when translation for selected language is not found
                TrialDescriptionLabel.Text = "Translation not available for selected language.";
            }
        }
    }*/

    /*private async void OnChooseLanguageClicked(object sender, EventArgs e)
    {
        var selectedLanguage = await DisplayActionSheet("Select Language", "Cancel", null, "Xhosa", "Zulu", "Afrikaans");

        switch (selectedLanguage)
        {
            case "Xhosa":
                UpdateDisplayedLanguage("xh");
                break;
            case "Zulu":
                UpdateDisplayedLanguage("zu");
                break;
            case "Afrikaans":
                UpdateDisplayedLanguage("af");
                break;
            default:
                // Handle default case or Cancel option
                UpdateDisplayedLanguage("en"); // Default back to English
                break;
        }
    }*/

    /*private void UpdateDisplayedLanguage(string languageCode)
    {
        if (languageCode == "en")
        {
            // Display the original English description
            var trial = _database.GetTrialById(TrialId);
            TrialDescriptionLabel.Text = trial.TrialDescription;
        }
        else
        {
            var translation = _translations.FirstOrDefault(t => t.LanguageCode == languageCode);
            if (translation != null)
            {
                // Update UI elements with translated content
                TrialDescriptionLabel.Text = translation.TranslatedDescription;
            }
            else
            {
                // Handle case when translation for selected language is not found
                TrialDescriptionLabel.Text = "Translation not available for selected language.";
            }
        }
    }*/

    protected override void OnAppearing()
    {
        base.OnAppearing();

        TrialTreatment = _database.GetTrialTreatmentById(Trial.TrialId);
    }
}