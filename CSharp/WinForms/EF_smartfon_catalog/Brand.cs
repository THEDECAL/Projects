using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartfon_catalog
{
    class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public override string ToString() => Name;
    }
}
