using System;
using System.Linq;

namespace VarAndLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            Issues issues = new Issues(new Issue[] { new Issue() { Title = "1" }, new Issue() { Title = "1" }, new Issue() { Title = "1" }, new Issue() { Title = "2" }, new Issue() { Title = "3" }, new Issue() { Title = "4" }, new Issue() { Title = "5" } }); ;
            var dd=issues.Where(dat=>dat.Title=="1").ToList();
            foreach (var aa in issues)
            {
                var ss = aa;
            }
        }
    }
}
