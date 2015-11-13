using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortStudents
{
    class Student
    {
        private string _name;
        private string _surname;

        private int _mark1 = 0;
        private int _mark2 = 0;
        private int _mark3 = 0;
        private int _mark4 = 0;
        private double _average = 0;

        public Student(string name, string surname)
        {
            if (name.Length > 1)
            {
                this._name = name;
            }
            else
            {
                this._name = "Student";
                Console.WriteLine("'Name' is too short. 'Name' is 'Student'");
            }
            if (surname.Length > 1)
            {
                this._surname = surname;
            }
            else
            {
                this._surname = "Molodec";
                Console.WriteLine("'Sirname' is too short. 'Sirname' is 'Molodec'");
            }
        }

        public void fillMarks(int mark1, int mark2, int mark3, int mark4)
        {
            this.doMark1(mark1);
            this.doMark2(mark2);
            this.doMark3(mark3);
            this.doMark4(mark4);
        }

        public void calcAverage()
        {
            this._average = (this._mark1 + this._mark2 + this._mark3 + this._mark4) / 4;
        }

        public string Name
        {
            get
            {
                return this._name;
            }
        }

        public string Surname
        {
            get
            {
                return this._surname;
            }
        }

        public double Average
        {
            get
            {
                return this._average;
            }
        }

        public void print()
        {
            Console.WriteLine("Name: " + this.Name);
            Console.WriteLine("Surname: " + this.Surname);
            Console.WriteLine("1 mark: " + this._mark1);
            Console.WriteLine("2 mark: " + this._mark2);
            Console.WriteLine("3 mark: " + this._mark3);
            Console.WriteLine("4 mark: " + this._mark4);
            Console.WriteLine("Average value: " + Math.Round(this.Average, 4));
        }

        public void doMark1(int mark1)
        {
            if (mark1 > 0 && mark1 <= 100)
            {
                this._mark1 = mark1;
            }
            else
            {
                Console.WriteLine("Incorrect value.");
            }
        }

        public void doMark2(int mark2)
        {
            if (mark2 > 0 && mark2 <= 100)
            {
                this._mark2 = mark2;
            }
            else
            {
                Console.WriteLine("Incorrect value.");
            }
        }

        public void doMark3(int mark3)
        {
            if (mark3 > 0 && mark3 <= 100)
            {
                this._mark3 = mark3;
            }
            else
            {
                Console.WriteLine("Incorrect value.");
            }
        }

        public void doMark4(int mark4)
        {
            if (mark4 > 0 && mark4 <= 100)
            {
                this._mark4 = mark4;
            }
            else
            {
                Console.WriteLine("Incorrect value.");
            }
        }
    }

    class ArrayList
    {
        private const int MAX_SIZE = 1000;
        private int _size;
        Student[] list = new Student[MAX_SIZE];

        public ArrayList()
        {
            _size = -1;
        }

        public int Size
        {
            get
            {
                return this._size;
            }
        }

        public void addStudent(Student student)
        {
            if (this.Size < MAX_SIZE - 1)
            {
                this._size += 1;
                this.list[this.Size] = student;
            }
            else
            {
                Console.WriteLine("List is full");
            }
        }

        public void Swap(Student a, Student b)
        {
            Student tmp;
            tmp = a;
            a = b;
            b = tmp;
        }

        public void sortStudents()
        {
            for (int i = 0; i < this.Size - 1; i++)
            {
                for (int j = 0; j <= i - 1; j++)
                {
                    if (this.list[j].Average > this.list[j + 1].Average)
                    {
                        Student highValue = this.list[j];
                        this.list[j] = this.list[j + 1];
                        this.list[j + 1] = highValue;

                    }
                }
            }
        }

        public static ArrayList sortSelection(ArrayList list)
        {
            for (int i = 0; i < list.Size - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < list.Size; j++)
                {
                    if (list.list[j].Average < list.list[min].Average)
                    {
                        min = j;
                    }
                }
                Student temp = list.list[i];
                list.list[i] = list.list[min];
                list.list[min] = temp;
            }
            return list;
        }

        public void delStudent(string name)
        {
            for (int i = 0; i < this.Size; i++)
            {
                if (this.list[i].Name == name)
                {
                    for (int j = i; j < this.Size; i++)
                    {
                        this.list[j] = this.list[j + 1];
                    }
                    this._size -= 1;
                }
                else
                {
                    Console.WriteLine("Student isn't found");
                }
            }
        }

        public void print()
        {
            for (int i = 0; i <= this.Size; i++)
                Console.WriteLine(this.list[i].Name);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Student Vasya = new Student("Vasya", "Galeev");
            Student Marsel = new Student("Marsel", "Sidikov");
            Student Ranis = new Student("Ranis", "Nigmatullin");

            Vasya.fillMarks(99, 99, 99, 99);
            Vasya.calcAverage();
            Marsel.fillMarks(1, 2, 4, 7);
            Marsel.calcAverage();
            Marsel.print();
            Ranis.fillMarks(20, 50, 70, 50);
            Ranis.calcAverage();

            ArrayList list = new ArrayList();
            //ArrayList sortedList = new ArrayList();
            list.addStudent(Vasya);
            list.addStudent(Marsel);
            list.addStudent(Ranis);

            //sortedList = ArrayList.sortSelection(list);
            list.Swap(Vasya, Ranis);
            list.print();
            
            Console.ReadLine();
        }
    }
}