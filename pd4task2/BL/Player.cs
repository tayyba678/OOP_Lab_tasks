using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace pd5task2
{
    class Player
    {
        public int Hp;
        public string Name;
        public int MaxHp;
        public int MaxEnergy;
        public double Energy;
        public int Armor;
        public Stats SkillStatistics;
        public Player(string name, int Hp, double energy, int armor)
        {
            this.Hp = Hp;
            Name = name;
            Energy = energy;
            Armor = armor;
        }
        public void UpdateHealth(int newHealth)
        {
            if (newHealth < 0)
            {
                Hp = 0;
            }
            else if (newHealth > MaxHp)
            {
                Hp = MaxHp;
            }
            else
            {
                Hp = newHealth;
            }
        }

        public void UpdateEnergy(int newEnergy)
        {
            if (newEnergy < 0)
            {
                Energy = 0;
            }
            else if (newEnergy > MaxEnergy)
            {
                Energy = MaxEnergy;
            }
            else
            {
                Energy = newEnergy;
            }
        }
        public void UpdateArmor(int newArmor)
        {
            if (newArmor < 0)
            {
                Armor = 0;
            }
            else
            {
                int maxArmor = 100;
                if (newArmor > maxArmor)
                {
                    Armor = maxArmor;
                }
                else
                {
                    Armor = newArmor; 
                }
            }
        }
        public void UpdateName(string newName)
        {
            Name = newName;
        }
        public void LearnSkill(Stats skillStats)
        {
            SkillStatistics = skillStats;
        }
        public string Damage(Player armor)
        {
            int effect = armor.Armor - SkillStatistics.Penetration;

            if (SkillStatistics.Cost < 0 || SkillStatistics.Cost > 100)
            {
                return null;
            }
            Energy -= SkillStatistics.Cost;
            double damage = SkillStatistics.Damage * ((100 - effect) / 100);
            armor.UpdateHealth(armor.Hp - (int)damage);
            string attackString = $"{Name} used {SkillStatistics.attack}, {SkillStatistics.Description}, against {armor.Name}, doing {damage:F2} damage!";
            if (SkillStatistics.Heal > 0)
            {
                UpdateHealth(Hp + SkillStatistics.Heal);
                attackString += $" {Name} healed for {SkillStatistics.Heal} health!";
            }
            if (armor.Hp <= 0)
            {
                attackString += $" {armor.Name} died.";
            }
            else
            {
                attackString += $" {armor.Name} is at {((double)armor.Hp / armor.MaxHp) * 100:F2}% health.";
            }

            return attackString;
        }

    }

}
