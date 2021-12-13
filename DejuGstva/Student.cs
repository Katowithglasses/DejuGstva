using System;
using System.Collections.Generic;
using System.Text;

namespace DejuGstva
{
    public class Student
    {
        public string FIO { get; set; }
        public int Group { get; set; }
        public List<DateTime> DateOfDejurstva = new List<DateTime>();
    }
}
