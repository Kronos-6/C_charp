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
            Table[] Zal = {new Table(1, 8), new Table(2, 3), new Table(3, 5),};
            while (true)
            {
                for (int i = 0; i < Zal.Length; i++)
                {
                    Zal[i].ShovInfo();
                }
                Console.WriteLine("Введите номер стола ");
                int tableUserNamber = Convert.ToInt32(Console.ReadLine())-1;
                Console.WriteLine("Введите количестов  бронируемых мест ");
                int plaseUserNamber = Convert.ToInt32(Console.ReadLine());
                if (Zal[tableUserNamber].TruBool(plaseUserNamber))
                {
                    Console.WriteLine($"Вы забронировали столик номер: {tableUserNamber + 1} на {plaseUserNamber} человек");
                }
                else
                    Console.WriteLine("Вы привысили количество свободных мест");
                Console.ReadKey(false);
                Console.Clear();
            }

        }

    }

    class Table
    {
        private int _namber;
        private int _maxPlase;
        private int _freePlase;

        public Table(int Namber, int MaxPlases)
        {
            _maxPlase = MaxPlases;
            _namber = Namber;
            _freePlase = MaxPlases;
        }
        public void ShovInfo()
        {
            Console.WriteLine($"номер стола: {_namber}. Максимальное число мест: {_maxPlase}. Число свободных мест сейчас: {_freePlase}");
        }
        public bool TruBool(int TriyGivePlase)
        {
            if(TriyGivePlase > _freePlase)
            {
                return false;
            }
            else
            {
                _freePlase -= TriyGivePlase;
                return true;
            }
        }

    }


}

