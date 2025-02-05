using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class Answer : IComparable<Answer>
    {
        #region Property
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }
        #endregion

        #region Constructor
        public Answer(int id, string answerText) 
        {
            AnswerId = id;
            AnswerText = answerText;
        }
        public Answer(string answerText) : this(0, answerText) // Create object to store correct answer
        {
        }
        #endregion

        #region Methods
        public int CompareTo(Answer? other)
        {
            return (this.AnswerId == other?.AnswerId && this.AnswerText == other.AnswerText) ? 1 : 0;
        }
        public override string ToString()
        {
            return $"Answer : {AnswerText}";
        } 
        #endregion
    }
}
