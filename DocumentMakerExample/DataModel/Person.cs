using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaoloCattaneo.DocumentMakerExample.DataModel
{
    public class Student
    {
        public string Name { get; }
        public string Sex { get; }
        public int Age { get; }
        public string City { get; }

        public Student()
        {
            Name = "John Smith";
            Sex = "Male";
            Age = 22;
            City = "Springfield (Illinois)";
        }
    }
}
