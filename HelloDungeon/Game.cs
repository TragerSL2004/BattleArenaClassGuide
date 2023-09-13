using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloDungeon
{
    class Game
    {
        //Weapon Struct
        struct Weapon
        {
            public string Name;
            public float Damage;
            public float StaminaUsage;
        }
        //Print player and opponet stats
        void PrintStats(Character character)
        {
            Console.WriteLine("Name: " + character.Name);
            Console.WriteLine("Health: " + character.Health);
            Console.WriteLine("Damage: " + character.Damage + "+" + character.CurrentWeapon.Damage);
            Console.WriteLine("Defense: " + character.Defense);
            Console.WriteLine("Stamina: " + character.Stamina);
            Console.WriteLine("Weapon: " + character.CurrentWeapon.Name);
        }
        //struct for player and opponent
        struct Character
        {
            public string Name;
            public float Health;
            public float Damage;
            public float Defense;
            public float Stamina;
            public Weapon CurrentWeapon;
        }

        bool gameOver = false;
        int currentScene = 0;
        string playerChoice = "";
        
        //Various characters
        Character manWithLargeStick;
        Character manWithAlligator;
        Character gunDude;

        Character player;

        //Damage calculation function
        float Attack(Character attacker,Character defender)
        {
            float totalDamage = attacker.Damage + attacker.CurrentWeapon.Damage - defender.Defense;
            return defender.Health - totalDamage;
        }

        //Combat loop
        void Fight(ref Character Character1, ref Character Character2)
        {
            Console.WriteLine(Character1.Name + " yeets their " +  player.CurrentWeapon.Name + " at " + Character2.Name + "!!!");
            Character2.Health = Attack(Character1, Character2);

            Console.ReadKey(true);
            PrintStats(Character1);
            PrintStats(Character2);

            Console.WriteLine(Character2.Name + " fires on " + Character1.Name + "!!!");
            Character1.Health = Attack(Character2, Character1);

            PrintStats(Character1);
            PrintStats(Character2);
        }
        
        //Heal function
        float Healing(Character healTarget, float healAmount)
        {
            return healTarget.Health + healAmount;
        }
        
        //Character selection menu
        void CharacterSelection()
        {
            Console.WriteLine("Choose your character!");
            Console.WriteLine("1.Florida Man with a large stick");
            Console.WriteLine("2.Florida Man Ultimate");
            Console.WriteLine("3.Dude with a gun");
            Console.Write("> ");
            playerChoice = Console.ReadLine();
            if (playerChoice == "1")
            {
                player = manWithLargeStick;
                currentScene = 1;

            }
            else if (playerChoice == "2")
            {
                player = manWithAlligator;
                currentScene = 1;
            }
            else if (playerChoice == "3")
            {
                player = gunDude;
                currentScene = 1;
            }
            else
            {
                Console.WriteLine("Invalid input");
                Console.ReadKey(true);
                Console.Clear();
            }
        }
        
        //Battle until a character dies
        void BattleScene()
        {
            PrintStats(player);
            playerChoice = "";
            Console.WriteLine("Oh no! You are approached by a dude in a suit holding a gun! What will you do?");
            Console.WriteLine("1.Fight him!");
            Console.WriteLine("2.Defend yourself and pray!");
            playerChoice = Console.ReadLine();

            bool isDefending = false;
            if (playerChoice == "1")
            {
                Fight(ref player, ref gunDude);

                Console.Clear();
            }
            else if (playerChoice == "2")
            {
                Console.Clear();
                isDefending = true;
                player.Defense *= 4f;
                Console.WriteLine("You put your weapon in front of you to guard against the attack!");
                PrintStats(player);
                PrintStats(gunDude);
                Console.WriteLine(gunDude.Name + " won't let up on " + player.Name + "!!!");
                player.Health = Attack(gunDude, player);
                PrintStats(player);
                PrintStats(gunDude);
                Console.ReadKey();
                Console.Clear();
                if (isDefending == true)
                {
                    player.Defense /= 4f;
                }

            }
            if (player.Health <= 0 || gunDude.Health <= 0)
            {
                currentScene = 2;
            }

            //Console.WriteLine("The Florida man chugs his Bud Lite!");
            //Console.WriteLine(Healing(ManWithLargeStick, 35.7f));
        }

        //Winner display screen
        void WinResultScene()
        {
            if (player.Health > 0f && gunDude.Health <= 0f)
            {
                Console.WriteLine("The winner is: " + player.Name);
            }
            else if (gunDude.Health > 0f && player.Health <= 0f)
            {
                Console.WriteLine("The winner is: " + gunDude.Name);
            }
            Console.ReadKey(true);
            Console.Clear();
        }
        
        //Pre-game initilization 
        void Start()
        {
            Weapon TruthStick;
            TruthStick.Name = "Truth Hurts";
            TruthStick.Damage = 50f;
            TruthStick.StaminaUsage = 2f;

            Weapon Alligator;
            Alligator.Name = "Steve the Sentient Alligator Sword";
            Alligator.Damage = 100f;
            Alligator.StaminaUsage = 60f;

            Weapon Gun;
            Gun.Name = "Literally just a gun";
            Gun.Damage = 100f;
            Gun.StaminaUsage = 10f;
            manWithLargeStick.Name = "Florida Man with a large stick";
            manWithLargeStick.Health = 300f;
            manWithLargeStick.Damage = 69.420f;
            manWithLargeStick.Defense = 0.6f;
            manWithLargeStick.Stamina = 10.0f;

            manWithAlligator.Name = "Florida Man Ultimate";
            manWithAlligator.Health = 500f;
            manWithAlligator.Damage = 75f;
            manWithAlligator.Defense = 50f;
            manWithAlligator.Stamina = 60.0f;

            gunDude.Name = "Dude with a gun";
            gunDude.Health = 200f;
            gunDude.Damage = 100f;
            gunDude.Defense = 0f;
            gunDude.Stamina = 100f;

            manWithLargeStick.CurrentWeapon = TruthStick;
            manWithAlligator.CurrentWeapon = Alligator;
            gunDude.CurrentWeapon = Gun;
        }

        void Update()
        {
            if (currentScene == 0)
            {
                CharacterSelection();
            }
            else if (currentScene == 1)
            {
                BattleScene();
            }
            else if (currentScene == 2)
            {
                WinResultScene();
            }
        }

        //Game ending message
        void End()
        {
            Console.WriteLine("Thanks for playing!");
        }
        public void Run()
        {
            Start();

            //Overall game loop
            while (gameOver == false)
            {
                Update();
            }

            //Ending
            End();
        }
    }
}
