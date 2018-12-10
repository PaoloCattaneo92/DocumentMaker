using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaoloCattaneo.DocumentMakerExample.DataModel
{
    public class ExamDetail
    {
        public string[] Chapters;

        public ExamDetail(params string[] chapters)
        {
            Chapters = chapters;
        }
    }
}
