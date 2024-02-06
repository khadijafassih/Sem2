using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDTask3.BL;

namespace PDTask3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Shiritori my_shiritori = new Shiritori();

            my_shiritori.Play("apple");
            my_shiritori.Play("ear");
            my_shiritori.Play("rhino");
            my_shiritori.Play("corn");
            Console.WriteLine("[" + string.Join(", ", my_shiritori.words) + "]");
            Console.WriteLine(my_shiritori.Restart());
            my_shiritori.Play("hostess");
            my_shiritori.Play("stash");
            Console.WriteLine("[" + string.Join(", ", my_shiritori.words) + "]");
            my_shiritori.Play("hostess");
            Console.WriteLine("[" + string.Join(", ", my_shiritori.words) + "]");

            Console.ReadLine();
        }
    }
}
        
