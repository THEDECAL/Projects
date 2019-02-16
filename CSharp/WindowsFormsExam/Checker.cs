using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsExam
{
    class Checker
    {
        public enum type { King, Easy }
        public Color Color { get; set; }
        public Point Position { get; set; }
        public bool IsEmpty { get; set; } = false;
        public type Type { get; set; } = type.Easy;
        public Checker(Point position)
        {
            this.Position = position;
        }
    }

}
