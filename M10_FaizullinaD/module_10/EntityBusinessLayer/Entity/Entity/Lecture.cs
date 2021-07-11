using System;
using System.Collections.Generic;

namespace Entity.Entity
{
    public class Lecture
    {
        public Lecture(int id,
                       string name,
                       DateTime date,
                       string subject,
                       Lecturer lecturer)
        {
            Id = id;
            Name = name;
            Date = date;
            Subject = subject;
            Lecturer = lecturer;
            VisitationList = new List<Student>();
            HomeworkList = new List<Homework>();
        }
        
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public string Subject { get; set; }

        public Lecturer Lecturer { get; set; }

        public List<Student> VisitationList { get; set; }

        public List<Homework> HomeworkList { get; set; }
    }
}
