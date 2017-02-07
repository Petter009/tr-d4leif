using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dcApp
{
    public class Scissor
    {
        public bool isAvailable { get; set; }
        public string name { get; set; }

        public Scissor(string name)
        {
            this.name = name;
            isAvailable = true;
        }
    }
}
