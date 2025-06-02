using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CourseService
{
    [DataContract(Namespace = "")]
    public class Course
    {
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public double Price { get; set; }
        [DataMember]
        public DateTime StartDate { get; set; }
    }
}