using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    

    public class StudentBUS
    {
        StudentDAO mStudentDAO;

        public StudentBUS()
        {
            mStudentDAO = new StudentDAO();
        }

        public bool insertNewStudent(Student st)
        {
            return mStudentDAO.insertNewStudent(st);
        }

        public List<Student> getAllStudent()
        {
            return mStudentDAO.getAllStudent();
        }

        public bool updateStudent(Student st)
        {
            return mStudentDAO.updateStudent(st);
        }
    }

   
}
