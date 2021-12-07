using System;
using System.Collections.Generic;
using System.Threading;

namespace rvip
{
    public class Philosopher
    {
        bool _isHunger;
        readonly string _philosopherName;
        readonly int _number;
        int _time;

        public Philosopher(string name, int number)
        {
            _philosopherName = name;
            _number = number;

        }

        void GetFork(IList<Fork> fork)
        {
            _time = new Random().Next(System.DateTime.Now.Millisecond);

            Console.WriteLine("Философ " + _philosopherName + " ждет вилку" + "\t ({0}мс)", _time);


            var first = _number;
            var second = (_number + 1) % (fork.Count - 1);

            if (fork[first].IsUsing || fork[second].IsUsing) return;

            fork[first].IsUsing = true;
            fork[second].IsUsing = true;

            Console.WriteLine("Философ " + _philosopherName + " обедает" + "\t ({0}мс)", _time);
            Console.WriteLine("Вилки " + (first + 1) + " и " + (second + 1) + " заняты " + "\t ({0}мс)", _time);
            Thread.Sleep(_time);



            fork[first].IsUsing = false;
            fork[second].IsUsing = false;
        }

        public void Start(object obj)
        {
            while (true)
            {
                Thread.Sleep(_time);
                ChangeStatus();
                if (_isHunger)
                    GetFork((List<Fork>)obj);
            }
        }

        void ChangeStatus()
        {
            _isHunger = !_isHunger;
            if (!_isHunger)
                Console.WriteLine("Философ " + _philosopherName + " думает." + "\t ({0}мс)", _time);
        }
    }

    public class Fork
    {
        public bool IsUsing { get; set; }
    }
}
