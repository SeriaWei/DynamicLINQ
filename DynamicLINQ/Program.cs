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
            List<B> values = new List<B>
            {
               new B(){A="All"},
               new B(){A="Al"},
               new B(){A="C"}
            };

            var resu = values.AsQueryable().Where("A.Contains(@0)", "Al");

        }
    }

    public class B
    {
        public string A { get; set; }
    }
}
