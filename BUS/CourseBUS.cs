using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public class CourseBUS
    {
        public CourseBUS() { }

        public List<Course> getListAllCourse()
        {
            return new CourseDAO().getAllCourse();
        }
    }
}
