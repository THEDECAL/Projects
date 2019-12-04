using System;
using static System.Console;

namespace task8
{
    enum Subjects { Programming, Administration, Desgin };
    class Student
    {
        string fname;
        string sname;
        string pname;
        string group;
        uint age;
        uint[][] marks = new uint[3][]
        {
            new uint[0],
            new uint[0],
            new uint[0]
        };
        public Student()
        {
            fname = sname = pname = group = "Не задано.";
        }
        public Student(string fn, string sn, string pn, string gr, uint ag)
        {
            fname = fn;
            sname = sn;
            pname = pn;
            group = gr;
            age = ag;
        }
        public void show() //Вывод информации о студенте
        {
            WriteLine("ФИО: " + sname + " " + fname + " " + pname);
            WriteLine("Группа: " + group);
            WriteLine($"Возраст: {(age == 0 ? "Не задано":age.ToString())}");
            WriteLine("Оценки: ");
            //Выполняю таким способом, чтобы показать работу функции get_marks() и avg()
            if (get_marks(Subjects.Programming) != null)
            {
                Write("Программирование: ");
                foreach (var item in get_marks(Subjects.Programming)) Write(item + " ");
                WriteLine();
                Write("Средняя оценка: " + avg(Subjects.Programming));
                WriteLine();
            }
            if (get_marks(Subjects.Administration) != null)
            {
                Write("Администрирование: ");
                foreach (var item in get_marks(Subjects.Administration)) Write(item + " ");
                WriteLine();
                Write("Средняя оценка: " + avg(Subjects.Administration));
                WriteLine();
            }
            if (get_marks(Subjects.Desgin) != null)
            {
                Write("Дизайн: ");
                foreach (var item in get_marks(Subjects.Desgin)) Write(item + " ");
                WriteLine();
                Write("Средняя оценка: " + avg(Subjects.Desgin));
                WriteLine();
            }
            WriteLine("\n");
        }
        public decimal avg(Subjects subj) //Выдача средней оценки по предмету
        {
            if (marks[(int)subj].Length != 0)
            {
                uint sum = 0;
                foreach (var item in marks[(int)subj]) sum += item;

                return Math.Round((decimal)sum / (decimal)marks[(int)subj].Length,1);
            }

            return 0.0m;
        }
        public void add_mark(Subjects subj, uint mark) //Добавление новой оценки по предмету
        {
            if (mark > 0 && mark < 13)
            {
                Array.Resize(ref marks[(int)subj], marks[(int)subj].Length + 1);
                marks[(int)subj][marks[(int)subj].Length - 1] = mark;
            }
                
        }
        public uint[] get_marks(Subjects subj) //Выдача массива оценок по предмету
        {
            if(marks[(int)subj].Length != 0)
                return marks[(int)subj];

            return null;
        }
    }
    class Program
    {
        static void Main()
        {
            Random rnum = new Random();
            int rmin = 1, rmax = 12;

            //Инициализация массива студентов
            Student[] students = 
            {
                new Student(),
                new Student("Игорь","Игоревиченко","Игоревич","12П-12",20),
                new Student("Александр","Александренко","Александрович","12П-12",18),
                new Student("Пётр","Петренко","Петрович","11К-10",17),
                new Student("Николай","Николаенко","Николаевич","11К-13",19)
            };

            //Генерация оценок
            foreach (var item in students)
            {
                int amMarks = rnum.Next(rmin, rmax);
                for (int i = 0; i < amMarks; i++)
                {
                    item.add_mark((Subjects)rnum.Next(0,3), (uint)rnum.Next(rmin,rmax));
                }
            }

            //Отображение каждого студента
            foreach (var item in students) item.show();
        }
    }
}
