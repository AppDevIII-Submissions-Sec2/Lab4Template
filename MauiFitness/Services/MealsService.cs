
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;


namespace MauiFitness.Services
{

    public static class MealsService
    {
        

        public static async Task<double> GetMealCalories(string mealDetails)
        {
            try
            {
                HttpClient client = new HttpClient();
                
                client.DefaultRequestHeaders.Add("X-Api-Key", App.Settings.CaloriesApiKey);
                var response = await client.GetAsync(App.Settings.CaloriesApiUrl + mealDetails);
                /*
                 * https://calorieninjas.com/api
                 * first tag in the Json is items
                 * required tag is calories
                 */
                string headerTag = "items";
                string targetTag = "calories";

                if (response.IsSuccessStatusCode)
                {
                    var values = await response.Content.ReadAsStringAsync();
                    //JObject mealFacts = JObject.Parse(values);
                    List<Dictionary<string, object>> mealFacts = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(values);
                    


                    //Simplicity we will read only the first calories value
                    return double.Parse(mealFacts[0][targetTag].ToString());

                    //If we need read multiple value (may be next year)
                    /*
                    for (int i = 0; i < mealFacts["items"].Count(); i++)
                    {
                        var cal = mealFacts["items"][i].SelectToken("calories");
                        await Console.Out.WriteLineAsync(cal.ToString());
                    }
                    */
                }
                return 0; //zero is return if http request failed 
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return 0; //zero is return is there is an error.
            }
            
            
        }
    }
}
