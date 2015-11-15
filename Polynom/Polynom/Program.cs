using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Polynom
{
    class Monomial
    {
        private int _value;
        private int _degree;

        public Monomial(int value, int degree)
        {
            this._value = value;
            if (degree >= 0)
                this._degree = degree;
            else
                this._degree = 0;
        }

        public int Value
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
        protected const int MAX_SIZE = 200;
        protected double[] _nodes = new double[MAX_SIZE];

        public Polynom(double[] array)
        {
            int i = 0;
            while ((i < array.Length) && (i < MAX_SIZE))
            {
                this.Nodes[i] = array[i];
                i += 1;
            }
        }

        public Polynom()
        {
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
            for (int i = 0; i < this.Nodes.Length; i++)
            {
                value += this.Nodes[i] * Math.Pow(x, i);
            }

            return value;
        }

        public static Polynom operator +(Polynom X, Polynom Y)
        {
            double[] Z = new double[MAX_SIZE];

            int i = 0;
            while ((i < X.Nodes.Length) && (i < Y.Nodes.Length))
            {
                Z[i] = X.Nodes[i] + Y.Nodes[i];
                i += 1;
            }

            return new Polynom(Z);
        }

        public static Polynom operator +(Polynom X, Monomial Num)
        {
            double[] Z = new double[MAX_SIZE];

            for (int i = 0; i < X.Nodes.Length; i++)
                Z[i] = X.Nodes[i];

            Z[Num.Degree] += Num.Value;

            return new Polynom(Z);
        }

        public static Polynom operator +(Polynom X, double num)
        {
            double[] Z = X.Nodes;
            Z[0] += num;

            return new Polynom(Z);
        }

        public static Polynom operator -(Polynom X, Polynom Y)
        {
            double[] Z = new double[MAX_SIZE];

            int i = 0;
            while ((i < X.Nodes.Length) && (i < Y.Nodes.Length))
            {
                Z[i] = X.Nodes[i] - Y.Nodes[i];
                i += 1;
            }

            return new Polynom(Z);
        }

        public static Polynom operator -(Polynom X, Monomial Num)
        {
            double[] Z = new double[MAX_SIZE];

            for (int i = 0; i < X.Nodes.Length; i++)
                Z[i] = X.Nodes[i];

            Z[Num.Degree] -= Num.Value;

            return new Polynom(Z);
        }

        public static Polynom operator -(Polynom X, double num)
        {
            double[] Z = X.Nodes;
            Z[0] -= num;

            return new Polynom(Z);
        }

        public static Polynom operator *(Polynom X, Polynom Y)
        {
            double[] Z = new double[MAX_SIZE];

            for (int i = 0; i < X.Nodes.Length; i++)
                for (int j = 0; j < Y.Nodes.Length; j++)
                {
                    if (X.Nodes[i] != 0 && Y.Nodes[j] != 0 && (i + j) < MAX_SIZE)
                        Z[i + j] += X.Nodes[i] * Y.Nodes[j];
                }
            
            return new Polynom(Z);
        }

        public static Polynom operator *(Polynom X, Monomial Num)
        {
            double[] Z = new double[MAX_SIZE];

            if (Num.Value != 0)
            {
                for (int i = 0; i < X.Nodes.Length; i++)
                {
                    if (X.Nodes[i] != 0)
                        Z[i + Num.Degree] = X.Nodes[i] * Num.Value;
                }
            }

            return new Polynom(Z);
        }

        public static Polynom operator *(Polynom X, double num)
        {
            double[] Z = X.Nodes;
            Z[0] *= num;

            return new Polynom(Z);
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

            while (i < this.Nodes.Length)
            {
                if (this.Nodes[i] != 0)
                    Console.Write(" + " + Math.Round(this.Nodes[i], 2) + " * x^" + i);
                i += 1;
            }

            Console.WriteLine();
        }

        //protected static double[] GetNodes(double[] arr)
        //{
        //    int length = arr.Length;

        //    for (int i = arr.Length - 1; i >= 0; i--)
        //    {
        //        if (arr[i] != 0)
        //        {
        //            length = i + 1;
        //            break;
        //        }
        //    }

        //    double[] arrAnswer = new double[length];
        //    Array.Copy(arr, 0, arrAnswer, 0, length);

        //    return arrAnswer;
        //}
    }

    class LagrangePolynom : Polynom
    {
        public LagrangePolynom() : base() { }

        public LagrangePolynom(double[] array)
            : base(array)
        {
            Polynom x = new Polynom(new double[] { 0, 1 });
            Polynom L = new Polynom();

            for (int i = 0; i < array.Length; i++)
            {
                Polynom li = new Polynom(new double[] { 1 });
                for (int j = 0; j < array.Length; j++)
                    if (j != i)
                    {
                        li *= (x - array[j]) * (1 / (array[i] - array[j]));
                    }

                L += li * f(array[i]);
            }

            for (int i = 0; i < L.Nodes.Length; i++)
                this._nodes[i] = L.Nodes[i];
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
            double[] a1 = new double[] { -1.5, -0.75, 0, 0.75, 1.5 };
            //double[] a2 = new double[] { 4, 14, 27 };
            //Monomial mono = new Monomial(5, 1);
            LagrangePolynom lp1 = new LagrangePolynom(a1);
            //Polynom p2 = new Polynom(a2);
            lp1.Print();
            Console.WriteLine(lp1.Calc(2));

            Console.ReadLine();
        }
    }
}
