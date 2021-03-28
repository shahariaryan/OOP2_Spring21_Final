using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourse
{
    class Course
    {
        public string CourseName { get; set; }
        public string CourseId { get; set; }

        Student[] students;
        public int totalstudents { get; set; }
        public Course() { }
        public Course(string coursename, string courseid)
        {
            this.CourseName = coursename;
            this.CourseId = courseid;
            students = new Student[30];
        }
        public void EnrollStudent(params Student[] students)
        {
            foreach (var Student in students)
            {
                this.students[totalstudents++] = Student;
            }
        }

        public void showInfo()
        {
            Console.WriteLine("Course Name: " + CourseName);
            Console.WriteLine("ID: " + CourseId);
            Console.WriteLine("Total number of students in {0} is :{1}", CourseName, totalstudents);
        }
    }
}