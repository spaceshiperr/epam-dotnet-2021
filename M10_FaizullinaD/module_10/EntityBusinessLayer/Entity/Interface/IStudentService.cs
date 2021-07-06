using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Interface
{
    public interface IStudentService
    {
        void Add(Student student);

        void Remove(Student student);

        bool Contains(Student student);
    }
}
