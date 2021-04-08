using System;
using System.Collections.Generic;
using System.Linq;

namespace _04StudentsByAgeRange
{
    class Program
    {
        static void Main(string[] args)
        {
            int studentsCount = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();
            for (int i = 0; i < studentsCount; i++)
            {
                string[] studentInfo = Console.ReadLine().Split();
                string firstName = studentInfo[0];
                string lastName = studentInfo[1];
                int age = int.Parse(studentInfo[2]);
                students.Add(new Student(firstName, lastName, age));
            }

            IEnumerable<Student> studentsByAgeRange =
                   from student in students
                   where student.Age >= 18 && student.Age <= 24
                   select student;                   

            foreach (Student student in studentsByAgeRange)
            {
                Console.WriteLine($"First Name: {student.FirstName}; LastName: {student.LastName}; Age: {student.Age}.");
            }
        }
    }
}