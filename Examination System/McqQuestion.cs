using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class McqQuestion : Question
    {
        #region Properety
        public List<Answer>? Answers { get; set; }
        public Answer CorrectAnswer { get; set; }
        #endregion

        #region Constructor
        public McqQuestion(string? header, string? body, double mark, List<Answer>? answers, Answer correctAnswer) : base(header, body, mark)
        {
            Answers = answers;
            CorrectAnswer = correctAnswer;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            string answers = "";
            if (Answers?.Count > 0)
            {
                for (int i = 0; i < Answers.Count; i++)
                {
                    answers += $"{i + 1}.{Answers[i].AnswerText}\t\t";
                }
            }
            return $"{Header}\t\tMark: {Mark}\n{Body}\n{answers}";
        }
        #endregion

    }
}
