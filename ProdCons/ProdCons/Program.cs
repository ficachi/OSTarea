using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProdCons
{
    class Program
    {


        static void Main(string[] args)
        {
            bool full = false, empty = true;

            Random ran = new Random();
            List<int> buffer = new List<int>();

            while (true)
            {

                var consumer = new Thread(() =>
                {
                    full = true;
                    if (buffer.Count == 0)
                    {
                        empty = true;
                    }
                    while (empty != true)
                    {

                        buffer.RemoveAt(buffer.Count - 1);
                        full = false;
                        Console.WriteLine("Se consumido un numero, la cantidad de objetos es: " +buffer.Count.ToString());
                        Thread.Sleep(10000);
                        if (buffer.Count == 9)
                            full = true;
                        else if (buffer.Count == 0)
                        {
                            empty = true;
                        }
                    }

                });


                var c7 = new Thread(() =>
                {
                    if (buffer.Count != 9)
                        full = false;
                    else
                        full = true;

                    while (full == false)
                    {

                        int p = ran.Next(1, 100);
                        buffer.Add(p);
                        empty = false;
                        Console.WriteLine("Se ha producido el proceso # " + p + " la cantidad de objetos es: " +buffer.Count.ToString());
                        Thread.Sleep(10000);
                        if (buffer.Count == 9)
                        {
                            full = true;
                            consumer.Start();
                        }
                    }

                });

                c7.Start();
                Thread.Sleep(1000);
                consumer.Start();
            }

            
        }


        
    }
}
