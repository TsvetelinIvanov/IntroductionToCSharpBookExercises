namespace _22School
{
    public class Discipline
    {
        private string name;
        private int lessonsCount;
        private int exercisesCount;

        public Discipline(string name, int lessonsCount, int exercisesCount)
        {
            this.name = name;
            this.lessonsCount = lessonsCount;
            this.exercisesCount = exercisesCount;
        }        

        public override string ToString()
        {            
            return $"Name: {this.name}, Lessons Count: {this.lessonsCount}, Exercises Count: {this.exercisesCount}";
        }
    }
}