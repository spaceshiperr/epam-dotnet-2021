using System.Collections.Generic;

namespace Entity.Entity
{
    public class Course
    {
        public string Subject { get; set; }

        public Lecturer Lecturer { get; set; }

        public List<Lecture> Lectures { get; set; }
    }
}
