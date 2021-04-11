using System;

namespace _05EstateCompany
{
    public class EstateCompanyTest
    {
        private static Employee employee1 = new Employee("First Employee", "Boss", 120);
        private static Employee employee2 = new Employee("Second Employee", "Employee", 18);
        private static Employee employee3 = new Employee("Third Employee", "Employee", 1);

        private static Apartment apartment = new Apartment("Lulin 6", 46, 1739.13m, 8, true, false);
        private static House house = new House("Chepintsi", 120, 500, 39, 81, 2, true);
        private static Shop shop = new Shop("Studentski Grad", 15, 3573.17m);
        private static Area area = new Area("Breznik", 300, 100);

        private static EstateCompany estateCompany1 = new EstateCompany("First Company", "111111111", new Employee[] { employee1, employee2, employee3 }, new Estate[] { apartment, house, shop, area });
        private static EstateCompany estateCompany2 = new EstateCompany("Second Company", "111111112", new Employee[] { }, new Estate[] { apartment, house, shop, area, shop, apartment });
        private static EstateCompany estateCompany3 = new EstateCompany("Third Company", "111111113", new Employee[] { employee1, employee2, employee3, employee2, employee1 }, new Estate[] { });
        private static EstateCompany estateCompany4 = new EstateCompany("Fourth Company", "111111114", new Employee[] { }, new Estate[] { });

        public static void TestEstateCompany()
        {
            Console.WriteLine(estateCompany1);
            Console.WriteLine(estateCompany2);
            Console.WriteLine(estateCompany3);
            Console.WriteLine(estateCompany4);

            Console.WriteLine(estateCompany4.AddEmployee(employee1)); 
            Console.WriteLine(estateCompany4.AddEmployee(employee2));
            Console.WriteLine(estateCompany4.AddEmployee(employee3));
            Console.WriteLine(estateCompany4.AddEmployee(employee1));
            Console.WriteLine(estateCompany4.RemoveEmployee(employee2));
            Console.WriteLine(estateCompany4.RemoveEmployee(employee2));

            Console.WriteLine(estateCompany4.AddEstate(apartment));
            Console.WriteLine(estateCompany4.AddEstate(house));
            Console.WriteLine(estateCompany4.AddEstate(shop));
            Console.WriteLine(estateCompany4.AddEstate(area));
            Console.WriteLine(estateCompany4.AddEstate(apartment));
            Console.WriteLine(estateCompany4.RemoveEstate(shop));
            Console.WriteLine(estateCompany4.RemoveEstate(shop));          

            Console.WriteLine(estateCompany4);
            
            //Output:
            //Company Name: First Company
            //Bulstat: 111111111
            //Employees(3): Employee Name: First Employee, Position: Boss, Intership: 120 months; Employee Name: Second Employee, Position: Employee, Intership: 18 months; Employee Name: Third Employee, Position: Employee, Intership: 1 months.
            //Estates: 4
            //Type: Apartment, Area: 46 square meters, Price: $1739.13 per square meter($79999.98 in total), Location: Lulin 6, Floor: 8, Elevator: Yes, Furnished: No.
            //Type: House, Area: 120 square meters, Price: $500.00 per square meter($60000.00 in total), Location: Chepintsi, Built Up Area: 39 square meters, Not Built Up Area: 81 square meters, Floors: 2, Furnished: Yes.
            //Type: Shop, Area: 15 square meters, Price: $3573.17 per square meter($53597.55 in total), Location: Studentski Grad.
            //Type: Area, Area: 300 square meters, Price: $100.00 per square meter($30000.00 in total), Location: Breznik.
            //--------------------
            //Company Name: Second Company
            //Bulstat: 111111112
            //Employees(0): .
            //Estates: 4
            //Type: Apartment, Area: 46 square meters, Price: $1739.13 per square meter($79999.98 in total), Location: Lulin 6, Floor: 8, Elevator: Yes, Furnished: No.
            //Type: House, Area: 120 square meters, Price: $500.00 per square meter($60000.00 in total), Location: Chepintsi, Built Up Area: 39 square meters, Not Built Up Area: 81 square meters, Floors: 2, Furnished: Yes.
            //Type: Shop, Area: 15 square meters, Price: $3573.17 per square meter($53597.55 in total), Location: Studentski Grad.
            //Type: Area, Area: 300 square meters, Price: $100.00 per square meter($30000.00 in total), Location: Breznik.
            //--------------------
            //Company Name: Third Company
            //Bulstat: 111111113
            //Employees(3): Employee Name: First Employee, Position: Boss, Intership: 120 months; Employee Name: Second Employee, Position: Employee, Intership: 18 months; Employee Name: Third Employee, Position: Employee, Intership: 1 months.
            //Estates: 0

            //--------------------
            //Company Name: Fourth Company
            //Bulstat: 111111114
            //Employees(0): .
            //Estates: 0

            //--------------------
            //True
            //True
            //True
            //False
            //True
            //False
            //True
            //True
            //True
            //True
            //False
            //True
            //False
            //Company Name: Fourth Company
            //Bulstat: 111111114
            //Employees(2): Employee Name: First Employee, Position: Boss, Intership: 120 months; Employee Name: Third Employee, Position: Employee, Intership: 1 months.
            //Estates: 3
            //Type: Apartment, Area: 46 square meters, Price: $1739.13 per square meter($79999.98 in total), Location: Lulin 6, Floor: 8, Elevator: Yes, Furnished: No.
            //Type: House, Area: 120 square meters, Price: $500.00 per square meter($60000.00 in total), Location: Chepintsi, Built Up Area: 39 square meters, Not Built Up Area: 81 square meters, Floors: 2, Furnished: Yes.
            //Type: Area, Area: 300 square meters, Price: $100.00 per square meter($30000.00 in total), Location: Breznik.
            //--------------------
        }
    }
}
