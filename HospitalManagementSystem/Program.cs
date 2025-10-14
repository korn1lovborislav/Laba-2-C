using System;

namespace HospitalManagementSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Для відображення українських літер
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            HospitalDemo demo = new HospitalDemo();
            demo.Run();

            Console.WriteLine("\nНатисніть будь-яку клавішу для виходу...");
            Console.ReadKey();
        }
    }
}