using Microsoft.AspNetCore.Mvc;

namespace WorkoutApp.Controllers
{
    public class ExercisesController : Controller
    {
        public IActionResult Index(int exerciseCategoryId)
        {
            // https://wger.de/api/v2/exercise/?format=json&category=8

            // 1. build the url above with the passed in category id

            // 2. get the json using the WorkoutApiHelper class

            // 3. deserialize it using Exercises.FromJson() method that I have created



            
            return View(); //return with a view model - call it ExercisesViewModel
        }
    }
}