using System;

namespace _09Cars
{
    public class Car : IComparable<Car>
    {
        private string[] carIfno = new string[5];

        public Car(string brand = "Unknown", string model = "Unknown", string color = "Unknown", int year = 0, decimal price = 0)
        {
            this.carIfno[0] = this.Brand = brand;
            this.carIfno[1] = this.Model = model;
            this.carIfno[2] = this.Color = color;
            this.carIfno[3] = year.ToString();
            this.Year = year;
            this.carIfno[4] = price.ToString();
            this.Price = price;
        }

        public string Brand { get; }

        public string Model { get; }

        public string Color { get; }

        public int Year { get; }

        public decimal Price { get; }

        public string ReturnInfoByIndex(int index)
        {
            if (index >= 0 && index < this.carIfno.Length)
            {
                return carIfno[index];
            }
            else
            {
                return "Incorrect index passed!";
            }
        }

        public string ReturnProperties()
        {
            return Brand + Model + Color + Year + Price;           
        }

        public string ReturnCarInformation()
        {
            return $"Information about the car: Brand: {this.Brand}, Model {this.Model}, Color {this.Color}, Year: {this.Year}, $Price: {this.Price:f2}.";            
        }

        public int CompareTo(Car otherCar)
        {
            int result = this.Brand.CompareTo(otherCar.Brand);
            if (result == 0)
            {
                result = this.Model.CompareTo(otherCar.Model);
            }

            if (result == 0)
            {
                result = this.Color.CompareTo(otherCar.Color);
            }

            return result;
        }
    }
}