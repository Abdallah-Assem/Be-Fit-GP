using BeFit_API.Data;
using BeFit_API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeFit_API.Controllers
{
    public class ExercisesController : Controller
    {
        private readonly WebsiteDbContext _dbContext;
        public ExercisesController(WebsiteDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        [Route("api/get-exercises")]
        public async Task<ActionResult<List<Exercise>>> GetExercises()
        {
            List<Exercise> exercises = await _dbContext.Exercise.Where(x => x.IsActive == true).ToListAsync();
            return Ok(exercises);
        }
    }
}
