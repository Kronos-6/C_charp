using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Charp_Consol
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int scale = 3;
            int scaleLong = Convert.ToInt32(Math.Pow(2, scale));
            bool[,] arryBool = new bool[scaleLong, scale + 1];
            //for(int i = 0; i<scaleLong;i++)
            //{
            //    string memore = Convert.ToString(i, 2);
            //    int chfg = 0;
            //    for (int k = memore.Length - 1; k >= 0; k--)
            //    {
            //        arryBool[i, k] = (memore[k] == '0') ? false : true;
            //        //Console.Write(memore[k]);

            //    }
            //    Console.WriteLine();

            //}

            //0
            //1
            //01
            //11
            //001
            //101
            //011
            //111


            //for (int i = 0; i < scaleLong; i++)
            //{
            //    for (int j = 0; j < scale; j++)
            //    {
            //        if (arryBool[i, j] == false)
            //        {
            //            Console.Write('0');
            //        }
            //        else
            //        {
            //            Console.Write('1');
            //        }

            //    }
            //    Console.WriteLine();
            //}

            //int[] a = new int[] { 0, 0, 1 };

            //int[] b = new int[] { 1 };

            //int last_index = 0;

            //for (int i = 0; i < b.Length; i++)
            //{
            //    a[i] = b[i];
            //    last_index = i+1;
            //}

            //for (int i = a.Length - b.Length; i < a.Length; i++)
            //{
            //    a[i] = 0;

            //}
        }
    }
}

