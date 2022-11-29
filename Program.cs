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
            while (Time >= TimeTakenAt_n(n))
            {
                Time -= TimeTakenAt_n(n);
                //Console.WriteLine("Subtracting : " + " n : " + n + " result : "+ TimeTakenAt_n(n));
                n++;
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
            Coordinates Final = Start;
            if (!IsEven(n))
            {
                // 1 meter forward
                if(Time > 0)
                {
                    Final.y += 1;
                    Time--;
                }

                // n meter left
                if (Time > 0)
                {
                    if(Time < n)
                    {
                        Final.x += Time;
                        Time = 0;
                    }
                    else
                    {
                        Final.x += n;
                        Time -= n;
                    }
                }

                // n meter backwards
                if (Time > 0)
                {
                    if (Time < n)
                    {
                        Final.y -= Time;
                        Time = 0;
                    }
                    else
                    {
                        Final.y -= n;
                        Time -= n;
                    }
                }

                // n meter left
                if (Time > 0)
                {
                    Final.x += 1;
                }
            }
            else
            {
                //n meter forward
                if (Time > 0)
                {
                    if (Time < n)
                    {
                        Final.y += Time;
                        Time = 0;
                    }
                    else
                    {
                        Final.y += n;
                        Time -= n;
                    }
                }

                //n meter right
                if (Time > 0)
                {
                    if (Time < n)
                    {
                        Final.x -= Time;
                        Time = 0;
                    }
                    else
                    {
                        Final.x -= n;
                        Time -= n;
                    }
                }
            }

            Console.WriteLine("x: " + Final.x + " meters left \ny: " + Final.y + " meters foward");
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
