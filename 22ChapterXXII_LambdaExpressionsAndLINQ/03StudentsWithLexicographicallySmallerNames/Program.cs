using System;
using System.Collections.Generic;

namespace _03StudentsWithLexicographicallySmallerNames
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

            IEnumerable<Student> studentsWithFirstNameBeforeLastName = StudentsWithFirstNameBeforeLastNameLexicographicallyMethod.FindStudentsWithFirstNameBeforeLastNameLexicographically(students);
            foreach (Student student in studentsWithFirstNameBeforeLastName)
            {
                Console.WriteLine($"First Name: {student.FirstName}; LastName: {student.LastName}; Age: {student.Age}.");
            }
        }
    }
}