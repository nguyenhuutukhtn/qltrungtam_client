using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public static class URL
    {
        public static String root = "http://10.0.2.2:8001";
        public static String add_new_student_endpoint = "/add_new_student/";
        public static String get_all_student_endpoint = "/get_all_student/";
        public static String update_student_endpoint = "/update_student/";
        public static String get_all_courses_endpoint = "/get_all_courses/";
        public static String get_all_teachers_endpoint = "/get_all_teachers/";
        public static String add_new_course_endpoint = "/add_new_course/";
        public static String get_opening_courses_endpoint = "/get_opening_courses/";
    }
}
