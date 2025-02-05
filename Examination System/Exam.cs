using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal abstract class Exam
    {

        public int TimeofMinute { get; set; }
        public int NumberOfQuestion {  get; set; }
        public List<Question> Questions { get; set; }
        public double Score { get; set; }
        protected Exam(int timeofMinute, int numberOfQuestion)
        {
            TimeofMinute = timeofMinute;
            NumberOfQuestion = numberOfQuestion;
        }

        public abstract void CreateQuestionsOfExam(int numberOfQuestion);
        public abstract void ShowExam();
        public abstract void ShowResult(Dictionary<int, Answer> myAnswers);
    }
}
