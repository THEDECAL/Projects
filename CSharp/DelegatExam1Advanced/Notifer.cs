using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatExam1Advanced
{
    enum mc {
        ERR_AM_DISP,
        ERR_READ,
        ERR_WRITE,
        CATH_ERR_AIRDESTR,
        CATH_ERR_UNUS,
        PRESS_ANY_KEY,
        SUCC_LAND
    };
    class Notifer
    {
        public static Notifer notifer { get; private set; } = new Notifer();
        public string[] Msg { get; private set; }
        Notifer()
        {
            Msg = new string[]
            {
                "Ошибка. Диспетчеров должно быть минимум двое",
                "Ошибка. Ошибка при чтении файла",
                "Ошибка. Ошибка при записи файла",
                "Исключение. Пилот непригоден к полётам",
                "Исключение. Самолёт разбился",
                "Нажмите любую клавишу для продолжения.",
                "Вы успешно приземлились."
            };
        }
        public string this[mc index]
        {
            get { return Msg[(int)index]; }
        }
    }
}
