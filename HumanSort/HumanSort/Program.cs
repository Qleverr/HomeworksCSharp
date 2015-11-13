using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HumanSort
{
    class Human
    {
        private const int MAX_AGE = 200;
        private string _name;
        private int _age;

        public Human(string name, int age)
        {
            if (name.Length > 0)
                this._name = name;
            else
            {
                this._name = "Human";
                Console.WriteLine("Incorrect name. Name = 'Human'");
            }

            if (age < MAX_AGE && age > -1)
                this._age = age;
            else
            {
                this._age = 0;
                Console.WriteLine(this._name + "'s age is out of range. Age = 0");
            }
        }

        public string Name
        {
            get
            {
                return this._name;
            }
        }

        public int Age
        {
            get
            {
                return this._age;
            }
        }

        public static LinkedList<Human>[] SortByAge(LinkedList<Human> humans)
        {
            LinkedList<Human>[] sorted = new LinkedList<Human>[MAX_AGE];

            for (int i = 0; i < sorted.Length; i++)
            {
                sorted[i] = new LinkedList<Human>();
            }

            foreach (Human human in humans)
            {
                sorted[human.Age].AddLast(human);
            }
            return sorted;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<Human> humans = new LinkedList<Human>();

            humans.AddLast(new Human("Ranis", 19));
            humans.AddLast(new Human("Nina", 10));
            humans.AddLast(new Human("Marsel", 22));
            humans.AddLast(new Human("Vasya", 19));
            humans.AddLast(new Human("Kolya", 54));
            humans.AddLast(new Human("Nuriza", 123));
            humans.AddLast(new Human("Pavel", 200));

            LinkedList<Human>[] sortedHumans = Human.SortByAge(humans);

            foreach (LinkedList<Human> humansSameAge in sortedHumans)
                foreach (Human human in humansSameAge)
                {
                    Console.WriteLine("Name: " + human.Name);
                    Console.WriteLine(" Age: " + human.Age);
                    Console.WriteLine();
                }
        }
    }
}
