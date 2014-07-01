using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic;

namespace DynamicLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 6; i++)
            {
                int total = 1;
                for (int k = 0; k < i + 1; k++)
                {
                    total *= 10;
                }
                List<A> values = new List<A>();
                for (int j = 0; j < total; j++)
                {
                    values.Add(new A { PB = new B { Filter = "Filter_" + j } });
                }
                Console.WriteLine("Data:{0};", total);
                DateTime start = DateTime.Now;
                var resu = values.AsQueryable().Where("PB.Filter.Contains(\"Filter_2\") && PB.Filter.Contains(\"Filter_20\")");
                Console.Write("Dynamic:{0};\t", resu.Count());
                Console.Write("Timespan:{0};", (DateTime.Now - start).TotalMilliseconds);

                start = DateTime.Now;
                var resu2 = values.Where(m => m.PB.Filter.Contains("Filter_2") && m.PB.Filter.Contains("Filter_20"));
                Console.Write("Normal:{0};\t", resu2.Count());
                Console.Write("Timespan:{0};", (DateTime.Now - start).TotalMilliseconds);
                Console.WriteLine("\r\n-----------------------------------------------------");
            }

            Console.ReadKey();
        }
    }

    public class A
    {
        public B PB { get; set; }
    }
    public class B
    {
        public string Filter { get; set; }
    }
}
