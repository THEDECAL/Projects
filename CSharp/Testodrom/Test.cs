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
        public string CheckToValid()
        {
            var sb = new StringBuilder();
            var results = new List<ValidationResult>();
            var context = new ValidationContext(this);

            if (!Validator.TryValidateObject(this, context, results, true)) results.ForEach(e => sb.Append(e.ErrorMessage + '\n'));
            Questions.ForEach(e => sb.Append(e.CheckToValid()));

            return (sb.Length == 0) ? null : sb.ToString();
        }
        public override string ToString() => Name;
    }
    class Question
    {
        [Required(ErrorMessage = "Вопрос не установлен")]
        [StringLength(45, MinimumLength = 3, ErrorMessage = "Вопрос должен быть больше 3 символов и не больше 45")]
        public string Name { get; set; }
        public List<Variant> VariantsAnswers { get; set; } = new List<Variant>();
        public string CheckToValid()
        {
            var sb = new StringBuilder();
            var results = new List<ValidationResult>();
            var context = new ValidationContext(this);

            if (!Validator.TryValidateObject(this, context, results, true)) results.ForEach(e => sb.Append(e.ErrorMessage + '\n'));
            if(results.Count == 0) VariantsAnswers.ForEach(e => sb.Append(e.CheckToValid()));

            return (sb.Length == 0) ? null : sb.ToString();
        }
    }
    class Variant
    {
        [Required(ErrorMessage = "Вариант ответа не установлен")]
        [StringLength(45, MinimumLength = 3, ErrorMessage = "Вариант ответа должен быть больше 3 символов и не больше 45")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Корректность ответа не установлена")]
        public bool isCorrectAnswer { get; set; }
        public string CheckToValid()
        {
            var sb = new StringBuilder();
            var results = new List<ValidationResult>();
            var context = new ValidationContext(this);

            if (!Validator.TryValidateObject(this, context, results, true)) results.ForEach(e => sb.Append(e.ErrorMessage + '\n'));

            return (sb.Length == 0) ? null : sb.ToString();
        }
    }
}
