using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drone
{
    class Program
    {
        static void Main(string[] args)
        {
            Drone.FindLocation(11);

            Console.Write("Press Enter To Exit Programme : ");
            Console.ReadLine();
        }
    }

    class Drone
    {
        public static void FindLocation(int Time){
            int n = 1;
            while (Time > TimeTakenAt_n(n))
            {
                n++;
                Time -= TimeTakenAt_n(n);
            }

            //Calculating starting coordinates
            Coordinates Start;
            if (n == 1)
            {
                Start.x = 0;
                Start.y = 0;
            }
            else if (IsEven(n-1))
            {
                Start.x = 0;
                Start.y = n;
            }
            else
            {
                //N is odd
                Start.x = n;
                Start.y = 0;
            }

            //Calculating final coordinates of drone

            Console.WriteLine("Start x: " + Start.x + " Start y: " + Start.y);
            Console.WriteLine("Steps left : " + Time);
        }
        private static int TimeTakenAt_n(int n)
        {
            if (IsEven(n))
                return 2 * n;

            return 2 + (2 * n);
        }

        private static bool IsEven(int n)
        {
            return n % 2 == 0;
        }
    }

    struct Coordinates
    {
        public int x;
        public int y;
    }
}
