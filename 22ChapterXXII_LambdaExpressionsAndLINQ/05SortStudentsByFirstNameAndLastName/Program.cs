using System;
using System.Collections.Generic;
using System.Linq;

namespace _05SortStudentsByFirstNameAndLastName
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

            IEnumerable<Student> orderedByLambdaStudents = students.OrderByDescending(s => s.FirstName).ThenByDescending(s => s.LastName);

            Console.WriteLine("Students ordered by lambda LINQ expression:");
            foreach (Student student in orderedByLambdaStudents)
            {
                Console.WriteLine($"First Name: {student.FirstName}; LastName: {student.LastName}; Age: {student.Age}.");
            }

            IEnumerable<Student> orderedByLINQStudents =
                   from student in students
                   orderby student.FirstName descending, student.LastName descending
                   select student;

            Console.WriteLine("Students ordered by query LINQ:");
            foreach (Student student in orderedByLINQStudents)
            {
                Console.WriteLine($"First Name: {student.FirstName}; LastName: {student.LastName}; Age: {student.Age}.");
            }
        }
    }
}