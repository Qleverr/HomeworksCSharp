using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Polynom
{
    class Monomial
    {
        private double _value;
        private int _degree;

        public Monomial(double value, int degree)
        {
            this._value = value;
            if (degree >= 0)
                this._degree = degree;
            else
                this._degree = 0;
        }

        public double Value
        {
            get
            {
                return this._value;
            }
        }

        public int Degree
        {
            get
            {
                return this._degree;
            }
        }
    }

    class Polynom
    {
        protected double[] _nodes;
        protected int _n;

        public Polynom(double[] array, int n)
        {
            this._nodes = array;
            this._n = n;
        }

        public Polynom(double[] array) : this(array, array.Length)
        {
        }

        public Polynom() : this(new double[] {}, 0)
        {
        }

        public int n
        {
            get
            {
                return this._n;
            }
        }

        public double[] Nodes
        {
            get
            {
                return this._nodes;
            }
        }

        public double Calc(double x)
        {
            double value = 0;
            for (int i = 0; i < this.n; i++)
            {
                value += this.Nodes[i] * Math.Pow(x, i);
            }

            return value;
        }

        public static Polynom operator +(Polynom X, Polynom Y)
        {
            double[] Z = new double[Math.Max(X.n, Y.n)];

            for (int i = 0; i < Math.Min(X.n, Y.n); i++)
                Z[i] = X.Nodes[i] + Y.Nodes[i];

            for (int i = Math.Min(X.n, Y.n); i < Math.Max(X.n, Y.n); i++)
                Z[i] = (X.n > Y.n) ? X.Nodes[i] : Y.Nodes[i];


            return new Polynom(Z);

        }

        public static Polynom operator +(Polynom X, Monomial Num)
        {
            double[] Z = new double[X.n];

            for (int i = 0; i < X.n; i++)
                Z[i] = X.Nodes[i];
            Z[Num.Degree] += Num.Value;

            return new Polynom(Z);
        }

        public static Polynom operator +(Polynom X, double num)
        {
            double[] Z = new double[X.n];

            for (int i = 0; i < X.n; i++)
                Z[i] = X.Nodes[i];
            Z[0] += num;

            return new Polynom(Z);
        }

        public static Polynom operator -(Polynom X, Polynom Y)
        {
            double[] Z = new double[Math.Max(X.n, Y.n)];

            for (int i = 0; i < Math.Min(X.n, Y.n); i++)
                Z[i] = X.Nodes[i] - Y.Nodes[i];

            for (int i = Math.Min(X.n, Y.n); i < Math.Max(X.n, Y.n); i++)
                Z[i] = (X.n > Y.n) ? X.Nodes[i] : Y.Nodes[i];


            return new Polynom(Z);
        }

        public static Polynom operator -(Polynom X, Monomial Num)
        {
            double[] Z = new double[X.n];

            for (int i = 0; i < X.n; i++)
                Z[i] = X.Nodes[i];
            Z[Num.Degree] -= Num.Value;

            return new Polynom(Z);
        }

        public static Polynom operator -(Polynom X, double num)
        {
            return X + (-num);
        }

        public static Polynom operator *(Polynom X, Polynom Y)
        {
            double[] Z = new double[2 * Math.Max(X.n, Y.n)];

            for (int i = 0; i < X.Nodes.Length; i++)
                for (int j = 0; j < Y.Nodes.Length; j++)
                {
                    if (X.Nodes[i] != 0 && Y.Nodes[j] != 0)
                        Z[i + j] += X.Nodes[i] * Y.Nodes[j];
                }
            
            return new Polynom(Z);
        }

        public static Polynom operator *(Polynom X, Monomial Num)
        {
            double[] Z = new double[Math.Max(X.n, Num.Degree)];

            for (int i = 0; i < X.n; i++)
                Z[i] = X.Nodes[i];
            Z[Num.Degree] *= Num.Value;

            return new Polynom(Z);
        }

        public static Polynom operator *(Polynom X, double num)
        {
            double[] Z = new double[X.n];

            for (int i = 0; i < X.n; i++)
                Z[i] += X.Nodes[i] * num;

            return new Polynom(Z);
        }

        public static Polynom operator /(Polynom X, double num)
        {
            return X * (1 / num);
        }

        public void Print()
        {
            int i = 0;
            while (this.Nodes[i] == 0)
                i += 1;

            Console.Write(Math.Round(this.Nodes[i], 2));
            if (i > 0)
                Console.Write(" * x^" + i);

            i += 1;

            while (i < this.n)
            {
                if (this.Nodes[i] != 0)
                    Console.Write(" + " + Math.Round(this.Nodes[i], 2) + " * x^" + i);
                i += 1;
            }

            Console.WriteLine();
        }
    }

    class LagrangePolynom : Polynom
    {
        public LagrangePolynom() : base() { }

        public LagrangePolynom(double[] array) : base(array)
        {
            Polynom x = new Polynom(new double[] { 0, 1 });
            Polynom L = new Polynom();

            for (int i = 0; i < array.Length; i++)
            {
                Polynom li = new Polynom(new double[] { 1 });
                for (int j = 0; j < array.Length; j++)
                    if (j != i)
                    {
                        li *= (x - array[j]) / (array[i] - array[j]);
                    }

                L += li * f(array[i]);
            }

            this._nodes = L.Nodes;
            this._n = L.n;
        }

        private double f(double x)
        {
            return Math.Tan(x);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            double[] a1 = new double[] { -2, 1, 4, -1 };
            double[] a2 = new double[] { 3, 0, 27 };
            Monomial mono = new Monomial(5, 1);
            Polynom p1 = new Polynom(a1);
            Polynom p2 = new Polynom(a2);

            p1.Print();
            p2.Print();
            Console.WriteLine();

            (p1 + p2).Print();
            (p1 - p2).Print();
            (p1 * p2).Print();
            Console.WriteLine();

            (p1 + mono).Print();
            (p1 - mono).Print();
            (p1 * mono).Print();
            Console.WriteLine();

            (p1 + 3).Print();
            (p1 - 3).Print();
            (p1 * 3).Print();
            Console.WriteLine();

            LagrangePolynom lp1 = new LagrangePolynom(new double[] {-1.5, -0.75, 0, 0.75, 1.5});
            lp1.Print();
            Console.WriteLine(lp1.Calc(2));

            Console.ReadLine();
        }
    }
}
