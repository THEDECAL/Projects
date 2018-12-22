using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatExam1Advanced
{
    class SingletonTemplate<T> where T : new()
    {
        static private T reference = default(T);
        static public T Reference
        {
            get { return reference = (reference != null) ? reference : new T(); }
            set { reference = value; }
        }
    }
}
