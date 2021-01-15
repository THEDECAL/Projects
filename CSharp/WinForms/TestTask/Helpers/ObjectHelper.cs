using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace TestTask.Helpers
{
    public static class ObjectHelper
    {
        static public string GetCurrentMethod(this StackTrace obj) => obj.GetFrame(1).GetMethod().Name;

        /// <summary>
        /// Дублирование объекта
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="from"></param>
        /// <param name="excl"></param>
        /// <returns></returns>
        static public T Copy<T>( this T from, params string[] excl) where T : class
        {
            var copy = Activator.CreateInstance<T>();
            from.Clone(copy, excl);
            return copy;
        }

        /// <summary>
        /// Клонирование одного объекта в другой
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="excl"></param>
        static public void Clone<T>(this T from,T to, params string[] excl) where T : class
        {
            var list = from.GetProps(excl).ToList();
            list.ForEach((p) =>
            {
                p.SetValue(to, p.GetValue(from));
            });
        }

        /// <summary>
        /// Сравнение свойств двух объектов
        /// </summary>
        /// <typeparam name="T">Тип сравниваемых объектов</typeparam>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <param name="excl">Свойства исключаемые из сравнения</param>
        /// <returns>Возвращает True, если свойства объектов равны</returns>
        static public bool Compare<T>(this T o1, T o2, params string[] excl) where T : class
            => o1.GetProps(excl).All((p) => p.GetValue(o1).StrChk().Equals(p.GetValue(o2).StrChk()));

        /// <summary>
        /// Получить свойства объекта
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="excl">Свойства исключающиеся из поиска</param>
        /// <returns></returns>
        static public IEnumerable<PropertyInfo> GetProps<T>(this T obj, params string[] excl)
        {
            var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            return ((excl == null)
                    ? props
                    : props.Where((p) => excl.Any((ep) => !ep.StrChk().Equals(p.Name.StrChk()))))
                .AsEnumerable();
        }

        /// <summary>
        /// Проверка строки на пустоту
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        static public string StrChk<T>(this T obj) where T : class
            => (string.IsNullOrWhiteSpace(obj.ToString()))
                ? string.Empty : obj.ToString().ToLower().Trim();
    }
}
