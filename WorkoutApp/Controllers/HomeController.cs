using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WorkoutApiClient;
using WorkoutApiClient.Model;
using WorkoutApp.Models;

namespace WorkoutApp.Controllers
{
    public class HomeController : Controller
    {
        public const string BaseWorkoutApiUrl = "https://wger.de/api/v2";

        public IActionResult Index()
        {
            string exerciseCategoryUrl = $"{BaseWorkoutApiUrl}/exercisecategory/?format=json"; //https://wger.de/api/v2/exercisecategory/?format=json

            string jsonReponse = WorkoutApiHelper.GetJsonStringFromApi(exerciseCategoryUrl);

            ExerciseCategory exerciseCategory = ExerciseCategory.FromJson(jsonReponse);

            var homeViewModel = new HomeViewModel { ExerciseCategoryList = exerciseCategory };

            return View(homeViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
