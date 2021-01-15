using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    abstract public class Entity
    {
        public int Id { get; set; }
        public DateTime DateOfCreation { get; set; }
    }
}
