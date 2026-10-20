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
            Console.WriteLine("Введите  количество стелажей");
            int NumberOfShelves = Verification(1);
            Shelf[] shelves = new Shelf[NumberOfShelves];
            for (int i = 0; i < NumberOfShelves; i++)
            {
                Console.WriteLine("Введите количество коробок на стелаже");
                int NumberOfBox = Verification();
                Box[] boxes = new Box[NumberOfBox];
                Console.WriteLine($"Ведите информацию  о конкретной коробек в формате: название вес количество. {NumberOfBox} раз ");
                for (int j = 0; j < NumberOfBox; j++)
                {
                    (string , int  , int) MaterialGrup = VerificationMaster();
                    boxes[j] = new Box(MaterialGrup.Item1, MaterialGrup.Item2, MaterialGrup.Item3);
                }
                Shelf shelf = new Shelf(boxes);
                shelves[i] = shelf;

            }
            Base @base = new Base(shelves);

            Console.Clear();

            for (int i = 0; i < NumberOfShelves; i++)
            {
                Console.WriteLine($"Стелаж {i + 1}: общий вес {@base.Show_weight_Base(i)}"); 
            }
            Console.WriteLine();
            string[] FinalStep = @base.Greatest_weight();
            foreach (string s in FinalStep)
            {
                Console.WriteLine(s);
            }

        }

        static int Verification(int Min)
        {
            string Material = Console.ReadLine();
            if (Material.Length == 0)
            {
                Console.WriteLine($"Ничего не ввиеденно повторите операцию");
                return Verification(Min);
            }
            else
            {
                int MaterialStep1 = 0;
                if (int.TryParse(Material, out MaterialStep1))
                {
                    if (MaterialStep1 >= Min)
                    {
                        return MaterialStep1;
                    }
                    else
                    {
                        Console.WriteLine($"введино не допустимое значение {Min}<  повторите операцию");
                        return Verification(Min);
                    }
                }
                else
                {
                    Console.WriteLine("Введино не число повторите операцию");
                    return Verification(Min);
                }
            }
        }
        static int Verification(string Material)
        {
            if (Material.Length == 0)
            {
                Console.WriteLine($"Ничего не ввиеденно повторите операцию. вашо число {Material}");
                return Verification();
            }
            else
            {
                int MaterialStep1 = 0;
                if (int.TryParse(Material, out MaterialStep1))
                {
                    if (MaterialStep1 >= 0)
                    {
                        return MaterialStep1;
                    }
                    else
                    {
                        Console.WriteLine($"введино отрицательное число повторите операцию. вашо число {Material}");
                        return Verification();
                    }
                }
                else
                {
                    Console.WriteLine($"Введино не число повторите операцию. вашо число {Material}");
                    return Verification();
                }
            }
        }
        static string VerificationString()
        {
            string MaterialStap0 = Console.ReadLine();
            if (MaterialStap0.Length == 0)
            {
                Console.WriteLine($"Ничего не ввиеденно повторите операцию. Ваше имя {MaterialStap0}");
                return VerificationString();
            }
            else
            {
                return MaterialStap0;
            }
        }  

        static (string, int, int) VerificationMaster()
        {
            (string, int, int) MaterialGrup;
            string[] BoxData = Console.ReadLine().Split(' ');
            if(BoxData.Length == 0)
            {
                Console.WriteLine("Вы не ввели ничего попробуйте ещё раз");
                return VerificationMaster();
            }
            else if(BoxData.Length == 1)
            {
                Console.WriteLine("Вы ввели одно значение из трёх ");
                return VerificationMaster();
            }
            else if(BoxData.Length == 2)
            {
                Console.WriteLine("Вы ввели два значения из трёх ");
                return VerificationMaster();
            }
            else if (BoxData.Length == 3)
            {
                if (BoxData[0].Length == 0)
                {
                    Console.WriteLine("Вы не ввели имя предмета"); // Я типо хз это никогда не сработает 
                    return VerificationMaster();
                }

                int MaterialStep1 = 0;
                if (int.TryParse(BoxData[1], out MaterialStep1))
                {
                    if (MaterialStep1 >= 0) { }
                    else
                    {
                        Console.WriteLine("введино отрицательное число повторите операцию");
                        return VerificationMaster();
                    }
                }
                else
                {
                    Console.WriteLine("Введино не число повторите операцию");
                    return VerificationMaster();
                }
                int MaterialStep2 = 0;
                if (int.TryParse(BoxData[2], out MaterialStep2))
                {
                    if (MaterialStep2 >= 0) { }
                    else
                    {
                        Console.WriteLine("введино отрицательное число повторите операцию");
                        return VerificationMaster();
                    }
                }
                else
                {
                    Console.WriteLine("Введино не число повторите операцию");
                    return VerificationMaster();
                }
                return MaterialGrup = (BoxData[0], MaterialStep1, MaterialStep2);


            }
            else
            {
                Console.WriteLine("Введино больше трёх значений");
                return VerificationMaster();
            }
                

        }

    }

    class Base
    {
        private Shelf[] _shelves;
        public Base(Shelf[] Shelves)
        {
            _shelves = Shelves;
        }
        public int Show_weight_Base(int Index)
        {
            return _shelves[Index].Show_weight();
        }
        public string[] Greatest_weight()
        {
            int MaxWeight = 0;
            int PositionaxWeight = 0;
            for (int i = 0; i < _shelves.Length; i++)
            {
                if (_shelves[i].Show_weight() > MaxWeight)
                {
                    MaxWeight = _shelves[i].Show_weight();
                    PositionaxWeight = i;
                }
            }
            int s = Show_weight_Base(PositionaxWeight);
            Box[] boxes0 = _shelves[PositionaxWeight]._boxes;
            for (int i = 0; i < boxes0.Length - 1; i++)
            {
                for (int j = 0; j < boxes0.Length - 1 - i; j++)
                {

                    if (boxes0[j].Individual_weight() < boxes0[j + 1].Individual_weight())
                    {
                        Box memori = boxes0[j];
                        boxes0[j] = boxes0[j + 1];     // тут начинается полная жесть жестокость расчленёнка  boxes0[j + 1].Individual_weight() = boxes0[j].Individual_weight();   boxes0[j].Individual_weight() = memori; я сосал 
                        boxes0[j + 1] = memori;
                        
                    }
                    if (TheScary_Name(boxes0[j + 1]._name, boxes0[j]._name) && boxes0[j].Individual_weight() == boxes0[j + 1].Individual_weight())
                    {
                        Box memori = boxes0[j + 1];
                        boxes0[j + 1] = boxes0[j];
                        boxes0[j ] = memori;
                    }
                }
            }
            string PartOne = ("Самый загруженный: стелаж " + (PositionaxWeight+1) + ", вес " + s);
            string[] @return = new string[boxes0.Length + 1];
            @return[0] = PartOne;
            for (int i = 0; i < boxes0.Length; i++)
            {
                @return[i+1] = (boxes0[i]._name + ' ' + boxes0[i]._weight + ' ' + boxes0[i]._number + ' ' + boxes0[i].Individual_weight());
            }



            return @return; 
        }

        private bool TheScary_Name(string FirstName, string LastName, int index = 0)
        {
            char[] CharsFirstName = FirstName.ToCharArray();
            char[] CharsLastName = LastName.ToCharArray();
            if (FirstName != LastName)
            {

                if (CharsFirstName[index] < CharsLastName[index])
                {
                    return true;
                }
                else
                {
                    if (CharsFirstName[index] == CharsLastName[index])
                    {
                        if (index + 1 >= FirstName.Length || index + 1 >= LastName.Length)
                        {
                            if (index + 1 >= CharsFirstName.Length)
                                return false;
                            else
                                return true;
                        }
                        else
                            return TheScary_Name(FirstName, LastName, index + 1);

                    } 
                    else
                        return false;
                }
            }
            else
            {
                return false;
            }
            
        }
    }

    class Shelf
    {
        public Box[] _boxes {  get; private set; }
        public Shelf(Box[] Boxes)
        {
            _boxes = Boxes;
        }
        public int Show_weight()
        {
            int Amount = 0;
            for (int i = 0; i < _boxes.Length; i++)
            {
                Amount += _boxes[i].Individual_weight();
            }
            return Amount;
        }


    }

    class Box
    {
        public Box(string Name, int Weight, int Number)
        {
            _name = Name;
            _weight = Weight;
            _number = Number;
        }
        public string _name; 
        public int _weight { get; private set; }
        public int _number { get; private set; }

        public int Individual_weight()
        {
            return _weight * _number;
        }
    }
}

    

