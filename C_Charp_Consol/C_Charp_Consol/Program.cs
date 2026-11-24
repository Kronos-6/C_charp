using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace C_Charp_Consol
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(0.1f+ 0.2f);
            //Ikan a = new One();
            //a.Fank1();
        }
    }
     interface Ikan
    {
        void Fank1();
    }
    class One : Ikan
    {
        public void Fank1()
        {

        }
    }
    abstract class Tou
    {
        public abstract void Mah(); 
    }
 

}

    

