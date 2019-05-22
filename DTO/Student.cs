using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Student
    {
        public Student() { }

        public Student(int id, string name, string birthday, int grade, string gender, string phoneNumber, string email, string school, string parentName, string parentPhoneNum)
        {
            Id = id;
            Name = name;
            Birthday = birthday;
            Grade = grade;
            Gender = gender;
            PhoneNum = phoneNumber;
            Email = email;
            School = school;
            ParentName = parentName;
            ParentPhoneNum = parentPhoneNum;
        }

        public int Id { get; set; }
        public String Name { get; set; }
        public String Birthday { get; set; }
        public int Grade { get; set; }
        public String Gender { get; set; }
        public String PhoneNum { get; set; }
        public String Email { get; set; }
        public String School { get; set; }
        public String ParentName { get; set; }
        public String ParentPhoneNum { get; set; }
    }
}
