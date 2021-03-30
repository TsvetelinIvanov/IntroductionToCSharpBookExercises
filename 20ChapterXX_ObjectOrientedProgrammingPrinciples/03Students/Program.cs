using System;
using System.Linq;

namespace _03Students
{
    class Program
    {
        static void Main(string[] args)
        {
            Student[] students = new Student[]
            {
                new Student("Ivan", "Ivanov", 5.31),
                new Student("Petar", "Petrov", 4.98),
                new Student("Georgi", "Georgiev", 5.37),
                new Student("Iveta", "Ivova", 5.11),
                new Student("Ginka", "Ginkova", 4.51),
                new Student("Petrana", "Petrova", 3.87),
                new Student("Yolo", "Yolov", 5.87),
                new Student("Fidanka", "Fidosova", 5.90),
                new Student("Goran", "Goranov", 4.13),
                new Student("Filip", "Filipov", 5.91)
            };

            Array.Sort(students);
            Console.WriteLine(string.Join(Environment.NewLine, students.Select(s => s)));
        }
    }
}