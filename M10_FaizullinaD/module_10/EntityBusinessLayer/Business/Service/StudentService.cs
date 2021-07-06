using Entity.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Entity;

namespace Business.Service
{
    public class StudentService : IStudentService
    {
        public List<Student> Students;

        public StudentService()
        {
            Students = new List<Student>();
        }

        public void Add(Student student)
        {
            Students.Add(student);
        }

        public void Remove(Student student)
        {
            Students.Remove(student);
        }

        public bool Contains(Student student)
        {
            return Students.Contains(student);
        }
    }
}
