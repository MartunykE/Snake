using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ConsoleApp1
{
    class Program
    {
        static Timer timer; 
        static void Main(string[] args)
        {
            SetTimer();
            Console.ReadKey();
            timer.Stop();


            Console.ReadKey();

        }

        static void SetTimer()
        {
            timer = new Timer(500);
            timer.Elapsed += ev;
            timer.Enabled = true;

        }
        static void ev(object source, ElapsedEventArgs e)
        {
            Console.WriteLine(2);
        }
    }
}
