using System.Collections.Generic;
using System.Linq;

namespace _03StudentsWithLexicographicallySmallerNames
{
    public class StudentsWithFirstNameBeforeLastNameLexicographicallyMethod
    {
        public static IEnumerable<Student> FindStudentsWithFirstNameBeforeLastNameLexicographically(IEnumerable<Student> students)
        {
            IOrderedEnumerable<Student> studentsWithFirstNameBeforeLastName =
                from student in students
                where student.FirstName.CompareTo(student.LastName) < 0
                orderby student.FirstName, student.LastName
                select student;

            return studentsWithFirstNameBeforeLastName;
        }
    }
}