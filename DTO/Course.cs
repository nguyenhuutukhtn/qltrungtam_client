using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Course
    {
        

        private int Id { get; set; }
        private String Name { get; set; }
        private String Description { get; set; }
        private String StartDay { get; set; }
        private int TeacherId { get; set; }
        private String FinishDay { get; set; }
        private String Room { get; set; }
        private int StudentNumber { get; set; }
        private String TimeTable { get; set; }
        private int Fee { get; set; }
        private String DiscountInfo { get; set; }

        public Course() { }

        public Course(int id, string name, string description, string startDay, int teacherId, string finishDay, string room, int studentNumber, string timeTable, int fee, string discountInfo)
        {
            Id = id;
            Name = name;
            Description = description;
            StartDay = startDay;
            TeacherId = teacherId;
            FinishDay = finishDay;
            Room = room;
            StudentNumber = studentNumber;
            TimeTable = timeTable;
            Fee = fee;
            DiscountInfo = discountInfo;
        }
    }
}
