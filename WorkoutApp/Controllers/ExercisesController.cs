using Microsoft.AspNetCore.Mvc;

using WorkoutApiClient;
using WorkoutApiClient.Model;
using WorkoutApp.Models;

namespace WorkoutApp.Controllers
{
    public class ExercisesController : Controller
    {

        public const string BaseWorkoutApiUrl = "https://wger.de/api/v2";

        public IActionResult Index(int exerciseCategoryId)
        {
            // https://wger.de/api/v2/exercise/?format=json&category=8

            // 1. build the url above with the passed in category id

            string exercisesUrl = $"{BaseWorkoutApiUrl}/exercise/?format=json&category=" +exerciseCategoryId;

            // 2. get the json using the WorkoutApiHelper class
            string jsonReponse = WorkoutApiHelper.GetJsonStringFromApi(exercisesUrl);

            // 3. deserialize it using Exercises.FromJson() method that I have created
            Exercises exercises = Exercises.FromJson(jsonReponse);

            var exercisesViewModel = new ExercisesViewModel { ExercisesList = exercises };

            return View(exercisesViewModel); //return with a view model - call it ExercisesViewModel

        }
    }
}