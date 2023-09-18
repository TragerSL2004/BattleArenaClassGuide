using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloDungeon
{
        //Weapon Struct
        struct Weapon
        {
            public string Name;
            public float Damage;
            public float StaminaUsage;
        }
    class Game
    {

        bool gameOver = false;
        int currentScene = 0;
        string playerChoice = "";

        //Various characters
        Character manWithLargeStick;
        Character manWithAlligator;
        Character gunDude;
        Character[] Enemies;
        int currentEnemyIndex = 0;

        Character player;
        int[] numbers = new int[4] { 1, 45, 3, 7};
        int PrintArraySum(int[] numbers)
        {
            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }
            Console.WriteLine(sum);
            return sum;
        }
        void PrintLargestNumber(int[] numbers)
        { 
            int LargestNumber = numbers[0];
            for (int i = 0; i < numbers.Length; i++)
            { 
                if (numbers[i] > LargestNumber)
                {
                    LargestNumber = numbers[i];
                }
            }
            Console.WriteLine(LargestNumber);
        }
        string DisplayMenu(string prompt, string option1, string option2, string option3, string option4)
        {
            playerChoice = "";
            while (playerChoice != "1" && playerChoice != "2" && playerChoice != "3" && playerChoice != "4")
            {
                //Display prompt
                Console.Clear();
                Console.WriteLine(prompt);

                //Display all options
                Console.WriteLine("1." + option1);
                Console.WriteLine("2." + option2);
                if (option3 != "")
                {
                    Console.WriteLine("3." + option3);
                }
                if (option4 != "")
                {
                    Console.WriteLine("4." + option4);
                }
                //Get player input
                Console.Write(">");
                playerChoice = Console.ReadLine();


                if (playerChoice != "1" && playerChoice != "2")
                {
                    if (playerChoice == "3" && option3 != "" || playerChoice == "4" && option4 != "")
                    {
                        continue;
                    }
                    //Incorrect input notification
                    Console.WriteLine("That's not an option, traveler!");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey(true);

                    playerChoice = "";
                }
            }
            return playerChoice;
        }

        //Combat loop
        void Fight(ref Character Character1, ref Character Character2)
        {
            Console.WriteLine(player.GetName() + " yeets their " +  player.GetWeapon().Name + " at " + Character2.GetName() + "!!!");
            Character2.TakeDamage(player.GetDamage());

            Console.ReadKey(true);
            player.PrintStats();
            Character2.PrintStats();

            Console.WriteLine(Character2.GetName() + " fires on " + Character1.GetName() + "!!!");
            Character1.TakeDamage(Character2.GetDamage());
            
            player.PrintStats();
            Character2.PrintStats();
        }
        
        //Heal function
        float Healing(Character healTarget, float healAmount)
        {
            return healTarget.GetHealth() + healAmount;
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
            Console.Clear();
        }
        
        //Battle until a character dies
        void BattleScene()
        {
            player.PrintStats();
            playerChoice = "";
            Console.WriteLine("Oh no! You are approached by a shady dude! What will you do?");
            Console.WriteLine("1.Fight him!");
            Console.WriteLine("2.Defend yourself and pray!");
            Console.WriteLine("3.Chug an ice cold brewski and heal!");
            playerChoice = Console.ReadLine();

            bool isDefending = false;
            if (playerChoice == "1")
            {
                Enemies[currentEnemyIndex].TakeDamage(player.GetDamage());
                Console.Clear();
            }
            else if (playerChoice == "2")
            {
                Console.Clear();
                isDefending = true;
                player.BoostDefense(150f);
                Console.WriteLine("You put your weapon in front of you to guard against the attack!");
                player.PrintStats();
                Console.WriteLine(Enemies[currentEnemyIndex].GetName() + " won't let up on " + player.GetName() + "!!!");
                player.TakeDamage(Enemies[currentEnemyIndex].GetDamage());
                player.PrintStats();
                Enemies[currentEnemyIndex].PrintStats();
                Console.ReadKey();
                Console.Clear();
                if (isDefending == true)
                {
                    player.ResetDefense();
                }

            }
            else if (playerChoice == "3")
            {


                Console.WriteLine("Your Florida man chugs his Bud Lite!");
                Console.WriteLine(Healing(player, 35.7f));

            }
            if (player.GetHealth() <= 0 || Enemies[currentEnemyIndex].GetHealth() <= 0)
            {
                currentScene = 2;
            }
        }

        //Winner display screen
        void WinResultScene()
        {
            //Draws monkey character 
            Console.WriteLine("     __\n" +
                               "w  c(..)o   (\n" +
                               " \\__(-)   __)\n" +
                               "    /|   (\n" +
                               "   /(_)___)\n" +
                               "  w /|\n" +
                               "   \\  \n" +
                               "    m m");

            if (player.GetHealth() > 0f && Enemies[currentEnemyIndex].GetHealth() <= 0f)
            {
                Console.WriteLine("The monkey congratulates: " + player.GetName());
                currentScene = 1;
                currentEnemyIndex++;
            }
            else if (Enemies[currentEnemyIndex].GetHealth() > 0f && player.GetHealth() <= 0f)
            {
                Console.WriteLine("The monkey congratulates: " + Enemies[currentEnemyIndex].GetName());
                currentScene = 3;
            }
            Console.ReadKey(true);
            Console.Clear();
        }
        void EndGameScreen()
        {
            string playerChoice = DisplayMenu("The battles have ended, do you wish to play again?", "1.Yes", "2.No", "", "");
            if (playerChoice == "1")
            { 
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                currentScene = 0;
            }
            else
            {

            }
        }
        
        //Pre-game initilization
        void Start()
        {
            //Florida man with a stick weapon
            Weapon TruthStick;
            TruthStick.Name = "Truth Hurts";
            TruthStick.Damage = 50f;
            TruthStick.StaminaUsage = 2f;

            //Florida man ultimate weapon
            Weapon Alligator;
            Alligator.Name = "Steve the Sentient Alligator Sword";
            Alligator.Damage = 200f;
            Alligator.StaminaUsage = 60f;

            //Gun dude weapon
            Weapon Gun;
            Gun.Name = "Literally just a gun";
            Gun.Damage = 100f;
            Gun.StaminaUsage = 10f;

            manWithLargeStick = new Character("Florida Man with a large stick", 300f, 69.420f, 0.6f, 10.0f, TruthStick);
            
            manWithAlligator = new Character("Florida Man Ultimate", 500f, 75f, 50f, 60.0f, Alligator);

            gunDude = new Character("Florida man with a gun", 200f, 100f, 0f, 100f, Gun);

            Enemies = new Character[3] { manWithLargeStick, gunDude, manWithAlligator };
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
            else if (currentScene == 3)
            {
                EndGameScreen();
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
