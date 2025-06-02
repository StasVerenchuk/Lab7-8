using System.Runtime.Serialization;

namespace Course.Api
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public DateTime StartDate { get; set; }
    }
}

