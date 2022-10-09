using System;
using System.Collections.Generic;
//29 Using statement
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Assessment1
{
    internal class Program
    {
        public const int Months = 12;
        public const int Weeks = 52;
        public const int Days = 365;
        public const double DaysPerWeek = (double)Days / (double)Weeks;
        public const double DaysPerMonth = (double)Days / (double)Months;

        public enum Season
        {
            Spring,
            Summer,
            Autumn,
            Winter
        }



        static void Main(string[] args)
        {

            #region Syntax Features method calls PART A
            //1 Selection statements//31 Named Arguments
            Console.WriteLine("1-Selection statements 31-Named Arguments");
            SelectionStatement(value: 48);
            Console.WriteLine("");

            //2 Iteration statements
            Console.WriteLine("2-Iteration Statements");
            IterationStatement();
            Console.WriteLine("");

            //3 Constants
            Console.WriteLine("3-Constants");
            Constants();
            Console.WriteLine("");

            //4 Arrays
            Console.WriteLine("4-Arrays");
            Arrays();

            //5 Classes//9 Constructors//25 Properties
            Console.WriteLine("5-Classes 9-Constructors 25-Properties");
            var person1 = new Person("Keagan", "Erasmus");
            Console.WriteLine(person1);
            Console.WriteLine("");

            //6 Access modifiers//7 Fields//8 Readonly
            Console.WriteLine("6-Access modifiers 7-Fields 8-Readonly");
            var tric1 = new Tricycle();
            Console.WriteLine(tric1.Wheels);
            Console.WriteLine("");

            //10 Passing by value//24 Static
            Console.WriteLine("10-Passing by value 24-Static");
            int n = 5;
            System.Console.WriteLine("The value before calling the method: {0}", n);
            PassingByValue(n);  // Passing the variable by value.
            System.Console.WriteLine("The value after calling the method: {0}", n);
            Console.WriteLine("");

            //11 Passing by refrence
            Console.WriteLine("11-Passing by reference");
            int m = 5;
            System.Console.WriteLine("The value before calling the method: {0}", m);
            PassingByRefrence(ref m);  // Passing the variable by reference.
            System.Console.WriteLine("The value after calling the method: {0}", m);
            Console.WriteLine("");

            //12 Expression body definitions =>
            Console.WriteLine("12-Expression body definitions =>");
            var location = new Location("ChristChurch");
            Console.WriteLine(location.Name);
            Console.WriteLine("");

            //13 Lambda expressions
            Console.WriteLine("13-Lambda expression");
            Func<int, int> square = x => x * x;
            Console.WriteLine(square(5));
            Console.WriteLine("");

            //14 Generic Methods
            Console.WriteLine("14-Generic Methods");
            GenericMethods();
            Console.WriteLine("");

            //15 Interfaces//16 Inheritance
            Console.WriteLine("15-Interfaces 16-Inheritance");
            Cow myCow = new();
            myCow.animalSound();

            //17 Virtual 
            Console.WriteLine("17-Virtual");
            double r = 3.0, h = 5.0;
            Shape l = new Cylinder(r, h);
            // Display results.
            Console.WriteLine("Area of Cylinder = {0:F2}", l.Area());
            Console.WriteLine("");

            //18 Overload
            Console.WriteLine("18-Overload");
            Console.WriteLine(Add(1, 2));
            Console.WriteLine(Add(3, 4, 5));
            Console.WriteLine("");

            //19 Override//22 Base
            Console.WriteLine("19-Override 22-Base");
            var employee1 = new SalesEmployee("Alice", 1000, 500);
            var employee2 = new Employee("Bob", 1200);
            Console.WriteLine($"Employee1 {employee1.Name} earned: {employee1.CalculatePay()}");
            Console.WriteLine($"Employee2 {employee2.Name} earned: {employee2.CalculatePay()}");
            Console.WriteLine("");

            //20 Abstract Classes and Abstract Class Members
            Console.WriteLine("20-Abstract Classes and Abstract Class Members");
            var o = new DerivedClass();
            o.AbstractMethod();
            Console.WriteLine($"x = {o.X}, y = {o.Y}");
            Console.WriteLine("");

            //21 New Modifier//23 Sealed Classes and Sealed Class Members
            Console.WriteLine("21-New Modifier 23-Sealed Classes and Sealed Class Members");
            // Display the new value of x:
            Console.WriteLine(DerivedC.x);
            // Display the hidden value of x:
            Console.WriteLine(BaseC.x);
            // Display the unhidden member y:
            Console.WriteLine(BaseC.y);
            Console.WriteLine("");

            //26 $ - string interpolation
            Console.WriteLine("26-String interpolation");
            string name = "Keagan";
            var date = DateTime.Now;
            Console.WriteLine($"Hello, {name}! Today is {date.DayOfWeek}, it's {date:HH:mm} now.");
            Console.WriteLine("");

            //27 Enumeration types
            Console.WriteLine("27-Enumeration types");
            Season a = Season.Autumn;
            Console.WriteLine($"Integral value of {a} is {(int)a}");  // output: Integral value of Autumn is 2
            var b = (Season)1;
            Console.WriteLine(b);  // output: Summer
            var c = (Season)4;
            Console.WriteLine(c);  // output: 4
            Console.WriteLine("");

            //28 Exceptions and Exception Handling
            // Input for test purposes. Change the values to see
            // exception handling behavior.
            Console.WriteLine("28-Exceptions and Exception Handling");
            double q = 98, w = 0;
            double result;
            try
            {
                result = SafeDivision(q, w);
                Console.WriteLine("{0} divided by {1} = {2}", a, b, result);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Attempted divide by zero.");
            }

            //29 Using statement
            Console.WriteLine("29-Using statements");
            string manyLines = @"This is line one
                This is line two
                Here is line three
                The penultimate line is line four
                This is the final, fifth line.";
            using (var reader = new StringReader(manyLines))
            {
                string? item;
                do
                {
                    item = reader.ReadLine();
                    Console.WriteLine(item);
                } while (item != null);
            }

            //30 Init accessors
            Console.WriteLine("30-Init accessors");
            var s = new Student()
            {
                FirstName = "Jared",
                LastName = "Parosns",
            };
            Console.WriteLine($"Fistname: {s.FirstName}, Lastname: {s.LastName}");
            Console.WriteLine("");

            //32 When
            Console.WriteLine("32-When");
            Console.WriteLine(MakeRequest().Result);
            Console.WriteLine("");

            //33 Object and Collection Initializers
            Console.WriteLine("33-Object and Collection Initializers");
            Student newStudent = new Student {FirstName = "Keagan", LastName = "Erasmus" };
            Console.WriteLine($"Student:\nFirstName: {newStudent.FirstName} LastName: {newStudent.LastName}");
            Console.WriteLine("");

            //34 Reflection
            Console.WriteLine("34-Reflection");
            int i = 42;
            Type type = i.GetType();
            Console.WriteLine(type);
            Console.WriteLine("");

            //35 Delegates
            Console.WriteLine("35-Delegates");
            // Instantiate the delegate.
            Del handler = DelegateMethod;
            // Call the delegate.
            handler("Hello World");
            Console.WriteLine("");

            //36 Event
            Console.WriteLine("36-Event");
            Counter counter = new Counter(new Random().Next(10));
            counter.ThresholdReached += c_ThresholdReached;
            Console.WriteLine("press 'a' key to increase total");
            while (Console.ReadKey(true).KeyChar == 'a')
            {
                Console.WriteLine("adding one");
                counter.Add(1);
            }
            Console.WriteLine("");

            //37 Indexers
            Console.WriteLine("37-Indexers");
            var stringCollection = new SampleCollection<string>();
            stringCollection[0] = "Hello, World This is using Idexers";
            Console.WriteLine(stringCollection[0]);
            Console.WriteLine("");
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

            static double SafeDivision(double x, double y)
            {
                if (y == 0)
                    throw new DivideByZeroException();
                return x / y;
            }

            static void c_ThresholdReached(object sender, EventArgs e)
            {
                Console.WriteLine("The threshold was reached.");
                Environment.Exit(0);
            }

            #endregion

            Console.ReadKey();
        }

        public static async Task<string> MakeRequest()
        {
            var client = new HttpClient();
            var streamTask = client.GetStringAsync("https://localHost:10000");
            try
            {
                var responseText = await streamTask;
                return responseText;
            }
            catch (HttpRequestException e) when (e.Message.Contains("301"))
            {
                return "Site Moved";
            }
            catch (HttpRequestException e) when (e.Message.Contains("404"))
            {
                return "Page Not Found";
            }
            catch (HttpRequestException e)
            {
                return e.Message;
            }
        }

        public delegate void Del(string message);
        public static void DelegateMethod(string message)
        {
            Console.WriteLine(message);
        }

        class Counter
        {
            private int threshold;
            private int total;

            public Counter(int passedThreshold)
            {
                threshold = passedThreshold;
            }

            public void Add(int x)
            {
                total += x;
                if (total >= threshold)
                {
                    ThresholdReached?.Invoke(this, EventArgs.Empty);
                }
            }

            public event EventHandler ThresholdReached;
        }

        class SampleCollection<T>
        {
            // Declare an array to store the data elements.
            private T[] arr = new T[100];

            // Define the indexer to allow client code to use [] notation.
            public T this[int i]
            {
                get { return arr[i]; }
                set { arr[i] = value; }
            }
        }

        class Student
        {
            public string FirstName { get; init; }
            public string LastName { get; init; }
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

        public class BaseC
        {
            public static int x = 55;
            public static int y = 22;
        }
        public class DerivedC : BaseC
        {
            // Hide field 'x'.
            new public static int x = 100;
        }
    }
}