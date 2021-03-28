using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourse
{
    class Student
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public float Cgpa { get; set; }

        Course[] course;
        public int courseCount { get; set; }
           

        public Student() { }
        public Student(string name, string id, float cgpa)
        {
            this.Name = name;
            this.Id = id;
            this.Cgpa = cgpa;
            course = new Course[5];
        }
        public void AddCourse(params Course[] courses)
        {
            foreach (var c in courses)
            {
                this.course[courseCount++]=c;
            }
        }
        
        public void Show()
        {
            for (int i=0;i<courseCount;i++)
            {
                course[i].showInfo();
            }
        }


        public void showInfo()
        {
            Console.WriteLine("Student Name: " + Name);
            Console.WriteLine("Id: " + Id);
            Console.WriteLine("CGPA: " + Cgpa);
           
        }
    }
}
