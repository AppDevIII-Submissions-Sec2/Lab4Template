using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;

namespace MauiFitness.Services
{
   

public static class WorkoutService
    {
        static string targetTag = "calories_per_hour";
        static string headerTag = "items";
        public static async Task<double> GetBurntCalories(string workoutDetails)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("X-Api-Key", App.Settings.ActivitiesApiKey);
                var reponse = await client.GetAsync(App.Settings.ActivitiesApiUrl + workoutDetails);
                /*
                 * https://api-ninjas.com/api/caloriesburned
                 */
                if(reponse.IsSuccessStatusCode)
                {
                    string values = await reponse.Content.ReadAsStringAsync();
                    List<Dictionary<string, object>> workoutFacts = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(values);
                    return double.Parse(workoutFacts[0][targetTag].ToString());
                }
                return 0.0;//zero is return if http request failed 
            }
            catch(Exception ex) 
            {
                return 0; //zero is return if http request failed   
            }
        }
    }
}
