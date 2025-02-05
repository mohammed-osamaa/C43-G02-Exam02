
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class FinalExam : Exam
    {
        public FinalExam(int timeofMinute, int numberOfQuestion) : base(timeofMinute, numberOfQuestion)
        {
        }

        #region Methods
        public override void CreateQuestionsOfExam(int numberOfQuestions)
        {
            List<Question> questions = new List<Question>();
            bool IsParse = false;
            for (int i = 0; i < numberOfQuestions; i++)
            {
                Console.Write("Please Enter the Type of Question (1. True or False || 2. MCQ): ");
                int choice;
                do
                {
                    IsParse = int.TryParse(Console.ReadLine(), out choice);
                }while(!IsParse);

                Console.Clear();

                string header, body;
                double mark;


                if (choice == 1)
                {
                    header = "Choose True Or False.";
                    Console.WriteLine(header);

                    Console.WriteLine($"Please Enter the body of Question ({i + 1}) : ");
                    body = Console.ReadLine();

                    Console.Write($"Please Enter the Mark of Question ({i + 1}) : ");
                    do
                    {
                        IsParse = double.TryParse(Console.ReadLine(), out mark);
                    } while (!IsParse);

                    Console.Write($"Please Enter the Correct Answer of Question ({i + 1}) [1. True\t2. False] : ");
                    int c;
                    do
                    {
                        IsParse = int.TryParse(Console.ReadLine(), out c);
                    } while (!IsParse);

                    bool CorrectAns = (c == 1) ? true : false;
                    questions.Add(new TFQuestion(header, body, mark, CorrectAns));
                }
                else
                {
                    header = "Choose One Option from These Options.";
                    Console.WriteLine(header);

                    Console.WriteLine($"Please Enter the body of Question ({i + 1}) : ");
                    body = Console.ReadLine();

                    Console.Write($"Please Enter the Mark of Question ({i + 1}) : ");
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

                    Console.WriteLine(); // NewLine
                    Console.WriteLine($"Please Enter the Correct Answer of Question ({i + 1}): ");
                    for (int k = 0; k < answers.Count; k++)
                        Console.Write($"{k + 1}. {answers[k].AnswerText}\t");

                    int CorrectOption;
                    do
                    {
                        IsParse = int.TryParse(Console.ReadLine(), out CorrectOption);
                    }while (!IsParse);

                    foreach (Answer answer in answers)
                        if(CorrectOption == answer.AnswerId)
                        {
                            questions.Add(new McqQuestion(header, body, mark, answers, answer));
                            break;
                        }
                }
            }
            this.Questions = questions;
        }
        public override void ShowExam()
        {
            Console.Clear();

            Dictionary<int,Answer> MyAnswers = new Dictionary<int, Answer>();

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
                {
                    foreach (Answer answer in mcqQuestion.Answers)
                        if (answer.AnswerId == AnsNumber)
                            MyAnswers.Add(i, answer);
                }
                else if(Questions[i] is TFQuestion tf_Question)
                {
                    bool myAnswer = (AnsNumber == 1);
                    tf_Question.UserAnswer = myAnswer;
                }
            }

            Console.WriteLine("Wait Your Result of Exam.... ");
            Thread.Sleep(2000);
            Console.Clear();

            ShowResult(MyAnswers);
        } 
    
        public override void ShowResult(Dictionary<int,Answer> myAnswers)
        {
            for (int i = 0; i < this.Questions.Count; i++)
            {
                if (Questions[i] is McqQuestion mcqQuestion)
                {

                    Console.WriteLine(mcqQuestion);
                    Console.WriteLine($"My {myAnswers[i]}");
                    Console.WriteLine("===================================================");

                    if (myAnswers.Count > 0)
                    {
                        int res = myAnswers[i].CompareTo(mcqQuestion.CorrectAnswer);
                        if (res == 1)
                            Score += mcqQuestion.Mark;
                    }
                }
                else if (Questions[i] is TFQuestion tf_Question)
                {
                    Console.WriteLine(tf_Question);
                    Console.WriteLine($"My Answer {tf_Question.UserAnswer}");
                    Console.WriteLine("===================================================");
                    if (tf_Question.UserAnswer == tf_Question.CorrectAnswer)
                        Score += tf_Question.Mark;
                }
            }
            Console.WriteLine($"The Total Marks Is {Score}");
        }
        #endregion

    }
}
