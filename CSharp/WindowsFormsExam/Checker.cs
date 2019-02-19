using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsExam
{
    //class Button : Control
    //{
    //    static public implicit operator Checker(Button btn) => (btn.Tag is Checker) ? btn.Tag as Checker : null;
    //    //static public explicit operator System.Windows.Forms.Button(Checker chk)
    //    //{
    //    //    (chk.Tag is Checker) ? btn.Tag as Checker : null;
    //    //}
    //}
    public sealed class Checker// : ICloneable
    {
        public enum CType { Empty = 0, WhiteEasy, BlackEasy, WhiteKing, BlackKing }
        static Checker[] types;
        public Color _Color { get; set; }
        public Point _Point { get; set; }
        public bool IsEmpty { get; set; }
        public CType CheckerType {get; set; }
        public Checker(CType t, Color? clr = null, Point? pnt = null, bool isEmpty = false)
        {
            _Color = clr.GetValueOrDefault(); //(clr.GetValueOrDefault.IsEmpty) ? Color.Empty : Color.FromName(clr.Value.Name);
            _Point = pnt.GetValueOrDefault(); // (pnt.Value.IsEmpty) ? Point.Empty : new Point(pnt.Value.X, pnt.Value.Y);
            this.IsEmpty = isEmpty;
            this.CheckerType = t;
        }
        private static Checker[] InitArrayTypes()
        {
            return types = new Checker[]
            {
                new Checker(CType.Empty, Color.Empty, Point.Empty, true),
                new Checker(CType.BlackKing, Color.Black, Point.Empty, false),
                new Checker(CType.BlackEasy, Color.Black, Point.Empty, false),
                new Checker(CType.WhiteKing, Color.White, Point.Empty, false),
                new Checker(CType.WhiteEasy, Color.White, Point.Empty, false)
            };
        }
        //public static implicit operator Checker(CType t) => types[(int)t];
        public static explicit operator CType(Checker chk) => chk.CheckerType;
        //public Checker this[CType t]
        //{
        //    get { return types[(int)t].Clone() as Checker; }
        //    private set { types = InitArrayTypes(); }
        //}
        //public object Clone() => this.MemberwiseClone();
        public override string ToString() => $"{_Color.ToString()},{_Point.ToString()},{IsEmpty.ToString()} ({(Enum.GetName(typeof(CType), CheckerType))})";
    }
}