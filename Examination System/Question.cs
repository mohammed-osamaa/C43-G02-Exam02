using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class Question
    {

        public string? Header { get; set; }
        public string? Body { get; set; }
        public double Mark { get; set; }
        public Question(string? header, string? body, double mark)
        {
            Header = header;
            Body = body;
            Mark = mark;
           
        }

    }
}
