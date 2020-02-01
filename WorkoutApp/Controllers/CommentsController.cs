using Microsoft.AspNetCore.Mvc;
using WorkoutApiClient;
using WorkoutApiClient.Model;
using WorkoutApp.Models;

namespace WorkoutApp.Controllers
{
    public class CommentsController : Controller
    {
        public IActionResult Index(int exerciseId)
        {
            string commentUrl
                = $"{Constants.BaseWorkoutApiUrl}/exercisecomment/?format=json&language=2&exercise=" + exerciseId;

            string jsonReponse = WorkoutApiHelper.GetJsonStringFromApi(commentUrl);

            ExerciseComments comments = ExerciseComments.FromJson(jsonReponse);

            var commentViewModel = new CommentViewModel { CommentsList = comments };

            return View(commentViewModel);
        }
    }
}
