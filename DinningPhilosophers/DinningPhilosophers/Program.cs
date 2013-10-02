using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace DinningPhilosophers
{
    class Program
    {
        static void Main(string[] args)
        {
            bool eating1 = false, eating2 = false, eating3 = false, eating4 = false, eating5 = false;

            while (true)
            {
                var Phi1 = new Thread(() =>
                {
                        if (eating5 == false && eating2 == false)
                        {
                            eating1 = true;
                            Console.WriteLine("filosofo 1 esta comiendo");
                            Thread.Sleep(2000);
                            eating1 = false;
                        }
                        else
                            Console.WriteLine("filosofo 1 esta pensando");
                });


                var Phi2 = new Thread(() =>
                {
                    if (eating1 == false && eating3 == false)
                    {
                        eating2 = true;

                        Console.WriteLine("filosofo 2 esta comiendo");
                        Thread.Sleep(3500);
                        eating2 = false;
                    }

                    else
                        Console.WriteLine("filosofo 2 esta pensando");
                });


                var Phi3 = new Thread(() =>
                {
                    if (eating2 == false && eating4 == false)
                    {
                        eating3 = true;

                        Console.WriteLine("filosofo 3 esta comiendo");
                        Thread.Sleep(3000);
                        eating3 = false;
                    }
                    else
                        Console.WriteLine("filosofo 3 esta pensando");
                });



                var Phi4 = new Thread(() =>
                {
                    if (eating3 == false && eating5 == false)
                    {
                        eating4 = true;

                        Console.WriteLine("filosofo 4 esta comiendo");
                        Thread.Sleep(1000);
                        eating4 = false;
                    }
                    else
                        Console.WriteLine("filosofo 4 esta pensando");
                });


                var Phi5 = new Thread(() =>
                {
                    if (eating1 == false && eating4 == false)
                    {
                        eating5 = true;
                        Console.WriteLine("filosofo 5 esta comiendo");
                        Thread.Sleep(5000);
                        eating5 = false;
                    }
                    else
                        Console.WriteLine("filosofo 5 esta pensando");

                });


                Phi3.Start();
                Phi4.Start();
                Phi5.Start();
                Phi1.Start();
                Phi2.Start();
                Console.WriteLine();
            }
            
        }
    }
}
