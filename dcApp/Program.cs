using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace dcApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Barber bA = new Barber("Kim");
            Barber bB = new Barber("Leif");
            Barber bC = new Barber("Simon");
            Barber bD = new Barber("Pelle");
            Barber bE = new Barber("Søren");
            Barber bF = new Barber("Nikolaj");

            Scissor sA = new Scissor("AB");
            Scissor sB = new Scissor("BC");
            Scissor sC = new Scissor("CD");
            Scissor sD = new Scissor("DE");
            Scissor sE = new Scissor("EF");
            Scissor sF = new Scissor("FA");

            Thread A = new Thread(() => bA.StartCutting(sA, sF));
            Thread B = new Thread(() => bB.StartCutting(sA, sB));
            Thread C = new Thread(() => bC.StartCutting(sB, sC));
            Thread D = new Thread(() => bD.StartCutting(sC, sD));
            Thread E = new Thread(() => bE.StartCutting(sD, sE));
            Thread F = new Thread(() => bF.StartCutting(sE, sF));

            A.Start();
            B.Start();
            C.Start();
            D.Start();
            E.Start();
            F.Start();
        }
    }
}
