using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace TaskBasedAsyncPattern2
{
/// <summary>
    /// ///   Shows async execution of NON-VOID methods
/// </summary>
    internal class Program
    {
        public static void Main()
        {
            string[] dirNames = { "..." ,"..", "." };
            List<Task<int>> tasks = new List<Task<int>>();
            foreach (var dirName in dirNames)
            {
                Task<int> t = Task<int>.Run(() =>
                {
                    return SomeMethod(dirName);
                });
                tasks.Add(t);
            }
            Task.WaitAll(tasks.ToArray());
            foreach (Task<int> t in tasks)
                Console.WriteLine("Task {0} Status: {1} {2}", t.Id, t.Status, t.Result);
            Console.ReadLine();
        }

        private static int SomeMethod(string dirName)
        {
            return dirName.Length;
        }

    }
}