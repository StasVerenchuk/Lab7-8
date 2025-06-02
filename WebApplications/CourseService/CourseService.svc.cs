using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace CourseService
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class CourseService : ICourseService
    {
        public List<Course> GetCourses()
        {
            return PopulateCourseData();
        }

        private List<Course> PopulateCourseData()
        {
            List<Course> courses = new List<Course>();

            courses.Add(new Course
            {
                Title = "English A1",
                Price = 1200.0,
                StartDate = new DateTime(2025, 6, 15)
            });
            courses.Add(new Course
            {
                Title = "English B2",
                Price = 1200.0,
                StartDate = new DateTime(2025, 6, 18)
            });

            return courses;
        }
    }
}
