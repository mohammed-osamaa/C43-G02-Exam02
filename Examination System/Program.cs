using System.Diagnostics;

namespace Examination_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject subject = new Subject(10,"C#");
            subject.CreateExam();
            Console.Clear();

            Console.WriteLine($"Do you Want to Start the {subject.Name} Exam ? (y | n)");

            if(char.Parse( Console.ReadLine()) == 'y')
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                subject.Exam.ShowExam();
                Console.WriteLine($"the Elapsed time is {sw.Elapsed}");
            }
        }
    }
}
