using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Course
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Type { get; set; }
        public String StartDay { get; set; }
        public String Teacher { get; set; }
        public String FinishDay { get; set; }
        public int StudentNumber { get; set; }
        public int Fee { get; set; }
        public String DiscountInfo { get; set; }

        public Course() { }

        public Course(int id, string name, string type, string startDay, string teacher, string finishDay, int studentNumber, int fee, string discountInfo)
        {
            Id = id;
            Name = name;
            Type = type;
            StartDay = startDay;
            Teacher = teacher;
            FinishDay = finishDay;
            StudentNumber = studentNumber;
            Fee = fee;
            DiscountInfo = discountInfo;
        }
    }
}
