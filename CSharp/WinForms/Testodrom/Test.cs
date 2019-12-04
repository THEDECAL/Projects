using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testodrom
{
    class Test
    {
        [Required(ErrorMessage = "Название теста не установлено")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Название теста должно быть больше 3 символов и не больше 100")]
        public string Name { get; set; }
        public List<Question> Questions { get; set; } = new List<Question>();
        /// <summary>
        /// Функция проверки теста на валидность
        /// </summary>
        /// <returns>Возвращает строку с текстом ошибок, если есть ошибки, иначе null</returns>
        public string CheckToValid()
        {
            var sb = new StringBuilder();
            var results = new List<ValidationResult>();
            var context = new ValidationContext(this);

            if (!Validator.TryValidateObject(this, context, results, true))
                results.ForEach(e => sb.Append(e.ErrorMessage + '\n'));

            if (results.Count == 0)
            {
                foreach (var item in Questions)
                {
                    sb.Append(item.CheckToValid());
                    if (sb.Length != 0) break;
                }
            }

            return (sb.Length == 0) ? null : sb.ToString();
        }
        /// <summary>
        /// Метод клонирования теста
        /// </summary>
        /// <param name="o">Принимает тест для клонирования</param>
        /// <param name="withoutCorrectAnswers">true - клонировать без корректных вопросов, false(По умолчанию) - клонировать полностью</param>
        /// <returns>Возвращает склонированный тест</returns>
        static public Test Clone(Test o, bool withoutCorrectAnswers = false)
        {

            Test @new = new Test() { Name = o.Name };
            foreach (var item in o.Questions)
            {
                @new.Questions.Add(new Question() { Name = item.Name });
                foreach (var item2 in item.VariantsAnswers)
                {
                    @new.Questions[@new.Questions.Count - 1].VariantsAnswers.Add(new Variant()
                    {
                        Name = item2.Name,
                        isCorrectAnswer = (!withoutCorrectAnswers) ? item2.isCorrectAnswer : false
                    });
                }
            }

            return @new;
        }
        public override string ToString() => Name;
    }
    class Question
    {
        [Required(ErrorMessage = "Вопрос не установлен")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Вопрос должен быть больше 3 символов и не больше 100")]
        public string Name { get; set; }
        public List<Variant> VariantsAnswers { get; set; } = new List<Variant>();
        /// <summary>
        /// Метод проверки вопроса на валидность
        /// </summary>
        /// <returns>Возвращает строку с текстом ошибок, если есть ошибки, иначе null</returns>
        public string CheckToValid()
        {
            var sb = new StringBuilder();
            var results = new List<ValidationResult>();
            var context = new ValidationContext(this);

            if (!Validator.TryValidateObject(this, context, results, true))
                results.ForEach(e => sb.Append(e.ErrorMessage + '\n'));

            if (results.Count == 0)
            {
                foreach (var item in VariantsAnswers)
                {
                    sb.Append(item.CheckToValid());
                    if (sb.Length != 0) break;
                }
            }
            //Обнаружение хотябы одного правильного ответа

            if (!CheckCorrectAnswers()) sb.Append("Нет ни одного ответа");

            return (sb.Length == 0) ? null : sb.ToString();
        }
        /// <summary>
        /// Метод проверки вопроса на наличие ответа
        /// </summary>
        /// <returns>Возвращает true, если есть хотябы один ответ, иначе false</returns>
        public bool CheckCorrectAnswers() => (VariantsAnswers.Any(e => e.isCorrectAnswer));
        public override string ToString() => Name;
    }
    class Variant
    {
        [Required(ErrorMessage = "Вариант ответа не установлен")]
        [StringLength(45, MinimumLength = 2, ErrorMessage = "Вариант ответа должен быть больше 3 символов и не больше 45")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Ответ не установлен")]
        public bool isCorrectAnswer { get; set; }
        /// <summary>
        /// Метод проверки варианта ответа на валидность
        /// </summary>
        /// <returns>Возвращает строку с текстом ошибок, если есть ошибки, иначе null</returns>
        public string CheckToValid()
        {
            var sb = new StringBuilder();
            var results = new List<ValidationResult>();
            var context = new ValidationContext(this);

            if (!Validator.TryValidateObject(this, context, results, true))
                results.ForEach(e => sb.Append(e.ErrorMessage + '\n'));

            return (sb.Length == 0) ? null : sb.ToString();
        }
        public override string ToString() => $"{Name} {isCorrectAnswer.ToString()}";
    }
}
