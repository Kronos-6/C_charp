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
        static Brigade brigade;
        static void Main(string[] args)
        {

            
            Console.WriteLine("Введите инормацию  о количестве требуемых рабочих");
            int WorkerCount = Convert.ToInt32(Console.ReadLine());
            List<Worker> WorkerList = new List<Worker>();
            Console.WriteLine("введите информацию в формате: тип имя часы. Допустимые типы Master и Apprentice");


            for (int i = 0; i< WorkerCount; i++)
            {
                Console.Write($"{i+1} строки: ");
                Worker worker = MasterChek();
                WorkerList.Add(worker);
                
            }
            brigade = new Brigade(WorkerList);
            Console.WriteLine("введите число команд");
            int CommandCount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Команды в формате: train name, sorted, original");
            for (int i = 0; i < CommandCount; i++)
            {
                Console.Write($"{i + 1} строки: ");
                CommandChek();

            }


        }
        static Worker MasterChek()
        {
            string[] UserInputArray = new string[2];
            string UserInput = Console.ReadLine();
            UserInputArray = UserInput.Split(' ');
            if (UserInputArray.Length < 3)
            {
                Console.WriteLine("Вы ввели не всю информацию или ввели её не коректно");
                return MasterChek();
            }
            else
            {
                if (UserInputArray[1].Length == 0)
                {
                    Console.WriteLine("Имя не введено");
                    return MasterChek();
                }
                else
                {
                    int hours;
                    if (int.TryParse(UserInputArray[2], out hours))
                    {
                        if(hours<1)
                        {
                            Console.WriteLine("Время рабочего не может быть менее 1 часа");
                            return MasterChek();
                        }
                        else if (UserInputArray[0] == "Master")
                        {
                            return new Master(UserInputArray[1], hours);
                        }
                        else if (UserInputArray[0] == "Apprentice")
                        {
                            return new Apprentice(UserInputArray[1], hours);
                        }
                        else
                        {
                            Console.WriteLine("Введинно не допустимы тип работника");
                            return MasterChek();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Вы ввели в качестве часов значение которое нельзя преобразовать в число");
                        return MasterChek();
                    }
                }

            }
        }
        static void CommandChek()
        {
            string[] command = Console.ReadLine().Split(' ');
            if (command.Length == 0)
            {
                Console.WriteLine("не введиной комманды");
            }
            else
            {
                if (command[0] == "train")
                {
                    if (command.Length < 1)
                    {
                        Console.WriteLine("Имя рабочего не введено");
                    }
                    else
                    {
                        FFind(command[1]);
                    }
                }
                else if(command[0] == "sorted")
                {
                    FSorted();
                }  
                else if (command[0] == "original")
                {
                    FOriginal();
                }
                else
                {
                    Console.WriteLine("Команда не распознана");
                    CommandChek();
                }
            }
        }
        static void FSorted()
        {
            List<Worker> workers = new List<Worker>();
            workers = brigade.GetWorkers();
            int LengIndex = workers.Count;
            for (int i = 0; i < LengIndex - 1; i++)
            {
                for (int j = 0; j < LengIndex - 1 - i; j++)
                {
                    if (workers[j].Hours < workers[j + 1].Hours)
                    {
                        Worker mem = workers[j + 1];
                        workers[j + 1] = workers[j];
                        workers[j] = mem;
                    }
                    if (workers[j].Hours == workers[j + 1].Hours && string.Compare(workers[j].Name, workers[j + 1].Name) > 0)
                    {
                        Worker mem = workers[j + 1];
                        workers[j + 1] = workers[j];
                        workers[j] = mem;
                    }
                }
            }
            foreach (Worker worker in workers)
            {
                if(worker is Master)
                {
                    Console.Write("Master");
                }
                else
                {
                    Console.Write("Apprentice");
                }
                Console.WriteLine($" {worker.Name}, {worker.Hours}");
            }


        }
        static void FFind(string args)
        {
            bool flaf0 = false;
            List<Worker> workers = new List<Worker>();
            workers = brigade.GetWorkers();
            foreach (Worker workera in workers)
            {
                if(workera.Name ==  args)
                {
                    flaf0 = true;
                    if(workera is Master master)
                    {
                        master.Train();
                        break;
                    }
                    else if(workera is Apprentice apprentice)
                    {
                        apprentice.Study();
                        break;
                    }
                    else
                    {

                        Console.WriteLine("Ошибка определения типа работника функции Find"); 
                        flaf0 = true; 
                        break;
                    }
                }

            }
            if(flaf0 == false)
            {
                Console.WriteLine("Имя не находится в списке рабочих");
            }
        }
        static void FOriginal()
        {
            List<Worker> workers = new List<Worker>();
            workers = brigade.GetWorkers();
            foreach(Worker worker in workers)
            {
                if (worker is Master)
                {
                    Console.Write("Master");
                }
                else
                {
                    Console.Write("Apprentice");
                }
                Console.WriteLine($" {worker.Name}, {worker.Hours}");
            }
        }
    }

    class Worker
    {
        public string Name { get; protected set; }
        public int Hours { get; protected set; }
        public Worker(string name, int hours)
        {
            Name = name;
            Hours = hours;
        }
        protected void AddHours(int amount)
        {
            Hours += amount;
        }
    }
    class Master : Worker
    {
        protected int _experience;
        public Master( string name, int hours) :  base(name, hours) { }
        public void Train()
        {
            _experience++;
            if (_experience % 3 == 0)
                AddHours(2);
        }
    }
    class Apprentice : Worker
    {
        protected int _stage;
        public Apprentice(string name, int hours) : base(name, hours) { }
        public void Study()
        {
            _stage++;
            AddHours(1);
        }
    }
    class Brigade
    {
        private List<Worker> _workers = new List<Worker>();
        public Brigade(List<Worker> workers)
        {
            _workers = workers;
        }
        public void Add(Worker worker)
        {
            _workers.Add(worker);
        }
        public List<Worker> GetWorkers()
        {

            return new List<Worker>(_workers);
        }
        public int GetTotalHours()
        {
            int _sumHours =0;
            foreach (Worker worker in _workers)
            {
                _sumHours += worker.Hours;
            }
            return _sumHours;
        }

    }
}

    

