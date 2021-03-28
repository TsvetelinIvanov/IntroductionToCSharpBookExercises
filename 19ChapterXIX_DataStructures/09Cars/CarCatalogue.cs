using Magnum.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09Cars
{
    public class CarCatalogue
    {
        private Dictionary<string, MultiDictionary<string, Car>>[] carCatalogue = new Dictionary<string, MultiDictionary<string, Car>>[3];
        private OrderedMultiDictionary<decimal, Car> priceCatalogue = new OrderedMultiDictionary<decimal, Car>(true);
        private OrderedMultiDictionary<int, Car> yearCatalogue = new OrderedMultiDictionary<int, Car>(true);

        public CarCatalogue()
        {
            for (int i = 0; i < this.carCatalogue.Length; i++)
            {
                this.carCatalogue[i] = new Dictionary<string, MultiDictionary<string, Car>>();
            }
        }

        public string Add(Car car)
        {                    
            for (int i = 0; i < this.carCatalogue.Length; i++)
            {
                string carInfo = car.ReturnInfoByIndex(i);
                if (this.carCatalogue[i].ContainsKey(carInfo))
                {
                    this.carCatalogue[i][carInfo].Add(car.ReturnProperties(), car);
                }
                else
                {
                    this.carCatalogue[i].Add(carInfo, new MultiDictionary<string, Car>(true));
                    this.carCatalogue[i][carInfo].Add(car.ReturnProperties(), car);
                }
            }

            this.priceCatalogue.Add(car.Price, car);
            this.yearCatalogue.Add(car.Year, car);

            return "Car Added.";
        }

        public string GetCarsByName(Car car, bool[] usedProperties)
        {            
            StringBuilder carsBuilder = new StringBuilder();
            List<Car> cars = new List<Car>();
            for (int i = 0; i < this.carCatalogue.Length; i++)
            {
                if (usedProperties[i])
                {
                    if (cars.Count == 0)
                    {
                        string currentProperty = car.ReturnInfoByIndex(i);
                        if (this.carCatalogue[i].ContainsKey(currentProperty))
                        {
                            cars = this.carCatalogue[i][currentProperty].Values.ToList();
                        }                        
                    }
                    else
                    {
                        List<Car> searchedCars = new List<Car>();                        
                        foreach (Car searchedCar in cars)
                        {
                            string currentProperty = car.ReturnInfoByIndex(i);
                            if (this.carCatalogue[i].ContainsKey(currentProperty))
                            {
                                if (this.carCatalogue[i][currentProperty].ContainsKey(searchedCar.ReturnProperties()))
                                {
                                    searchedCars.Add(searchedCar);
                                }
                            }
                        }

                        cars = searchedCars;
                    }
                }
            }

            carsBuilder.AppendLine(cars.Count + " cars found:");
            foreach (Car searchedCar in cars)
            {
                carsBuilder.AppendLine(searchedCar.ReturnCarInformation());
            }            

            return carsBuilder.ToString();
        }

        public string YearSearch(int startYear, int endYear)
        {            
            StringBuilder carsByYearBuilder = new StringBuilder();
            Car[] cars = this.yearCatalogue.Values.ToArray();
            int carsCounter = 0;

            foreach (Car car in cars)
            {
                if (car.Year >= startYear && car.Year <= endYear)
                {
                    carsCounter++;
                }
            }

            carsByYearBuilder.AppendLine(carsCounter + " cars found:");
            foreach (Car car in cars)
            {
                if (car.Year >= startYear && car.Year <= endYear)
                {
                    carsByYearBuilder.AppendLine(car.ReturnCarInformation());
                }
            }            

            return carsByYearBuilder.ToString();
        }

        public string PriceSearch(decimal startPrice, decimal endPrice)
        {            
            StringBuilder carsByPriceBuilder = new StringBuilder();
            Car[] cars = this.priceCatalogue.Values.ToArray();
            int carsCounter = 0;

            foreach (Car car in cars)
            {
                if (car.Price >= startPrice && car.Price <= endPrice)
                {
                    carsCounter++;
                }
            }

            carsByPriceBuilder.AppendLine(carsCounter + " cars found:");
            foreach (Car car in cars)
            {
                if (car.Price >= startPrice && car.Price <= endPrice)
                {
                    carsByPriceBuilder.AppendLine(car.ReturnCarInformation());
                }
            }
            
            return carsByPriceBuilder.ToString();
        }
    }
}