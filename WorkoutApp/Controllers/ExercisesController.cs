using Microsoft.AspNetCore.Mvc;
using WorkoutApiClient;
using WorkoutApiClient.Model;
using WorkoutApp.Models;

namespace WorkoutApp.Controllers
{
    public class ExercisesController : Controller
    {
        public IActionResult Index(int exerciseCategoryId)
        {
            string exercisesUrl 
                = $"{Constants.BaseWorkoutApiUrl}/exercise/?format=json&language=2&category=" +exerciseCategoryId;
            
            string jsonReponse = WorkoutApiHelper.GetJsonStringFromApi(exercisesUrl);
            
            Exercises exercises = Exercises.FromJson(jsonReponse);

            var exercisesViewModel = new ExercisesViewModel { ExercisesList = exercises };

            return View(exercisesViewModel);
        }
    }
}