using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pd5task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player alice = new Player("Alice", 110, 50, 10);
            Player bob = new Player("Bob", 653, 60, 20);
            Stats fireball = new Stats("fireball", 144, 1.2, 5, 15, "a fiery magical attack");
            alice.LearnSkill(fireball);

            Console.WriteLine(alice.Damage(bob));
            Console.ReadKey();
        }
    }
}
