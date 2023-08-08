using FallLady.Mood.Domain.Domain.Teachers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Persistance.Repositories.Teachers
{
    public class TeacherRepository:CrudRepository<Teacher,int>,ITeacherRepository
    {
    }
}
