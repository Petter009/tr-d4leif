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
            Thread.Sleep(1000);
        }
        public void StartCutting(Scissor s1, Scissor s2)
        {
            int customerServiced = 0;
            int temp;
            while (true)
            {
                if (TryToGetScissors(s1, s2) == true)
                {
                    Monitor.Enter(s1);  Monitor.Enter(s2);
                    Console.WriteLine("Barber {0} has now started cutting", name);
                    s1.isAvailable = false;
                    s2.isAvailable = false;
                    customerServiced++;
                    temp = customerServiced;
                    Thread.Sleep(10000);
                    if (temp == 6)
                    {
                        customerServiced = 0;
                        Console.WriteLine("Barber {0} is taking a break", name);
                        Thread.Sleep(60000);
                    }
                    MakeScissorsAvailable(s1, s2);
                    Monitor.Exit(s1); Monitor.Exit(s2);
                    //Monitor.Pulse(s1); Monitor.Pulse(s2);
                    //Monitor.Wait(s1); Monitor.Wait(s2);
                }
                else
                {
                    Console.WriteLine("Barber {0} - Waiting for scissors to become available", name);
                    Thread.Sleep(5000);
                }
            }
        }
    }
}
