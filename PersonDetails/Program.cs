using System;
using System.Collections.Generic;
using System.Net;
using System.Xml.Linq;
namespace MockTask
{
    public class Person
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public Person(string name, string address, int age)
        {
            this.Name = name;
            this.Address = address;
            this.Age = age;
        }
    }
    public class PersonImplementation
    {
        public string GetName(IList<Person> person)
        {
            //return $"{person.Name} {person.Address} ";
            string names = "";
            foreach (var p in person)
            {
                names += $"{p.Name} {p.Address}\n";
            }
            return names;
        }
        public double Average(IList<Person> person)
        {
            int Avg = 0;
            foreach (var i in person)
            {
                Avg += i.Age;

            }
            return (double)Avg / person.Count;
        }
        public int Max(IList<Person> person)
        {
            int maxAge = 0;
            foreach (var p in person)
            {
                if (p.Age > maxAge)
                {
                    maxAge = p.Age;
                }
            }
            return maxAge;

        }
    }

    public class Program
    {
        //public int num { get; set; }
        static void Main(String[] args)
        {
            IList<Person> p = new List<Person>();
            p.Add(new Person("Aarya", "A2101", 69));
            p.Add(new Person("Aarya", "A2101", 69));
            p.Add(new Person("Aarya", "A2101", 69));
            p.Add(new Person("Aarya", "A2101", 69));

            PersonImplementation p1 = new PersonImplementation();
            Console.WriteLine(p1.GetName(p));
            Console.WriteLine(p1.Average(p));
            Console.WriteLine(p1.Max(p));

        }
    }
}
