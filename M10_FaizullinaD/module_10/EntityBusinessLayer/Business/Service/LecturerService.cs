using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Interface;
using Entity.Entity;

namespace Business.Service
{
    class LecturerService : IService<Lecturer>
    {
        private List<Lecturer> lecturers;

        public LecturerService()
        {
            lecturers = new List<Lecturer>();
        }

        public void Add(Lecturer lecturer)
        {
            lecturers.Add(lecturer);
        }

        public void Remove(int id)
        {
            lecturers.RemoveAll(lecturer => lecturer.Id == id);
        }

        public Lecturer Search(int id)
        {
            return lecturers.Find(lecturer => lecturer.Id == id);
        }

        public void Edit(int id, Lecturer lecturer)
        {
            var index = lecturers.IndexOf(lecturers.First(lect => lect.Id == id));

            if (index != -1)
                lecturers[index] = lecturer;
            else
                throw new System.Exception();
        }

        public static int? Grade(Homework homework)
        {
            throw new NotImplementedException();
        }

    }
}
