using BeFit_API.Data;
using BeFit_API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BeFit_API.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly WebsiteDbContext _dbContext;
        public FeedbackController(WebsiteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("api/get-feedbacks-for-user")]
        public async Task<ActionResult<List<GetFeedback>>> GetFeedbacksforUser()
        {
            List<Feedback> Feedbacks = await _dbContext.Feedback.Where(x => x.IsActive == true && x.Approved == true).OrderByDescending(f => f.TimeCreated).ToListAsync();
            List<GetFeedback> getFeedbacks = new List<GetFeedback>();
            foreach (var feedback in Feedbacks)
            {
                GetFeedback getFeedback = new GetFeedback()
                {
                    Id = feedback.Id,
                    UserId = feedback.UserId,
                    Message = feedback.Message,
                    TimeCreated = feedback.TimeCreated,
                    Approved = feedback.Approved,
                    IsActive = feedback.IsActive,
                    FeedbackUser = await _dbContext.User.FirstOrDefaultAsync(x => x.Id == feedback.UserId)
                };

                getFeedbacks.Add(getFeedback);
            }
            return Ok(getFeedbacks);
        }
        [HttpGet]
        [Route("api/get-feedbacks-for-admin")]
        public async Task<ActionResult<List<GetFeedback>>> GetFeedbacksforAdmin()
        {
            List<Feedback> Feedbacks = await _dbContext.Feedback.Where(x => x.IsActive == true).OrderByDescending(f => f.TimeCreated).ToListAsync();
            List<GetFeedback> getFeedbacks = new List<GetFeedback>();
            foreach (var feedback in Feedbacks)
            {
                GetFeedback getFeedback = new GetFeedback()
                {
                    Id = feedback.Id,
                    UserId = feedback.UserId,
                    Message = feedback.Message,
                    TimeCreated = feedback.TimeCreated,
                    Approved = feedback.Approved,
                    IsActive = feedback.IsActive,
                    FeedbackUser = await _dbContext.User.FirstOrDefaultAsync(x => x.Id == feedback.UserId)
                };

                getFeedbacks.Add(getFeedback);
            }
            return Ok(getFeedbacks);
        }
        [HttpPost]
        [Route("api/add-feedback")]
        public async Task<IActionResult> AddFeedback([FromBody] Feedback feedback)
        {
            if (
                feedback.UserId == Guid.Empty
                && string.IsNullOrEmpty(feedback.Message)
                )
            {
                return BadRequest("no Feedback food");
            }
            
            feedback.Id = Guid.NewGuid();
            feedback.TimeCreated = DateTime.Now;
            feedback.Approved = false;
            feedback.IsActive = true;
            await _dbContext.Feedback.AddAsync(feedback);
            await _dbContext.SaveChangesAsync();
            return Ok(feedback);
        }
        [HttpGet]
        [Route("api/delete-feedback/{id}")]
        public async Task<IActionResult> DeleteFeedback(Guid id)
        {
            var deletedFeedback = await _dbContext.Feedback.FindAsync(id);

            deletedFeedback.IsActive = false;

            await _dbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpGet]
        [Route("api/approve-feedback/{id}")]
        public async Task<IActionResult> ApproveFeedback(Guid id)
        {
            var approvedFeedback = await _dbContext.Feedback.FindAsync(id);
            approvedFeedback.Approved = true;
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
