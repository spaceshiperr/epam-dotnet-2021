using System;

namespace Entity.Entity
{
    public class Lecture
    {
        public Lecture(int id,
                       string name,
                       DateTime date,
                       string subject)
        {
            Id = id;
            Name = name;
            Date = date;
            Subject = subject;
        }
        
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public string Subject { get; set; }
    }
}
