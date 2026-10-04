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
            int scale_long = Convert.ToInt32(Math.Pow(2, scale));
            bool[,] arry_bool = new bool[scale+1, scale_long];
            for(int i = 0; i<scale_long;i++)
            {
                string memore = Convert.ToString(i, 2);
                for (int j = 0; j < scale; j++)
                {
                    arry_bool[j, i] = false;
                }
                for (int f = memore.Length; f < 0; f--)
                {
                    arry_bool[arry_bool.GetLength(0) + f - 1, i] = memore[f];

                }

                Console.WriteLine();
            }
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

