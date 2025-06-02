using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Course.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly Course[] courses = new Course[]
        {
            new Course{Id = 1, Title = "English B2", Price = 1200.0, StartDate = DateTime.Now.AddDays(10)},
            new Course{Id = 1, Title = "English C1", Price = 800.0, StartDate = DateTime.Now.AddDays(19)}
        };

        [HttpGet]
        public ActionResult<IEnumerable<Course>> GetCourses()
        {
            return courses;
        }

        [HttpGet("{id}")]
        public ActionResult<Course> GetCourse(int id)
        {
            var course = courses.FirstOrDefault((c) => c.Id == id);
            if (course == null)
                return NotFound();
            return Ok(course);
        }
    }
}
