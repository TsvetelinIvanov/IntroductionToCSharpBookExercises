using System;
using System.Collections.Generic;

namespace _02Human
{
    class Program
    {
        static void Main(string[] args)
        {
            Student[] students = ReadStudents();
            Worker[] workers = ReadWorkers();
            List<Human> humans = new List<Human>(students.Length + workers.Length);
            humans.AddRange(students);
            humans.AddRange(workers);
            humans.Sort();
            foreach (Human human in humans)
            {
                Console.WriteLine(human);
            }
        }

        static Student[] ReadStudents()
        {
            int studentsCount = int.Parse(Console.ReadLine());
            Student[] students = new Student[studentsCount];
            for (int i = 0; i < studentsCount; i++)
            {                
                string[] studentInfo = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                string personalName = studentInfo[0];
                string familyName = studentInfo[1];
                double grade = double.Parse(studentInfo[2]);
                Student student = new Student(personalName, familyName, grade);
                students[i] = student;
            }

            return students;
        }

        static Worker[] ReadWorkers()
        {
            int workersCount = int.Parse(Console.ReadLine());
            Worker[] workers = new Worker[workersCount];
            for (int i = 0; i < workersCount; i++)
            {                
                string[] workerInfo = Console.ReadLine().Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);
                string personalName = workerInfo[0];
                string familyName = workerInfo[1];
                decimal salary = decimal.Parse(workerInfo[2]);
                int hoursCount = int.Parse(workerInfo[3]);
                Worker worker = new Worker(personalName, familyName, salary, hoursCount);
                workers[i] = worker;
            }

            return workers;
        }        
    }
}