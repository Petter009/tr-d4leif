using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace dcApp
{
    public class Barber
    {
        public string name { get; set; }

        public Barber(string name)
        {
            this.name = name;
            
        }

        public bool TryToGetScissors(Scissor s1, Scissor s2)
        {
            if (s1.isAvailable == true && s2.isAvailable == true)
            {
                return true;
            }
            else
                return false;
        }
        public void MakeScissorsAvailable(Scissor s1, Scissor s2)
        {
            s1.isAvailable = true;
            s2.isAvailable = true;
            Console.WriteLine("Scissors {0} and {1} have become available", s1.name, s2.name);
        }
        public void StartCutting(Scissor s1, Scissor s2)
        {
            Random rand = new Random();
            object locker = new object();
            int customerServiced = 0;
            int temp;
            while (true)
            {
                Thread.Sleep(5000);
                if (TryToGetScissors(s1, s2) != true)
                {
                    
                    Console.WriteLine("Barber {0} - WaitinG.... {1} = {2}, {3} = {4}", name, s1.name, s1.isAvailable, s2.name, s2.isAvailable);
                    Thread.Sleep(5000);
                }
                else
                {
                    Monitor.Enter(locker);
                    Console.WriteLine("Barber {0} has now started cutting - nr {1}", name, customerServiced);
                    s1.isAvailable = false;
                    s2.isAvailable = false;
                    customerServiced++;
                    temp = customerServiced;
                    Thread.Sleep(rand.Next(2000, 30000));
                    //Thread.Sleep(1000);
                    if (temp % 10 == 0)
                    {
                        Console.WriteLine("Barber {0} is taking a break", name);
                        MakeScissorsAvailable(s1, s2);
                        Thread.Sleep(20000);
                    }
                    MakeScissorsAvailable(s1, s2);
                    Monitor.Exit(locker);
                    //Monitor.Pulse(s1); Monitor.Pulse(s2);
                    //Monitor.Wait(s1); Monitor.Wait(s2);
                }
            }
        }
    }
}
