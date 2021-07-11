using Entity.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Entity;

namespace Business.Service
{
    public class StudentService : IService<Student>
    {
        private List<Student> students;

        public StudentService()
        {
            students = new List<Student>();
        }

        public void Add(Student student)
        {
            students.Add(student);
        }

        public void Remove(int id)
        {
            students.RemoveAll(student => student.Id == id);
        }

        public Student Search(int id)
        {
            return students.Find(student => student.Id == id);
        }

        public void Edit(int id, Student student)
        {
            var index = students.IndexOf(students.First(st => st.Id == id));

            if (index != -1)
                students[index] = student;
            else
                throw new System.Exception();
        }

        
    }
}
