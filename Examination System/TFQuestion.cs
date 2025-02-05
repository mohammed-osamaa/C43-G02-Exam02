using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class TFQuestion : Question
    {
        public bool CorrectAnswer { get; set; }
        public bool UserAnswer { get; set; }
        public TFQuestion(string? header, string? body, double mark, bool correctAnswer) : base(header, body, mark)
        {
            CorrectAnswer = correctAnswer;
        }
        public override string ToString()
        {
            return $"{Header}\t\tMark: {Mark}\n{Body}\n1.True\t2.False";
        }
    }
}
