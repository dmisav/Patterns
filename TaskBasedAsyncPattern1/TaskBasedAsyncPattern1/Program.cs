using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace TaskBasedAsyncPattern1
{
    /// <summary>
    ///   Shows async execution of VOID methods
    /// </summary>
    internal class Program
    {
        public static void Main()
        {
            var list = new ConcurrentBag<string>();
            string[] dirNames = { ".", ".." };
            List<Task> tasks = new List<Task>();
            foreach (var dirName in dirNames)
            {
                Task t = Task.Run(() =>
                {
                     SomeMethod(dirName, list);
                });
                tasks.Add(t);
            }
            Task.WaitAll(tasks.ToArray());
            foreach (Task t in tasks)
                Console.WriteLine("Task {0} Status: {1}", t.Id, t.Status);

            Console.WriteLine("Number of files read: {0}", list.Count);
            Console.ReadLine();
        }

        private static void SomeMethod(string dirName, ConcurrentBag<string> list)
        {
            foreach (var path in Directory.GetFiles(dirName))
                list.Add(path);
        }

    }
}