using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace _03SortStudentsInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, List<StudentName>> courses = new SortedDictionary<string, List<StudentName>>();
            StreamReader reader = new StreamReader("students.txt", UTF8Encoding.UTF8);
            using (reader)
            {
                while (true)
                {
                    string line = reader.ReadLine();
                    if (line == null)
                    {
                        break;
                    }
                    
                    string[] studentInfo = line.Split("|");
                    string firstName = studentInfo[0].Trim().Split()[0];
                    string lastName = studentInfo[0].Trim().Split()[1];
                    string courseName = studentInfo[1].Trim();
                    if (!courses.ContainsKey(courseName))
                    {
                        courses.Add(courseName, new List<StudentName>());
                    }

                    StudentName studentName = new StudentName(firstName, lastName);
                    courses[courseName].Add(studentName);
                }
            }

            foreach (KeyValuePair<string, List<StudentName>> course in courses)
            {
                List<StudentName> studentNames = course.Value;
                studentNames.Sort();
                Console.WriteLine($"{course.Key}: {string.Join(", ", studentNames)}");
            }
        }
    }
}