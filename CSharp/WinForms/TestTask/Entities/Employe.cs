using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Entities
{
    public class Employe : Entity
    {
        public string PN { get; set; } //Табельный номер
        public string TIN { get; set; } //ИНН
        public string SName { get; set; }
        public string FName { get; set; }
        public string PName { get; set; }
        public bool Gender { get; set; } //Где True - мужчина, а False - женщина
        public DateTime Birthday { get; set; }
        public string PlaceOfBirth { get; set; }
        public DateTime DateOfEmployment { get; set; }
        public DateTime? DateOfDismissal { get; set; }
        public string CauseOfDismissal { get; set; }

        public int PositionId { get; set; }
        public Position Position { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public override string ToString() => $"{SName} {FName[0]}.{PName[0]}.";
    }
}
