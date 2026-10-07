using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Charp_Consol
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Ball sphere = new Ball();
            sphere.Ves(); 

        }
    }
    class Ball
    {
        public int radius;
        public int p;
        public void Ves()
        {
            Console.WriteLine(radius*p);
        }
    }
}

