using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Entity;
using Entity.Interface;

namespace Business.Service
{
    class HomeworkService : IService<Homework>
    {
        private List<Homework> homeworks;

        public HomeworkService()
        {
            homeworks = new List<Homework>();
        }

        public void Add(Homework homework)
        {
            homeworks.Add(homework);
        }

        public void Remove(int id)
        {
            homeworks.RemoveAll(homework => homework.Id == id);
        }

        public Homework Search(int id)
        {
            return homeworks.Find(homework => homework.Id == id);
        }

        public void Edit(int id, Homework homework)
        {
            var index = homeworks.IndexOf(homeworks.First(hw => hw.Id == id));

            if (index != -1)
                homeworks[index] = homework;
            else
                throw new System.Exception();
        }

        public static Homework Grade(Lecturer lecturer, Homework homework)
        {
            homework.Grade = LecturerService.Grade(homework);
            
            return homework;
        }
    }
}
