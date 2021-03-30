namespace _01School
{
    public abstract class Person
    {
        private string name;        

        public Person(string name)
        {
            this.name = name;            
        }

        public string Name => this.name;
    }
}