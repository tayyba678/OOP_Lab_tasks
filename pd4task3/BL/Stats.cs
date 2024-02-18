using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace pd5task2
{
    class Stats
    {
        public string Name;
        public int Damage;
        public string attack;
        public string Description;
        public double Cost;
        public int Penetration;
        public int Heal;
        public Stats(string attack,int damage, int penetration, int heal, double cost,  string description)
        {
            Damage = damage;
            Description = description;
            Cost = cost;
            Penetration = penetration;
            Heal = heal;
            this.attack = attack;
        }
    }
}
