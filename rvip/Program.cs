using System;
using System.Collections.Generic;
using System.Threading;

namespace rvip
{
	class Program
	{
        public static Semaphore Semaphore = new Semaphore(3, 3);
        static readonly List<Fork> Fork = new List<Fork>();
        static readonly List<Philosopher> Ph = new List<Philosopher>();

        static void Main()
        {
            Console.WriteLine("Введите кол-во философов: ");
            var count = Convert.ToInt32(Console.ReadLine());

            for (var i = 0; i < count; i++)
            {
                Fork.Add(new Fork());
                Ph.Add(new Philosopher((i + 1).ToString(), i));
                new Thread(Ph[i].Start).Start(Fork);
            }
        }
    }
}
