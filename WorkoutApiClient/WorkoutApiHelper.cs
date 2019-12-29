using RestSharp;

namespace WorkoutApiClient
{
    public class WorkoutApiHelper
    {
        public static string GetJsonStringFromNhsApi(string apiUrl)
        {
            const string apiKey = "7dc7a418ef0ec9d2503371ff5a0816ae030f5f4e";

            var client = new RestClient(apiUrl);
            var request = new RestRequest { Method = Method.GET };
            request.AddHeader("Accept", "application/json");
            request.AddHeader("subscription-key", apiKey);
            IRestResponse response = client.Execute(request);
            string jsonString = response.Content;
            return jsonString;
        }
    }
}
