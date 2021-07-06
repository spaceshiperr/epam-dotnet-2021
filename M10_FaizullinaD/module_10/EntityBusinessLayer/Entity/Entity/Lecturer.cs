using System.Collections.Generic;

namespace Entity.Entity
{
    public class Lecturer
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public List<Course> Courses { get; set; }
    }
}
