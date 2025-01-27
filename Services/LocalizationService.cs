using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace EventEaseApp.Services
{
    public class LocalizationService
    {
        private readonly HttpClient _httpClient;
        private Dictionary<string, string> _localizationStrings = new Dictionary<string, string>();
        private string _currentLanguage = "en";

        public event Action? OnLanguageChanged;

        public LocalizationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task LoadLocalizationStringsAsync()
        {
            try
            {
                Console.WriteLine($"Fetching localization strings for language: {_currentLanguage}");
                var localizationStrings = await _httpClient.GetFromJsonAsync<Dictionary<string, string>>($"localization.{_currentLanguage}.json");
                if (localizationStrings != null)
                {
                    _localizationStrings = localizationStrings;
                    Console.WriteLine("Localization strings loaded successfully.");
                }
                else
                {
                    Console.WriteLine("Localization strings are null.");
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log it)
                Console.WriteLine($"Error loading localization strings: {ex.Message}");
            }
        }

        public async Task SetLanguageAsync(string language)
        {
            _currentLanguage = language;
            await LoadLocalizationStringsAsync();
            OnLanguageChanged?.Invoke();
        }

        public string GetString(string key)
        {
            if (_localizationStrings != null && _localizationStrings.ContainsKey(key))
            {
                return _localizationStrings[key];
            }
            return string.Empty;
        }
    }
}