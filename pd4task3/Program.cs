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
            List<Player> PlayerObjects = new List<Player>();
            List <Stats> StatisticObjects = new List<Stats> ();
            int ch;
            do
            {
                ch = Menu();
                if (ch == 1)
                {
                    AddPlayer(PlayerObjects);
                }
                else if (ch == 2)
                {
                    AddStatisticSkill(StatisticObjects);
                }
                else if (ch == 3)
                {
                    DisplayPlayer(PlayerObjects)
                }
                else if (ch == 4)
                {
                    Console.WriteLine("Enter Player Name");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter Skill Name");
                    string sname = Console.ReadLine();
                    ViewSkiLL(PlayerObjects, StatisticObjects, name, sname);
                }
                else if(ch == 5)
                {
                    Attack(PlayerObjects);
                }
            } while (ch != 6);
           
        }
        static int Menu()
        {
            Console.WriteLine("1. Add Player");
            Console.WriteLine("2. Add Statistic Skills");
            Console.WriteLine("3. Display Info");
            Console.WriteLine("4. Learn a Skill");
            Console.WriteLine("5. Attack");
            Console.WriteLine("6. Exit");
            int op=int.Parse(Console.ReadLine());
            return op;
        }
        static void AddPlayer(List <Player> PlayerObjects)
        {
            Console.WriteLine("Enter the Player Name");
            string name=Console.ReadLine();
            Console.WriteLine("Enter the Player Health");
            int hp = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Player Max Health");
            int maxhp = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Energy");
            double en = double.Parse(Console.ReadLine());
            Console.WriteLine("Enetr the Max Energy ");
            int maxen = int.Parse(Console.ReadLine());
            Console.WriteLine("enter the Armor");
            int ar = int.Parse(Console.ReadLine());
            Player add=new Player(name,hp,maxhp,en, maxen,ar);
            PlayerObjects.Add(add);
        }
        static void AddStatisticSkill(List <Stats> StatisticObjects)
        {
            Console.WriteLine("Enter Skill Name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Damage amount");
            int dam = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Penetration");
            int pen = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Heal Amount");
            int heal = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the cost");
            double cosr= double.Parse(Console.ReadLine());
            Console.WriteLine("Enter Description");
            string des = Console.ReadLine();
            Stats add=new Stats(name,dam, pen, heal, cosr,des);
            StatisticObjects.Add(add);
        }
        static void DisplayPlayer(List <Player> PlayerObjects)
        {
            foreach(var player in PlayerObjects)
            {
                Console.WriteLine(PlayerObjects[player].Name);
                Console.WriteLine(PlayerObjects[player].Hp);
                Console.WriteLine(PlayerObjects[player].MaxHp);
                Console.WriteLine(PlayerObjects[player].Energy);
                Console.WriteLine(PlayerObjects[player].MaxEnergy);
                Console.WriteLine(PlayerObjects[player].Armor);
            }
        }
        static void ViewSkill(List <Player> PlayerObjects, List<Stats> StatisticObjects,string playername, string skillname)
        {
            foreach (var player in PlayerObjects)
            {
                if (player.Name == playername)
                {
                    Stats skill = null;
                    foreach (var stat in StatisticObjects)
                    {
                        if (stat.Name == skillname)
                        {
                            skill = stat;
                            break;
                        }
                    }
                    if (skill != null)
                    {
                        player.LearnSkill(skill);
                        Console.WriteLine($"{playername} learned the skill {skillname}!");
                    }
                    else
                        Console.WriteLine("Skill not found");
                }
                else
                    Console.WriteLine("No player with that name found");
            }
        }
    
        static void Attack(List<Player> PlayerObjects)
        {
            Console.WriteLine("Choose the attacker from the list:");
            DisplayPlayer(PlayerObjects);
            Console.Write("Enter the name of the attacker: ");
            string attackerName = Console.ReadLine();
            Console.WriteLine("Choose the target from the list:");
            DisplayPlayer(PlayerObjects);
            Console.Write("Enter the name of the target: ");
            string targetName = Console.ReadLine();
            Player attacker = PlayerObjects.Find(p => p.Name == attackerName);
            Player target = PlayerObjects.Find(p => p.Name == targetName);
            if (attacker != null && target != null)
            {
                string attackResult = attacker.Attack(target);
                Console.WriteLine(attackResult);
            }
            else
            {
                Console.WriteLine("Invalid attacker or target. Please make sure both players exist.");
            }
        }
}
