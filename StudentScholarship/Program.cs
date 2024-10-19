using System;
using System.Collections.Generic;

namespace StudentScholarship
{
    public delegate bool IsEligibleforScholarship(Student std);
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Student> Students = new List<Student>();
            Student obj1 = new Student() { RollNo = 1, Name = "Raj", Marks = 75, SportsGrade = 'A' };
            Student obj2 = new Student() { RollNo = 2, Name = "Rahul", Marks = 82, SportsGrade = 'A' };
            Student obj3 = new Student() { RollNo = 3, Name = "Kiran", Marks = 89, SportsGrade = 'B' };
            Student obj4 = new Student() { RollNo = 4, Name = "Sunil", Marks = 86, SportsGrade = 'A' };

            Students.Add(obj1);
            Students.Add(obj2);
            Students.Add(obj3);
            Students.Add(obj4);
            IsEligibleforScholarship isEligible = ScholarshipEligibility;

            List<Student> eligibleStudents = GetEligibleStudents(Students, isEligible);
            //foreach (var student in eligibleStudents)
            //{
            //    Console.WriteLine($"{student.Name}");
            //    if (student < eligibleStudents.Count - 1)
            //    {
            //        Console.WriteLine(",");
            //    }

            //}
            for(int i = 0; i < eligibleStudents.Count;i++)
            {
                Console.Write($"{eligibleStudents[i].Name}");
                if (i < eligibleStudents.Count - 1)
                {
                    Console.Write(", ");
                }
            }

        }
        public static bool ScholarshipEligibility(Student std)
        {
            return std.Marks > 80 && std.SportsGrade == 'A';
            //{

            //    if (std.Marks > 80 && std.SportsGrade == 'A')
            //    {
            //        return true;
            //    }
            //}
            //return false;
        }

        public static List<Student> GetEligibleStudents(List<Student> students, IsEligibleforScholarship isEligible)
        {
            List<Student> eligibleStudents = new List<Student>();

            foreach (var student in students)
            {
                if (isEligible(student))
                {
                    eligibleStudents.Add(student);
                }
            }

            return eligibleStudents;
        }
    }
    public class Student
    {
        public IsEligibleforScholarship elegible { get; set; }
        public int RollNo { get; set; }
        public string Name { get; set; }
        public int Marks { get; set; }
        public char SportsGrade { get; set; }

    }
}

