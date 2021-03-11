using System;

namespace Chapter11
{
    public class Cat
    {
        private string name;
        private string color;

        public Cat()
        {
            this.name = "Unnamed";
            this.color = "gray";
        }
        
        public Cat(string name, string color)
        {
            this.name = name;
            this.color = color;
        }

        public string Name
        {           
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        public string Color
        {            
            get
            {
                return this.color;
            }

            set
            {
                this.color = value;
            }
        }
        
        public void SayMiau()
        {
            Console.WriteLine("Cat {0} said: Miauuuuuu!", name);
        }
    }
}