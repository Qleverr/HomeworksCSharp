using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shape
{
    abstract class Shape
    {
        abstract public double calcArea();
    }

    class Triangle : Shape
    {
        private double _a;
        private double _b;
        private double _c;

        public Triangle(double a, double b, double c)
        {
            if (a > 0)
                this._a = a;
            else
            {
                this._a = 1;
                Console.WriteLine("Incorrect value. A = 1");
            }

            if (b > 0)
                this._b = b;
            else
            {
                this._b = 1;
                Console.WriteLine("Incorrect value. B = 1");
            }

            if (c > 0)
                this._c = c;
            else
            {
                this._c = 1;
                Console.WriteLine("Incorrect value. C = 1");
            }
        }

        public override double calcArea()
        {
            double p = (this._a + this._b + this._c) / 2;
            return Math.Sqrt(p * (p - this._a) * (p - this._b) * (p - this._c));
        }

        public void print()
        {
            Console.WriteLine("A = " + this._a);
            Console.WriteLine("B = " + this._b);
            Console.WriteLine("C = " + this._c);
        }
    }

    class Rectangle : Shape
    {
        private double _a;
        private double _b;

        public Rectangle(double a, double b)
        {
            if (a > 0)
                this._a = a;
            else
            {
                this._a = 1;
                Console.WriteLine("Incorrect value. A = 1");
            }

            if (b > 0)
                this._b = b;
            else
            {
                this._b = 1;
                Console.WriteLine("Incorrect value. B = 1");
            }
        }

        public override double calcArea()
        {
            return this._a * this._b;
        }
    }

    class Circle : Shape
    {
        private double _r;

        public Circle(double r)
        {
            if (r > 0)
                this._r = r;
            else
            {
                this._r = 1;
                Console.WriteLine("Incorrect value. R = 1");
            }
        }

        public override double calcArea()
        {
            return Math.PI * Math.Pow(this._r, 2);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Shape[] Array = new Shape[100];
            Array[0] = new Triangle(1, 1, Math.Sqrt(2));
            Array[1] = new Rectangle(5, 6.5);
            Array[2] = new Circle(8);

            for (int i = 0; Array[i] != null; i++)
                Console.WriteLine(Array[i].calcArea());

            Console.ReadLine();
        }
    }
}
