using System;
using System.Collections.Generic;
using System.Drawing;

namespace Assessment1
{
    internal class Program
    {
        public const int Months = 12;
        public const int Weeks = 52;
        public const int Days = 365;
        public const double DaysPerWeek = (double)Days / (double)Weeks;
        public const double DaysPerMonth = (double)Days / (double)Months;

        static void Main(string[] args)
        {


            #region Syntax Features method calls PART A
            //1 Selection statements
            SelectionStatement(45);

            //2 Iteration statements
            IterationStatement();

            //3 Constants
            Constants();

            //4 Arrays
            Arrays();

            //5 Classes//9 Constructors
            var person1 = new Person("Keagan", "Erasmus");
            Console.WriteLine(person1);
            Console.WriteLine("");

            //6 Access modifiers//7 Fields//8 Readonly
            var tric1 = new Tricycle();
            Console.WriteLine(tric1.Wheels);
            Console.WriteLine("");

            //10 Passing by value
            int n = 5;
            System.Console.WriteLine("The value before calling the method: {0}", n);
            PassingByValue(n);  // Passing the variable by value.
            System.Console.WriteLine("The value after calling the method: {0}", n);
            Console.WriteLine("");

            //11 Passing by refrence
            int m = 5;
            System.Console.WriteLine("The value before calling the method: {0}", n);
            PassingByRefrence(ref m);  // Passing the variable by reference.
            System.Console.WriteLine("The value after calling the method: {0}", n);
            Console.WriteLine("");

            //12 Expression body definitions =>
            var location = new Location("ChristChurch");
            Console.WriteLine(location.Name);
            Console.WriteLine("");

            //13 Lambda expressions
            Func<int, int> square = x => x * x;
            Console.WriteLine(square(5));
            Console.WriteLine("");

            //14 Generic Methods
            GenericMethods();
            Console.WriteLine("");

            //15 Interfaces//16 Inheritance
            Cow myCow = new();
            myCow.animalSound();

            //17 Virtual 
            double r = 3.0, h = 5.0;
            Shape l = new Cylinder(r, h);
            // Display results.
            Console.WriteLine("Area of Cylinder = {0:F2}", l.Area());
            Console.WriteLine("");

            //18 Overload
            Console.WriteLine(Add(1, 2));
            Console.WriteLine(Add(3, 4, 5));
            Console.WriteLine("");

            //19 Override
            var employee1 = new SalesEmployee("Alice", 1000, 500);
            var employee2 = new Employee("Bob", 1200);
            Console.WriteLine($"Employee1 {employee1.Name} earned: {employee1.CalculatePay()}");
            Console.WriteLine($"Employee2 {employee2.Name} earned: {employee2.CalculatePay()}");
            Console.WriteLine("");

            //20 Abstract Classes and Abstract Class Members
            var o = new DerivedClass();
            o.AbstractMethod();
            Console.WriteLine($"x = {o.X}, y = {o.Y}");
            #endregion



            #region Syntax Features methods PART A
            void SelectionStatement(double value)
            {
                if (value < 0 || value > 100)
                {
                    Console.Write("Warning: not acceptable value! ");
                }

                Console.WriteLine($"The measurement value is {value}");
            }

            void IterationStatement()
            {
                Console.WriteLine("Fibonaci Numbers");
                var fibNumbers = new List<int> { 0, 1, 1, 2, 3, 5, 8, 13 };
                foreach (int element in fibNumbers)
                {
                    Console.WriteLine($"{element} \n");
                }
            }

            void Constants()
            {
                Console.WriteLine("Days per week {0}\nDays per monthe{1}\n",DaysPerWeek, DaysPerMonth);
            }

            void Arrays()
            {
                var names = new List<string> { "<name>", "Ana", "Felipe" };
                foreach (var name in names)
                {
                    Console.WriteLine($"Hello {name.ToUpper()}!\n");
                }
            }

            static void PassingByValue(int x)
            // The parameter x is passed by value.
            // Changes to x will not affect the original value of x.
            {
                x *= x;
                System.Console.WriteLine("The value inside the method: {0}", x);
            }

            static void PassingByRefrence(ref int x)
            // The parameter x is passed by reference.
            // Changes to x will affect the original value of x.
            {
                x *= x;
                System.Console.WriteLine("The value inside the method: {0}", x);
            }

            static void Swap<T>(ref T lhs, ref T rhs)
            {
                T temp;
                temp = lhs;
                lhs = rhs;
                rhs = temp;
            }
            // this tests the swap method
            static void GenericMethods()
            {
                int a = 1;
                int b = 2;

                Swap<int>(ref a, ref b);
                System.Console.WriteLine(a + " " + b);
            }

            #endregion
            Console.ReadKey();
        }

