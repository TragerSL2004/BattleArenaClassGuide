using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloDungeon
{
    class Game
    {
        void PrintStats(Monster monster)
        {
            Console.WriteLine("Name: " + monster.Name);
            Console.WriteLine("Health: " + monster.Health);
            Console.WriteLine("Damage: " + monster.Damage);
            Console.WriteLine("Defense: " + monster.Defense);
            Console.WriteLine("Stamina: " + monster.Stamina);
        }
        struct Monster
        {

            public string Name;
            public float Health;
            public float Damage;
            public float Defense;
            public float Stamina;

        }

        float Attack(ref Monster attacker, ref Monster defender)
        {
            float totalDamage = attacker.Damage - defender.Defense;
            return defender.Health - totalDamage;
        }
        void Fight(Monster monster1, Monster monster2)
        {

            PrintStats(monster1);
            PrintStats(monster2);

            Console.WriteLine(monster1.Name + " fires on " + monster2.Name + "!!!");
            monster2.Health = Attack(ref monster1,ref monster2);

            Console.ReadKey(true);
            PrintStats(monster1);
            PrintStats(monster2);

            Console.WriteLine(monster2.Name + " thwacks " + monster1.Name + "!!!");
            monster1.Health = Attack(ref monster2,ref monster1);

            PrintStats(monster1);
            PrintStats(monster2);
        }
        float Healing(Monster healTarget, float healAmount)
        {
            return healTarget.Health + healAmount;
        }
        public void Run()
        {
            Monster ManWithLargeStick;
            ManWithLargeStick.Name = "Man with a large stick";
            ManWithLargeStick.Health = 300f;
            ManWithLargeStick.Damage = 69.420f;
            ManWithLargeStick.Defense = 0.6f;
            ManWithLargeStick.Stamina = 10.0f;

            Monster ManWithBiggerStick;
            ManWithBiggerStick.Name = "Man with an EVEN BIGGER stick";
            ManWithBiggerStick.Health = 400f;
            ManWithBiggerStick.Damage = 75f;
            ManWithBiggerStick.Defense = 2f;
            ManWithBiggerStick.Stamina = 20.0f;

            Monster GunDude;
            GunDude.Name = "Dude with a gun";
            GunDude.Health = 200f;
            GunDude.Damage = 100f;
            GunDude.Defense = 0f;
            GunDude.Stamina = 100f;



            Console.WriteLine("The stick man uses his soda!");
            Console.WriteLine(Healing(ManWithLargeStick, 35.7f));
        }
    }
}
