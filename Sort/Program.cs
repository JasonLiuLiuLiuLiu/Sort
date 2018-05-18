using System;
using System.Collections.Generic;

namespace Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            var students = InitData();

            students.Sort();


            Console.WriteLine("Name-Order");

            foreach (var student in students)
            {
                Console.WriteLine($"学校:{student.Class.School.Name}-{student.Class.School.Order}>>班级:{student.Class.Name}-{student.Class.Order}>>学生:{student.Name}-{student.Order}");
            }

            Console.ReadLine();
        }

        static List<Student> InitData()
        {
            var school1 = new School()
            {
                Order = 1,
                Name = "A",

            };
            var school2 = new School
            {
                Name = "B",
                Order = 0
            };

            var class1 = new Class
            {
                Order = 1,
                Name = "1",
                School = school1,
            };

            var class2 = new Class
            {
                Order = 2,
                Name = "2",
                School = school1,
            };

            var class3 = new Class
            {
                Order = 1,
                Name = "1",
                School = school2,
            };

            var student1 = new Student
            {
                Order = 1,
                Name = "1",
                Class = class1,
            };


            var student2 = new Student
            {
                Order = 2,
                Name = "2",
                Class = class1,
            };


            var student3 = new Student
            {
                Order = 3,
                Name = "3",
                Class = class1,
            };


            var student4 = new Student
            {
                Order = 1,
                Name = "1",
                Class = class2,
            };


            var student5 = new Student
            {
                Order = 1,
                Name = "1",
                Class = class3,
            };

            return new List<Student> { student5, student3, student4, student2, student1 };

        }
    }
}
