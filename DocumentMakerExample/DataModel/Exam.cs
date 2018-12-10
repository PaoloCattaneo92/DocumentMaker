using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaoloCattaneo.DocumentMakerExample.DataModel
{
    public class Exam
    {
        public string Argument { get; }
        public string Date { get; }
        public int Vote { get; }

        public Exam(string argument, string date, int result)
        {
            Argument = argument;
            Date = date;
            Vote = result;
        }
    }
}
