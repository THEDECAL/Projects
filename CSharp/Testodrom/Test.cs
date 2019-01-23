﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testodrom
{
    class Test
    {
        public string Name { get; set; }
        public List<Question> Questions { get; set; }
        public override string ToString() => Name;
    }
    class Question
    {
        public string Name { get; set; }
        public string[] Variants { get; set; } = new string[4];
        public bool[] Answers { get; set; } = new bool[4];
    }
}
