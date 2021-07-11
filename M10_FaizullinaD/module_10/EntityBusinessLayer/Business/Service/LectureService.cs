using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Entity;
using Entity.Interface;

namespace Business.Service
{
    class LectureService : IService<Lecture>
    {
        private List<Lecture> lectures;

        public LectureService()
        {
            lectures = new List<Lecture>();
        }

        public void Add(Lecture lecture)
        {
            lectures.Add(lecture);
        }

        public void Remove(int id)
        {
            lectures.RemoveAll(lecture => lecture.Id == id);
        }

        public Lecture Search(int id)
        {
            return lectures.Find(lecture => lecture.Id == id);
        }

        public void Edit(int id, Lecture lecture)
        {
            var index = lectures.IndexOf(lectures.First(lect => lect.Id == id));

            if (index != -1)
                lectures[index] = lecture;
            else
                throw new System.Exception();
        }

        public static Lecture Require(Homework homework, Lecture lecture)
        {
            if (!lecture.HomeworkList.Contains(homework))
                lecture.HomeworkList.Add(homework);

            return lecture; 
        }

        public static Lecture Attend(Student student, Lecture lecture)
        {
            if (!lecture.VisitationList.Contains(student))
                lecture.VisitationList.Add(student);

            return lecture;
        }

        public static Lecture Teach(Lecturer lecturer, Lecture lecture)
        {
            lecture.Lecturer = lecturer;
            return lecture;
        }
    }
}
