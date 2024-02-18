using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityEventsAPI.Data;
using UniversityEventsAPI.Models;

namespace UniversityEventsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UniversityEventsController : Controller
    {
        private readonly UniversityEventsAPIDbContext dbContext;

        public UniversityEventsController(UniversityEventsAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return  Ok(await dbContext.UniversityEvents.ToListAsync());
            
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult> Get([FromRoute] Guid id)
        {
            var universityEvent = await dbContext.UniversityEvents.FindAsync(id);
            if(universityEvent == null)
            {
                return NotFound();
            }
            return Ok(universityEvent);

        }

        [HttpPost]
        public async Task<ActionResult> addUniversityEvent(AddUniversityEventRequest addUniversityEventRequest)
        {
            var universityEvent = new UniversityEvent()
            {
                Id = Guid.NewGuid(),
                Name = addUniversityEventRequest.Name,
                DateTime = addUniversityEventRequest.DateTime,
                Description = addUniversityEventRequest.Description,
                Location = addUniversityEventRequest.Location
            };

            await dbContext.UniversityEvents.AddAsync(universityEvent);
            await dbContext.SaveChangesAsync();

            return Ok(universityEvent);

        }



        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateUniversityEvent([FromRoute] Guid id, UpdateUniversityEventRequest updateUniversityEventRequest)
        {
            var universityEvent = await dbContext.UniversityEvents.FindAsync(id);

            if(universityEvent != null)
            {
                universityEvent.DateTime = updateUniversityEventRequest.DateTime;
                universityEvent.Description = updateUniversityEventRequest.Description;
                universityEvent.Name = updateUniversityEventRequest.Name;
                universityEvent.Location = updateUniversityEventRequest.Location;

                await dbContext.SaveChangesAsync();

                return Ok(universityEvent);
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<ActionResult> DeleteUniversityEvent([FromRoute] Guid id)
        {
            var universityEvent = await dbContext.UniversityEvents.FindAsync(id);
            if (universityEvent != null)
            {
                dbContext.Remove(universityEvent);
                await dbContext.SaveChangesAsync();
                return Ok(universityEvent);
            }
            return NotFound();

        }

    }
}
