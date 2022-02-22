using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;

namespace ProgrammingTasks
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var res = await HackerRank.getUsernames(10);
            
            res.ForEach(x => Console.WriteLine(x));
        }
        
        // private static (int?, int?) FindIndexes(List<int> arr, int target)
        // {
        //     var dict = arr.ToDictionary(key => key, value => arr.IndexOf(value));
        //     
        //     for (var i = 0; i < arr.Count; i++)
        //     {
        //         var num1 = arr[i];
        //         var num2 = target - arr[i];
        //
        //         if(dict.ContainsKey(num2))
        //         {
        //             return (i, dict[num2]);
        //         }
        //     }
        //
        //     return (null, null);
        // }
    }
}