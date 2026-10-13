using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace C_Charp_Consol
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //char[] arr = { 'a', 'b', 'c', };
            //foreach (char c in arr)
            //{
            //    Console.WriteLine(c);
            //}
            int playerLeng = Convert.ToInt32(Console.ReadLine());
            Player[] players = new Player[playerLeng];
            string[] names = new string[playerLeng];
            for (int i = 0; i < playerLeng; i++)
            {
                string name = Console.ReadLine();
                players[i] = new Player(name);
                names[i] = name;
            }
            int matchLeng = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < matchLeng; i++)
            {
                string ll = Console.ReadLine();
                char[] firstName = new char[ll.Length];
                char[] secondName = new char[ll.Length];
                bool flag0 = false;
                int v = 0;
                for (int j = 0; j < ll.Length; j++)
                {
                    if (ll[i] == ' ')
                    {
                        break;
                    }
                    else if (flag0 == false)
                    {
                        firstName[j] = ll[j];
                    }
                    else
                    {
                        secondName[j - v] = ll[j];
                    }
                    if (ll[j] == ' ')
                    {
                        v = j;
                        flag0 = true;
                    }

                }
                string[] a = new string[2];
                a[0] = new string(firstName);
                a[1] = new string(secondName);
                //Console.WriteLine("{");
                //Console.WriteLine(a[0]);
                //Console.WriteLine(a[1]);
                //Console.WriteLine("}");

                foreach (Player c in players)
                {
                    
                    Console.WriteLine($"В обьекте {c.Name}    {c.Name}");
                    Console.WriteLine($"В Массиве {a[0] == c.Name}/    {a[0]}/");
                }
                for(int n = 0; n < a.Length; n++)
                {
                    //int j = 0;
                    //Console.WriteLine($"Максимальная длина J {players.Length}");
                    //do
                    //{
                    //    Console.WriteLine($"Реальный J {j}");
                    //    if(j >= matchLeng)
                    //    {
                    //        Console.WriteLine("Ошибка");
                    //        break;
                    //    }
                    //    if (a[n] == players[j].Name)
                    //    {
                    //        if(n == 0)
                    //        {
                    //            players[j].Victory();
                    //        }
                    //        else
                    //        {
                    //            players[j].Losse();
                    //        }
                    //    }
                    //    j++;

                    //} while (a[n] != players[j].Name);
                }

            }


        }
        static string Parser(char[] chars)
        {

            string name = new string(chars);
            return name;
        }
    }
    class Player
    {
        public string Name { get; private set; }
        private int _win ;
        private int _loss;

        public Player(string name)
        {
            Name = name;
        }
        
        public void Victory()
        {
            _win += 1;
        }
        public void Losse()
        {
            _loss += 1;
        }
    }
    
}

