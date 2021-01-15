using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Entities
{
    public class Department : Entity
    {
        public string Name { get; set; }
        public bool State { get; set; }
        public DateTime? DateOfClosed { get; set; }

        public int? ParentDepartmentId { get; set; }
        public Department ParentDepartment { get; set; }

        public string GetStateName() => (State) ? "В работе" : "Закрыто";
        public override string ToString() => Name;
    }
}
