using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class PracticalExam : Exam
    {
        public PracticalExam(int timeofMinute, int numberOfQuestion) : base(timeofMinute, numberOfQuestion)
        {
        }

        #region Methods
        public override void CreateQuestionsOfExam(int numberOfQuestions)
        {
            List<Question> questions = new List<Question>();

            for (int i = 0; i < numberOfQuestions; i++)
            {
                string header, body;
                double mark;
                header = "Choose From Options.";
                Console.WriteLine(header);

                Console.WriteLine($"Please Enter the body of Question ({i + 1}) : ");
                body = Console.ReadLine();

                Console.Write($"Please Enter the Mark of Question ({i + 1}) : ");
                bool IsParse = false;
                do
                {
                    IsParse = double.TryParse(Console.ReadLine(), out mark);
                } while (!IsParse);

                List<Answer> answers = new List<Answer>(3);
                for (int j = 0; j < answers.Capacity; j++)
                {
                    Console.Write($"Enter Option {j + 1}: ");
                    answers.Add(new Answer(j + 1, Console.ReadLine()));
                }

                Console.WriteLine($"Please Enter the Correct Answer of Question ({i + 1}): ");
                for (int k = 0; k < answers.Count; k++)
                    Console.Write($"{k + 1}. {answers[k].AnswerText}\t");

                Console.WriteLine(); // NewLine
                int CorrectOption;
                do
                {
                    IsParse = int.TryParse(Console.ReadLine(), out CorrectOption);
                } while (!IsParse);

                foreach (Answer answer in answers)
                    if (CorrectOption == answer.AnswerId)
                        questions.Add(new McqQuestion(header, body, mark, answers, answer));
            }
            this.Questions = questions;
        }

        public override void ShowExam()
        {
            Console.Clear();

            Dictionary<int,Answer> MyAnswers = new Dictionary<int, Answer>(Questions.Count);
            bool IsParse = false;
            for (int i = 0; i < this.Questions.Count; i++)
            {
                Console.WriteLine(Questions[i]);
                Console.WriteLine("======================================================");
                int AnsNumber;
                do
                {
                    IsParse = int.TryParse(Console.ReadLine(), out AnsNumber);
                } while (!IsParse);

                if (Questions[i] is McqQuestion mcqQuestion)
                    foreach (Answer answer in mcqQuestion.Answers)
                        if (answer.AnswerId == AnsNumber)
                            MyAnswers.Add(i, answer);
            }

            Console.WriteLine("Wait Your Result of Exam.... ");
            Thread.Sleep(2000);
            Console.Clear();

            ShowResult(MyAnswers);
        }
        public override void ShowResult(Dictionary<int, Answer> myAnswers)
        {
            for (int i = 0; i < Questions.Count; i++)
                if (Questions[i] is McqQuestion mcqQuestion)
                {
                    Console.WriteLine($"My {myAnswers[i]}");
                    Console.WriteLine($"*** The Correct Answer : {mcqQuestion.CorrectAnswer} ***");
                    Console.WriteLine("===================================================");
                    if (myAnswers.Count > 0)
                    {
                        int res = myAnswers[i].CompareTo(mcqQuestion.CorrectAnswer);
                        if (res == 1)
                            Score += mcqQuestion.Mark;
                    }
                }
            Console.WriteLine($"The Total Marks Is {Score}");

        }
        #endregion
    }
}
