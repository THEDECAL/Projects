using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Entities
{
    public class TransferHistory : Entity
    {
        public int DepartmentId { get; set; }
        //[ForeignKey("DepartmentId")]
        //public Department Department { get; set; }
        public int PositionId { get; set; }
        //[ForeignKey("PositionId")]
        //public Position Position { get; set; }
        public int EmployeId { get; set; }
        //[ForeignKey("EmployeId")]
        //public Employe Employe { get; set; }
    }
}
