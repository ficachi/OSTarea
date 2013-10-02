using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Text;

namespace SleepingBarbero
{
    class Program
    {
        Barber buffer = new Barber(5);
        Random random = new Random();




        static void Main(string[] args)
        {
            Barber buffer = new Barber(5);
            Random random = new Random();

            Console.WriteLine("Pulsar cualquier tecla para empezar los cortes :) ");
            Console.ReadKey();





            var Barber = new Thread(() =>
            {
                while (true)
                {
                    buffer.Barbers();
                    Thread.Sleep(1500);
                }
            });

            var Cliente1 = new Thread(() =>
            {
                while (true)
                {
                    int r = random.Next(1, 50);
                    buffer.Clientes(r);
                    Thread.Sleep(1000);
                }
            });
            var Cliente2 = new Thread(() =>
            {
                while (true)
                {
                    int r = random.Next(1, 50);
                    buffer.Clientes(r);
                    Thread.Sleep(1000);
                }
            });
            var Cliente3 = new Thread(() =>
            {
                while (true)
                {
                    int r = random.Next(1, 50);
                    buffer.Clientes(r);
                    Thread.Sleep(1000);
                }
            });
            var Cliente4 = new Thread(() =>
            {
                while (true)
                {
                    int r = random.Next(1, 50);
                    buffer.Clientes(r);
                    Thread.Sleep(1000);
                }
            });
            var Cliente5 = new Thread(() =>
            {
                while (true)
                {
                    int r = random.Next(1, 50);
                    buffer.Clientes(r);
                    Thread.Sleep(1000);
                }
            });
            var Cliente6 = new Thread(() =>
            {
                while (true)
                {
                    int r = random.Next(1, 50);
                    buffer.Clientes(r);
                    Thread.Sleep(1000);
                }
            });
            var Cliente7 = new Thread(() =>
            {
                while (true)
                {
                    int r = random.Next(1, 50);
                    buffer.Clientes(r);
                    Thread.Sleep(1000);
                }
            });
            var Cliente8 = new Thread(() =>
            {
                while (true)
                {
                    int r = random.Next(1, 50);
                    buffer.Clientes(r);
                    Thread.Sleep(1000);
                }
            });
            var Cliente9 = new Thread(() =>
            {
                while (true)
                {
                    int r = random.Next(1, 50);
                    buffer.Clientes(r);
                    Thread.Sleep(1000);
                }
            });
            var Cliente10 = new Thread(() =>
            {
                while (true)
                {
                    int r = random.Next(1, 50);
                    buffer.Clientes(r);
                    Thread.Sleep(1000);
                }
            });
            var Cliente11 = new Thread(() =>
            {
                while (true)
                {
                    int r = random.Next(1, 50);
                    buffer.Clientes(r);
                    Thread.Sleep(1000);
                }
            });
            var Cliente12 = new Thread(() =>
            {
                while (true)
                {
                    int r = random.Next(1, 50);
                    buffer.Clientes(r);
                    Thread.Sleep(1000);
                }
            });
            var Cliente13 = new Thread(() =>
            {
                while (true)
                {
                    int r = random.Next(1, 50);
                    buffer.Clientes(r);
                    Thread.Sleep(1000);
                }
            });
            var Cliente14 = new Thread(() =>
            {
                while (true)
                {
                    int r = random.Next(1, 50);
                    buffer.Clientes(r);
                    Thread.Sleep(1000);
                }
            });
            var Cliente15 = new Thread(() =>
            {
                while (true)
                {
                    int r = random.Next(1, 50);
                    buffer.Clientes(r);
                    Thread.Sleep(1000);
                }
            });


            Barber.Start();
            Cliente1.Start();
            Cliente2.Start();
            Cliente3.Start();
            Cliente4.Start();
            Cliente5.Start();
            Cliente6.Start();
            Cliente7.Start();
            Cliente8.Start();
            Cliente9.Start();
            Cliente10.Start();
            Cliente11.Start();
            Cliente12.Start();
            Cliente13.Start();
            Cliente14.Start();
            Cliente15.Start();
            Console.WriteLine("");
        }



        public class Barber
        {
            Semaphore BReady;
            Semaphore sentarse;
            Semaphore CReady;
            int asientosLibres;
            public Barber(int nAsientos)
            {
                BReady = new Semaphore(0, nAsientos);
                sentarse = new Semaphore(nAsientos, nAsientos);
                CReady = new Semaphore(0, nAsientos);
                asientosLibres = nAsientos;
            }
            public void Barbers()
            {
                while (true)
                {
                    if (asientosLibres != 0)
                    {
                        CReady.WaitOne();
                    }
                    else
                    {
                        sentarse.WaitOne();
                        asientosLibres++;
                        BReady.Release();
                        sentarse.Release();
                        Console.WriteLine("Cortando el pelo");
                    }
                }
            }
            public void Clientes(int cliente)
            {
                sentarse.WaitOne();
                if (asientosLibres > 0)
                {
                    asientosLibres--;
                    CReady.Release();
                    sentarse.Release();
                    BReady.WaitOne();
                    Console.WriteLine("El cliente " + cliente + " se esta cortando el cabello");
                }
                else
                {
                    sentarse.Release();
                    Console.WriteLine("El Cliente " + cliente + " se fue por falta de asientos :(");
                }
            }
        }
    }
}
