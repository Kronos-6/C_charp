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


        }
    }
    class Worker
    {
        protected string _name;
        protected int _hours;
        public Worker(string name, int hours)
        {
            _name = name;
            _hours = hours;
        }
        protected void AddHours(int amount)
        {
            _hours += amount;
        }

    }
    class Master : Worker
    {
        protected int _experience;
        public Master(int experience, string name, int hours) :  base(name, hours)
        {
            _experience = experience;
        }
        public void Train()
        {
            _experience++;
            if (_experience % 3 == 0)
                _hours++;
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
        private List<Worker> _workers;
        public void Add(Worker worker)
        {
            _workers.Add(worker);
        }
        public List<Worker> GetWorkers(List<Worker> workeruser)
        {
            _workers.
            return workeruser;
        }
        public int GetTotalHours()
        {
            
        }

    }





}

    

