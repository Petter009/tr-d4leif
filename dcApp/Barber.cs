using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void StartCutting(Scissor s1, Scissor s2)
        {
            while (true)
            {
                if (TryToGetScissors(s1, s2) == true)
                {
                    s1.isAvailable = false;
                    s2.isAvailable = false;
                }
            }
        }
    }
}