        public class Person
        {
            public readonly string first;
            public readonly string last;

            // Constructor that takes one argument:
            public Person(string firstname, string lastname)
            {
                first = firstname;
                last = lastname;
            }

            // Method that overrides the base class (System.Object) implementation.
            public override string ToString()
            {
                return first + " " + last;
            }
        }

        public class Tricycle
        {
            // protected method:
            protected void Pedal() { }

            // private field:
            private readonly int _wheels = 3;

            // protected internal property:
            protected internal int Wheels
            {
                get { return _wheels; }
            }
        }

        public class Location
        {
            private string locationName;

            public Location(string name)
            {
                locationName = name;
            }

            public string Name => locationName;
        }

        public class Cow:IAnimal
        {
            public void animalSound()
            {
                Console.WriteLine("The cow goes: MOO MOO\n");
            }
        }

        public class Shape
        {
            public const double PI = Math.PI;
            protected double _x, _y;

            public Shape(double x, double y)
            {
                _x = x;
                _y = y;
            }

            public virtual double Area()
            {
                return _x * _y;
            }
        }
        public class Cylinder : Shape
        {
            public Cylinder(double r, double h) : base(r, h)
            {
            }

            public override double Area()
            {
                return 2 * PI * _x * _x + 2 * PI * _x * _y;
            }
        }

        static int Add(int x, int y)
        {
            return x + y;
        }
        static int Add(int x, int y, int z)
        {
            return x + y + z;
        }

        public class Employee
        {
            public string Name { get; }

            // Basepay is defined as protected, so that it may be
            // accessed only by this class and derived classes.
            protected decimal _basepay;

            // Constructor to set the name and basepay values.
            public Employee(string name, decimal basepay)
            {
                Name = name;
                _basepay = basepay;
            }

            // Declared virtual so it can be overridden.
            public virtual decimal CalculatePay()
            {
                return _basepay;
            }
        }

        // Derive a new class from Employee.
        public class SalesEmployee : Employee
        {
            // New field that will affect the base pay.
            private decimal _salesbonus;

            // The constructor calls the base-class version, and
            // initializes the salesbonus field.
            public SalesEmployee(string name, decimal basepay, decimal salesbonus)
                : base(name, basepay)
            {
                _salesbonus = salesbonus;
            }

            // Override the CalculatePay method
            // to take bonus into account.
            public override decimal CalculatePay()
            {
                return _basepay + _salesbonus;
            }
        }

        abstract class BaseClass
        {
            protected int _x = 100;
            protected int _y = 150;

            // Abstract method
            public abstract void AbstractMethod();

            // Abstract properties
            public abstract int X { get; }
            public abstract int Y { get; }
        }
        class DerivedClass : BaseClass
        {
            public override void AbstractMethod()
            {
                _x++;
                _y++;
            }

            public override int X   // overriding property
            {
                get
                {
                    return _x + 10;
                }
            }

            public override int Y   // overriding property
            {
                get
                {
                    return _y + 10;
                }
            }
        }
    }
}