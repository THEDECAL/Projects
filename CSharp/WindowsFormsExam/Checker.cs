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
        public enum CType { King, Easy }
        public Color Color { get; set; }
        public Point Position { get; set; }
        public bool IsEmpty { get; set; }
        public CType Type { get; set; }
        private Checker()
        {
            this.Color = System.Drawing.Color.Empty;
            this.Position = Point.Empty;
            this.IsEmpty = false;
            this.Type = CType.Easy;
        }
        public Checker(Point position) : this() { this.Position = (position.X > 0 && position.Y > 0) ? position : Point.Empty; }
        static public Checker GetEmptyChecker() => new Checker() {Color = Color.White};
        public override string ToString() => $"{Color.ToString()},{Position.ToString()},{IsEmpty.ToString()} ({(Type == CType.King ? "King" : "Easy")})";
    }
}
