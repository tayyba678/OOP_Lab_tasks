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
        public Player(string name, int hp, int MaxHp,  double Energy, int MaxEnergy, int Armor)
        {
            Name = name;
            Hp = hp;
            this.MaxHp = MaxHp;
            this.Energy = Energy;   
            this.MaxEnergy = MaxEnergy; 
            this.Armor = Armor; 
        }
        public void UpdateHealth(int newHealth)
        {
            Health = Math.Max(0, Math.Min(MaxHealth, newHealth));
        }

        public void UpdateEnergy(double newEnergy)
        {
            Energy = Math.Max(0, Math.Min(MaxEnergy, newEnergy));
        }

        public void UpdateArmor(int newArmor)
        {
            Armor = newArmor;
        }

        public void UpdateName(string newName)
        {
            Name = newName;
        }

        public void LearnSkill(Stats skill)
        {
            SkillStatistics = skill;
        }

        public string Attack(Player target)
        {
            int effectiveArmor = target.Armor - SkillStatistics.Penetration;

            if (SkillStatistics.Cost < 0 || SkillStatistics.Cost > 100)
            {
                return null;
            }

            Energy -= SkillStatistics.Cost;

            double damage = SkillStatistics.Damage * ((100 - effectiveArmor) / 100);
            target.UpdateHealth(target.Health - (int)damage);

            string attackString = $"{Name} used {SkillStatistics.Name}, {SkillStatistics.Description}, against {target.Name}, doing {damage:F2} damage!";

            if (SkillStatistics.Heal > 0)
            {
                UpdateHealth(Health + SkillStatistics.Heal);
                attackString += $" {Name} healed for {SkillStatistics.Heal} health!";
            }

            if (target.Health <= 0)
            {
                attackString += $" {target.Name} died.";
            }
            else
            {
                double targetHealthPercentage = ((double)target.Health / target.MaxHealth) * 100;
                attackString += $" {target.Name} is at {targetHealthPercentage:F2}% health.";
            }

            return attackString;
        }
    }
}
}
