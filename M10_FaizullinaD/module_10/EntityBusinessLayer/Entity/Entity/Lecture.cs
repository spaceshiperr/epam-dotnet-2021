using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public class Lecture
    {
        public string Name { get; set; }

        public DateTime Date { get; set; }

        public string Subject { get; set; }

        public List<Student> VisitationList { get; set; }

        public List<Homework> HomeworkList { get; set; }
    }
}
