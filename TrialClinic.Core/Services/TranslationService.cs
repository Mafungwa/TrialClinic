using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace TrialClinic.Services
{
    public class TranslationService
    {
        private readonly string subscriptionKey = "9fbcf417abc545e183727944343a0d06";
        private readonly string endpoint = "https://api.cognitive.microsofttranslator.com/";

        public async Task<string> TranslateText(string inputText, string targetLanguage)
        {
            string route = $"/translate?api-version=3.0&to={targetLanguage}";
            object[] body = new object[] { new { Text = inputText } };
            var requestBody = new StringContent(System.Text.Json.JsonSerializer.Serialize(body));
            requestBody.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Region", "eastus"); // e.g., "global"
                var response = await client.PostAsync(endpoint + route, requestBody);
                string result = await response.Content.ReadAsStringAsync();
                JArray jsonResponse = JArray.Parse(result);
                return jsonResponse[0]["translations"][0]["text"].ToString();
            }
        }
    }
}
