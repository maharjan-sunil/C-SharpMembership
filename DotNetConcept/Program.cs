using DotNetConcept.Implementation;
using System;

namespace DotNetConcept
{

    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Loading ....");
            CallLongTask();
            Console.ReadKey();
        }

        private async static void CallLongTask()
        {
            LongTask obj = new LongTask();
            var result = obj.GetList();
            var data = result.Result;
            DoOtherTask();
            //foreach(var data in data)
            //{
            //    Console.WriteLine(data);
            //}
            Console.WriteLine("Continue with other and return back to await");
            Console.WriteLine("The End");
        }

        private static void DoOtherTask()
        {
            Console.WriteLine("Do other Task");
        }
    }
}
