using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Entities
{
    public class Position : Entity
    {
        public string Name { get; set; }
        public override string ToString() => Name;
    }
}
