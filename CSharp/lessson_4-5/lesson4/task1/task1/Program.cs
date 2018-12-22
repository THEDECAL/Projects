using System;
using System.Text;

namespace task1
{
    abstract class GeometricFigure
    {
        protected double[] segments; //Отрезок, сторона
        public GeometricFigure(params double[] segments)
        {
            this.segments = new double[segments.Length];
            for (int i = 0; i < segments.Length; i++)
                segments[i] = this.segments[i];
        }
        public abstract double Area(); //Обязательный метод площади
    }
    class Triangle : GeometricFigure
    {
        public Triangle(double a, double b, double c) : base(a, b, c) { }
        override public double Area()
        {
            return 1 / 2 * (segments[0] + segments[1] + segments[2]);
        }
    }
    class Square : GeometricFigure
    {
        public Square(double a) : base(a) { }
        override public double Area()
        {
            return segments[0] * 2;
        }
    }
    class Rhombus : Square
    {
        public Rhombus(double a) : base(a) { }
    }
    class Rectangle : GeometricFigure
    {
        public Rectangle(double a, double b) : base(a, b) { }
        public override double Area()
        {
            return segments[0] * segments[1];
        }
    }
    class Parallelepiped : GeometricFigure
    {
        public Parallelepiped(double h, double w, double l) : base(h, w, l) { }
        public override double Area()
        {
            return segments[0] * segments[1] * segments[2];
        }
    }
    class Trapezium : GeometricFigure
    {
        public Trapezium(double a, double b, double h) : base(a, b, h) { }
        public override double Area()
        {
            return ((segments[0] + segments[1]) * segments[2]) / 2;
        }
    }
    class Circle : GeometricFigure
    {
        public Circle(double r):base(r) { }
        public override double Area()
        {
            return Math.PI * (segments[0] * segments[0]);
        }
    }
    class Ellipse : GeometricFigure
    {
        public Ellipse(double ra, double rb):base(ra,rb) { }
        public override double Area()
        {
            return segments[0] * segments[1] * Math.PI;
        }
    }
    class CompoundFigure
    {
        GeometricFigure[] figures;
        public CompoundFigure(params GeometricFigure[] figures)
        {
            this.figures = new GeometricFigure[figures.Length];
            for (int i = 0; i < figures.Length; i++)
                figures[i] = this.figures[i];
        }
        public double Area()
        {
            double sum = 0;
            foreach (var item in figures)
                sum += item.Area();

            return sum;
        }
    }
}
