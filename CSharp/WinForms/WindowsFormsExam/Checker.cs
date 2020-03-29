using System;
using System.Drawing;

namespace WindowsFormsExam
{
    class Checker
    {
        public enum CType { Empty, Easy, King}
        public Color _Color { get; set; }
        public Point _Point { get; set; }
        public bool IsEmpty { get; set; }
        public CType CheckerType { get; set; }
        public Checker(CType t, Color? clr = null, Point? pnt = null, bool isEmpty = false)
        {
            _Color = clr.GetValueOrDefault();
            _Point = pnt.GetValueOrDefault();
            this.IsEmpty = isEmpty;
            this.CheckerType = t;
        }
        public override string ToString() => $"{_Color},{_Point},{IsEmpty} ({(Enum.GetName(typeof(CType), CheckerType))})";
    }
}