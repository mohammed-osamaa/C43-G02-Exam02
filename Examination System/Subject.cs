using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class Subject
    {

        public int Id { get; set; } 
        public string Name { get; set; }
        public Subject(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public Exam Exam { get; set; }

        public void CreateExam()
        {
            Console.Write("Please Choose The Type Of Exam [1.Final\t2.Practical] : ");
            bool IsParse = false;
            int Type;
            do
            {
                IsParse= int.TryParse(Console.ReadLine(),out Type);
            }while (!IsParse);

            Console.Write("Please Enter the Number of Questions : ");
            int numOfQuestion;
            do
            {
                IsParse = int.TryParse(Console.ReadLine(), out numOfQuestion);
            } while (!IsParse);

            Console.Write("Please Enter the time of Exam in Minutes : ");
            int Time;
            do
            {
                IsParse = int.TryParse(Console.ReadLine(), out Time);
            } while (!IsParse);

            if (Type == 1)
                Exam = new FinalExam(Time,numOfQuestion);
            else
                Exam = new PracticalExam(Time, numOfQuestion);

            Console.Clear();
            Exam.CreateQuestionsOfExam(numOfQuestion);
        }

        public override string ToString()
        {
            return $"Id : {Id} , Name : {Name}";
        }
    }
}
