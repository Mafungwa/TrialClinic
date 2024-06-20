using TrialClinic.Models;
using TrialClinic.Services;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TrialClinic.Pages
{
    [QueryProperty(nameof(Trial), "Trial")]
    [QueryProperty(nameof(TrialTreatment), "TrialTreatment")]
    public partial class TrialDetailsPage : ContentPage
    {
        private Trial _trial;
        private TrialTreatment _trialTreatment;
        private readonly TrialLocalDatabase _database;
        private Dictionary<string, string> _languageCodes = new Dictionary<string, string>
        {
            { "Xhosa", "xh" },
            { "Zulu", "zu" },
            { "Afrikaans", "af" }
        };

        public Trial Trial
        {
            get => _trial;
            set
            {
                _trial = value;
                OnPropertyChanged();
            }
        }

        public TrialTreatment TrialTreatment
        {
            get => _trialTreatment;
            set
            {
                _trialTreatment = value;
                OnPropertyChanged();
            }
        }

        public TrialDetailsPage(TrialLocalDatabase database)
        {
            InitializeComponent();
            _database = database;
            BindingContext = this;
        }

        private void OnTranslateButtonClicked(object sender, EventArgs e)
        {
            TranslateButton.IsVisible = false;
            LanguageSelectionLayout.IsVisible = true;
        }

        private async void OnTranslateConfirmButtonClicked(object sender, EventArgs e)
        {
            if (_trial == null) return;

            var selectedLanguage = LanguagePicker.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedLanguage) || !_languageCodes.ContainsKey(selectedLanguage))
            {
                await DisplayAlert("Error", "Please select a valid language", "OK");
                return;
            }

            string targetLanguageCode = _languageCodes[selectedLanguage];
            var translationService = new TranslationService();
            string translatedDescription = await translationService.TranslateText(_trial.TrialDescription, targetLanguageCode);

            if (!string.IsNullOrEmpty(translatedDescription))
            {
                DescriptionLabel.Text = translatedDescription;
                TranslatedDescriptionLabel.Text = $"Translated to {selectedLanguage}";
            }
            else
            {
                await DisplayAlert("Error", "Translation failed", "OK");
            }

            TranslateButton.IsVisible = true;
            LanguageSelectionLayout.IsVisible = false;
        }
    }
}
