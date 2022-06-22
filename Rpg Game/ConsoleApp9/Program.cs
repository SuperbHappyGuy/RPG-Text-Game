using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Item
    {
        public string itemName;
        public bool mobDrop = false;
        public bool lootDrop = false;
        public bool eventDrop = false;
        public bool bossDrop = false;
        public bool weapon = false;
        public bool armour = false;
        public bool offHand = false;
        public bool jewl = false;
        public bool consumable = false;
        public bool equipable = false;
        public bool currency = false;
        public int reqHealth = 0;
        public int reqAttack = 0;
        public int reqDefence = 0;
        public int reqStrength = 0;
        public int reqLuck = 0;
        public int reqWisdom = 0;
        public int reqIntelligence = 0;
        public int reqLevel = 0;
    }
    public class Monster
    {
        public string monsterName;
        public int monsterHealth = 1;
        public int maxMonsterHealth = 1;
        public int monsterAttack = 1;
        public int monsterDefence = 0;
        public int monsterStrength = 0;
        public int monsterLuck = 0;
        public int monsterWisdom = 0;
        public int monsterIntelligence = 0;
        public int monsterMiss;
        public bool monsterActive;

        public void MonsterDeath()
        {
            if (monsterHealth > maxMonsterHealth)
            {
                monsterHealth = maxMonsterHealth;
            }
            if (monsterHealth < 0 || monsterHealth == 0)
            {
                monsterHealth = 0;
            }
            if (monsterHealth == 0)
            {
                monsterActive = false;
            }
        }
    }

    public class Player
    {
        public string playerName;
        public int skillPoints = 35;
        public int playerHealth = 10;
        public int maxPlayerHealth = 10;
        public int playerAttack = 1;
        public int playerDefence = 0;
        public int defenceChance = 26;
        public int playerStrength = 0;
        public int playerLuck = 0;
        public int missChance = 26;
        public int playerWisdom = 0;
        public int playerIntelligence = 0;
        public int playerLevel = 1;
        public int neededEXP = 10;
        public int carryEXP = 0;
        public int playerEXP = 0;
        public int playerMiss;
        public bool playerTurn = false;
        public bool playerDefend = false;
        public bool health = false;
        public bool attack = false;
        public bool defence = false;
        public bool strength = false;
        public bool luck = false;
        public bool wisdom = false;
        public bool intelligence = false;
        public bool negative = false;
        public bool gameStarted = false;

        public void PlayerDeath()
        {
            if (playerHealth < 0 || playerHealth == 0)
            {
                playerHealth = 0;
            }
        }

        public void SetSkills(int input, int skill, int skillpoint)
        {
            if (input > skillPoints)
            {
                input = 0;
            }
            if (input > 35 && negative == true)
            {
                input = 0;
            }
            if (input < 0)
            {
                input = 0;
            }

            if (health == true)
            {
                Console.WriteLine("Health:" + (input + playerHealth) + "/" + (input + maxPlayerHealth));
                maxPlayerHealth = input + maxPlayerHealth;
                playerHealth = playerHealth + input;
                health = false;
            }
            if (attack == true)
            {
                Console.WriteLine("Attack:" + (input + playerAttack));
                playerAttack = input + playerAttack;
                attack = false;
            }
            if (defence == true)
            {
                Console.WriteLine("Defence:" + (input + playerDefence));
                playerDefence = input + playerDefence;
                defenceChance = defenceChance - input;
                defence = false;
            }
            if (strength == true)
            {
                Console.WriteLine("Strength:" + (input + playerStrength));
                playerStrength = input + playerStrength;
                strength = false;
            }
            if (luck == true)
            {
                Console.WriteLine("Luck:" + (input + playerLuck));
                playerLuck = input + playerLuck;
                missChance = missChance - input;
                luck = false;
            }
            if (wisdom == true)
            {
                Console.WriteLine("Wisdom:" + (input + playerWisdom));
                playerWisdom = input + playerWisdom;
                wisdom = false;
            }
            if (intelligence == true)
            {
                Console.WriteLine("Intelligence:" + (input + playerIntelligence));
                playerIntelligence = input + playerIntelligence;
                intelligence = false;
                Console.WriteLine("Skill Points:" + (skillpoint - input));
                skillPoints = skillpoint - input;
            }
            else
            {
                Console.WriteLine("Skill Points:" + (skillpoint - input));
                skillPoints = skillpoint - input;
            }
        }
    }
    class Game
    {
        static void Main(string[] args)
        {
            Player player = new Player();

            Monster dino = new Monster();
            Monster rat = new Monster();
            Monster goblin = new Monster();

            Random gen = new Random();

            Item gooDrop = new Item();
            Item battleAxe = new Item();
            Item healthStim = new Item();

            List<string> inventory = new List<string>();

            //Intro to the game
            Console.WriteLine("Welcome to Dungeons!");
            Console.WriteLine("There are 100 floors to this dungeon! Good Luck <3");
            Console.WriteLine("Use the Command 'help' to get a list of commands!");
            //Enter Name
            Console.WriteLine("Who are You?");
            player.playerName = Console.ReadLine();
            if (player.playerName.Length > 16)
            {
                player.playerName = player.playerName.Substring(0, 16);
            }
            //Name loop if text is empty
            if (string.IsNullOrEmpty(player.playerName) || player.playerName == "help" || player.playerName == "start" || player.playerName == "tutorial")
            {
                do
                {
                    Console.WriteLine("That's an odd name? Try another one!");
                    Console.WriteLine("Who are You?");
                    player.playerName = Console.ReadLine();
                    if (player.playerName.Length > 16)
                    {
                        player.playerName = player.playerName.Substring(0, 16);
                    }
                } while (string.IsNullOrEmpty(player.playerName) || player.playerName == "help" || player.playerName == "start" || player.playerName == "tutorial");
            }

            Console.WriteLine("Hello {0}!", player.playerName);

            // Action Command Input loop
            bool commandLoop = true;
            bool a = true;
            bool b = false;
            bool c = false;
            bool d = false;
            bool e = false;
            bool f = false;
            bool g = false;
            bool floorEvent = false;
            bool autoPickUp = false;
            string command;
            string auto;
            int output;
            string someint;
            string givesp;
            int floorCounter = 1;
            int eventCounter = 0;
            int spawn = gen.Next(101);
            int eventChance = gen.Next(101);
            int miniGame = gen.Next(1, 11);
            string guess;
            int dropRate = gen.Next(101);
            int mobDropRate = gen.Next(101);
            int genRed;
            var red = Console.ForegroundColor = ConsoleColor.Red;
            var white = Console.ForegroundColor = ConsoleColor.White;

            //item list
            gooDrop.itemName = "Goo Drop";
            gooDrop.mobDrop = true;
            battleAxe.itemName = "Battle Axe";
            battleAxe.mobDrop = true;
            healthStim.itemName = "Health Stim";

            void StartGame()
            {
                //Console.WriteLine("Player:" + player.playerMiss);
                //Console.WriteLine("Rat:" + rat.monsterMiss);
                //Console.WriteLine("Goblin:" + goblin.monsterMiss);
                //Console.WriteLine("Dino:" + dino.monsterMiss);
                //Console.WriteLine("Defence Chance:" + player.defenceChance);
                //Console.WriteLine("Attack Miss%:" + player.missChance);
                //Console.WriteLine("Event Chance:" + eventChance);
                //Console.WriteLine("Right Answer:" + miniGame);
                GameOver();

                if (player.gameStarted == true)
                {
                    MobDeath();

                    while (player.playerEXP >= player.neededEXP)
                    {
                        LevelUp();
                    }

                    if (dino.monsterActive == false && rat.monsterActive == false && goblin.monsterActive == false)
                    {
                        MiniGame();
                    }

                    if (dino.monsterActive == false && rat.monsterActive == false && goblin.monsterActive == false)
                    {
                        spawn = gen.Next(100);
                    }

                    Console.WriteLine("Floor:" + floorCounter);
                    Console.WriteLine(player.playerName + ": HP:" + player.playerHealth + "/" + player.maxPlayerHealth);

                    if (spawn < 34)
                    {
                        if (dino.monsterActive == false && dino.monsterHealth == 1)
                        {
                            dino.monsterHealth = dino.monsterHealth + 4;
                        }
                        if (dino.monsterActive == false)
                        {
                            dino.monsterAttack = 3;
                        }
                        dino.maxMonsterHealth = 5;
                        Console.WriteLine("Dino: HP:" + dino.monsterHealth + "/" + dino.maxMonsterHealth);
                        dino.monsterActive = true;
                    }
                    else if (spawn > 33 && spawn < 66)
                    {
                        rat.maxMonsterHealth = 1;
                        Console.WriteLine("Rat: HP:" + rat.monsterHealth + "/" + rat.maxMonsterHealth);
                        rat.monsterActive = true;
                    }
                    else if (spawn > 65)
                    {
                        if (goblin.monsterActive == false && goblin.monsterHealth == 1)
                        {
                            goblin.monsterHealth = goblin.monsterHealth + 2;
                        }
                        if (goblin.monsterActive == false)
                        {
                            goblin.monsterAttack = 2;
                        }
                        goblin.maxMonsterHealth = 3;
                        Console.WriteLine("Goblin: HP:" + goblin.monsterHealth + "/" + goblin.maxMonsterHealth);
                        goblin.monsterActive = true;
                    }
                }
            }

            void Inventory()
            {

            }

            void DropRate()
            {

                dropRate = gen.Next(101);
                Console.WriteLine("Drop Rate:" + dropRate);

                /* if (dropRate > 21)
                 {
                     Console.WriteLine("Dropped a Goo Drop!");
                     if (autoPickUp == true)
                     {
                         inventory.Add(gooDrop.itemName);
                     }
                     if (autoPickUp == false)
                     {
                         Console.WriteLine("Do you want to take Goo Drop?");
                         auto = Console.ReadLine();
                         if (auto != "yes" && auto != "no")
                             do
                             {
                                 Console.WriteLine("Do you want to take Goo Drop?");
                                 auto = Console.ReadLine();
                             } while (auto != "yes" && auto != "no");

                         if (auto == "yes")
                         {
                             inventory.Add(gooDrop.itemName);
                         }
                         if (auto == "no")
                         {
                             Console.WriteLine("You threw away the Goo Drop.");
                         }
                     }
                 } */
            }

            void MiniGame()
            {
                eventChance = gen.Next(101);
                if (eventChance < 6)
                {
                    floorEvent = true;
                    eventCounter++;
                    floorCounter++;
                    Console.WriteLine("**Event:" + eventCounter + "**");
                    Console.WriteLine("Guess a number between 1 and 10!");
                    miniGame = gen.Next(1, 11);
                    //Console.WriteLine("Answer:" + miniGame);
                    guess = Console.ReadLine();

                    if (!(int.TryParse(guess, out output)))
                    {
                        do
                        {
                            Console.WriteLine("That's not a number.");
                            Console.WriteLine("Answer:" + miniGame);
                            guess = Console.ReadLine();
                        } while (!(int.TryParse(guess, out output)));
                    }
                    if (int.TryParse(guess, out output))
                    {
                        if (output != miniGame)
                        {
                            Console.WriteLine("Better luck next time.");
                            //StartGame();
                        }
                    }
                    if (output == miniGame)
                    {
                        Console.WriteLine("Congratulations!");
                        player.skillPoints++;
                        floorEvent = false;
                        //StartGame();
                    }
                }
            }
            //**display "Level up" once with multiple levels
            void LevelUp()
            {
                if (player.playerEXP > player.neededEXP)
                {
                    player.carryEXP = player.playerEXP - player.neededEXP;
                    player.playerEXP = player.neededEXP;
                }
                if (player.playerEXP == player.neededEXP)
                {
                    Console.WriteLine("**Level Up!**");
                    player.playerLevel++;
                    player.skillPoints++;
                    player.neededEXP++;
                    player.playerEXP = 0;
                    player.playerEXP = player.playerEXP + player.carryEXP + player.playerIntelligence;
                }
            }

            void GameOver()
            {
                if (player.playerHealth == 0)
                {
                    floorCounter = 1;
                    player.gameStarted = false;

                    player.skillPoints = 35;
                    player.playerHealth = 10;
                    player.maxPlayerHealth = 10;
                    player.playerAttack = 1;
                    player.playerDefence = 0;
                    player.defenceChance = 26;
                    player.playerStrength = 0;
                    player.playerLuck = 0;
                    player.missChance = 26;
                    player.playerWisdom = 0;
                    player.playerIntelligence = 0;
                    player.playerLevel = 1;
                    player.neededEXP = 10;
                    player.carryEXP = 0;
                    player.playerEXP = 0;

                    rat.monsterHealth = rat.maxMonsterHealth;
                    rat.monsterAttack = 1;
                    rat.monsterDefence = 0;
                    rat.monsterStrength = 0;
                    rat.monsterLuck = 0;
                    rat.monsterWisdom = 0;
                    rat.monsterIntelligence = 0;
                    rat.monsterActive = false;

                    goblin.monsterHealth = goblin.maxMonsterHealth;
                    goblin.monsterAttack = 2;
                    goblin.monsterDefence = 0;
                    goblin.monsterStrength = 0;
                    goblin.monsterLuck = 0;
                    goblin.monsterWisdom = 0;
                    goblin.monsterIntelligence = 0;
                    goblin.monsterActive = false;

                    dino.monsterHealth = dino.maxMonsterHealth;
                    dino.monsterAttack = 3;
                    dino.monsterDefence = 0;
                    dino.monsterStrength = 0;
                    dino.monsterLuck = 0;
                    dino.monsterWisdom = 0;
                    dino.monsterIntelligence = 0;
                    dino.monsterActive = false;

                    Console.WriteLine("Welcome to Dungeons!");
                    Console.WriteLine("There are 100 floors to this dungeon! Good Luck <3");
                    Console.WriteLine("Use the Command 'help' to get a list of commands!");
                    Console.WriteLine("Who are You?");
                    player.playerName = Console.ReadLine();
                    if (player.playerName.Length > 16)
                    {
                        player.playerName = player.playerName.Substring(0, 16);
                    }
                    if (string.IsNullOrEmpty(player.playerName) || player.playerName == "help" || player.playerName == "start" || player.playerName == "tutorial")
                    {
                        do
                        {
                            Console.WriteLine("That's an odd name? Try another one!");
                            Console.WriteLine("Who are You?");
                            player.playerName = Console.ReadLine();
                            if (player.playerName.Length > 16)
                            {
                                player.playerName = player.playerName.Substring(0, 16);
                            }
                        } while (string.IsNullOrEmpty(player.playerName) || player.playerName == "help" || player.playerName == "start" || player.playerName == "tutorial");
                    }

                    Console.WriteLine("Hello {0}!", player.playerName);
                }
            }

            void MobDeath()
            {
                if (goblin.monsterHealth == 0 || rat.monsterHealth == 0 || dino.monsterHealth == 0)
                {
                    floorCounter++;
                }
                if (rat.monsterHealth == 0)
                {
                    mobDropRate = gen.Next(101);
                    Console.WriteLine("**Rat Defeated!**");
                    player.playerEXP = player.playerEXP + 1;
                    rat.monsterHealth = rat.monsterHealth + 1;

                    if (mobDropRate <= 21)
                    {
                        DropRate();
                    }
                }
                if (goblin.monsterHealth == 0)
                {
                    mobDropRate = gen.Next(101);
                    Console.WriteLine("**Goblin Defeated!**");
                    player.playerEXP = player.playerEXP + 2;
                    goblin.monsterHealth = goblin.monsterHealth + 1;

                    if (mobDropRate <= 21)
                    {
                        DropRate();
                    }
                }
                if (dino.monsterHealth == 0)
                {
                    mobDropRate = gen.Next(101);
                    Console.WriteLine("**Dino Defeated!**");
                    player.playerEXP = player.playerEXP + 3;
                    dino.monsterHealth = dino.monsterHealth + 1;

                    if (mobDropRate <= 21)
                    {
                        DropRate();
                    }
                }
                LevelUp();
            }

            void MobAttack()
            {
                player.playerTurn = false;

                rat.monsterMiss = gen.Next(100);
                goblin.monsterMiss = gen.Next(100);
                dino.monsterMiss = gen.Next(100);

                if (rat.monsterActive == true)
                {
                    if (rat.monsterMiss < 26)
                    {
                        Console.WriteLine("Rat Missed.");
                        player.playerHealth = player.playerHealth - 0;
                    }
                    else
                    {
                        if (player.playerDefend == true)
                        {
                            player.playerHealth = (player.playerHealth - rat.monsterAttack) + 1;
                        }
                        else
                            player.playerHealth = player.playerHealth - rat.monsterAttack;
                    }
                }
                if (goblin.monsterActive == true)
                {
                    if (goblin.monsterMiss < 26)
                    {
                        Console.WriteLine("Goblin Missed.");
                        player.playerHealth = player.playerHealth - 0;
                    }
                    else
                    {
                        if (player.playerDefend == true)
                        {
                            player.playerHealth = (player.playerHealth - goblin.monsterAttack) + 1;
                        }
                        else
                            player.playerHealth = player.playerHealth - goblin.monsterAttack;
                    }
                }
                if (dino.monsterActive == true)
                {
                    if (dino.monsterMiss < 26)
                    {
                        Console.WriteLine("Dino Missed.");
                        player.playerHealth = player.playerHealth - 0;
                    }
                    else
                    {
                        if (player.playerDefend == true)
                        {
                            player.playerHealth = (player.playerHealth - dino.monsterAttack) + 1;
                        }
                        else
                            player.playerHealth = player.playerHealth - dino.monsterAttack;
                    }
                }

                player.playerTurn = true;
                player.PlayerDeath();
            }

            command = Console.ReadLine();

            do
            {
                if (command == "help")
                {
                    do
                    {
                        Console.WriteLine("-'help'");
                        Console.WriteLine("-'tutorial'");
                        Console.WriteLine("-'start'");
                        Console.WriteLine("-'clear'");
                        Console.WriteLine("-'skills'");
                        Console.WriteLine("-'givesp'");
                        command = Console.ReadLine();
                    } while (command == "help");
                }
                else if (command == "options")
                {
                    do
                    {
                        if (autoPickUp == false)
                        {
                            Console.WriteLine("[1]Auto Pick Up: Off");
                        }
                        else
                        {
                            Console.WriteLine("[1]Auto Pick Up: On");
                        }
                        Console.WriteLine("[2]Text Color:");
                        Console.WriteLine("[3] Back");

                        auto = Console.ReadLine();

                        if (auto != "1" && auto != "2" && auto != "3")
                        {
                            do
                            {
                                Console.WriteLine("Not A Valid Action.");
                                auto = Console.ReadLine();
                            } while (auto != "1" && auto != "2" && auto != "3");
                        }
                        if (auto == "3")
                        {
                            StartGame();
                        }
                        if (auto == "2")
                        {
                            Console.WriteLine("[1]Foreground Color:");
                            Console.WriteLine("[2]Background Color:");

                            auto = Console.ReadLine();

                            if (auto == "1")
                            {
                                Console.WriteLine("What Color Do You Want For Foreground Color?");
                                Console.WriteLine("");
                                Console.WriteLine("[1] Black  [2] White   [3] Gray");
                                Console.WriteLine("[4] Red    [5] Yellow  [6] Green");
                                Console.WriteLine("[7] Blue   [8] Next    [9] Back");
                                auto = Console.ReadLine();

                                if (auto != "1" && auto != "2" && auto != "3" && auto != "4" && auto != "5" && auto != "6" && auto != "7" && auto != "8" && auto != "9")
                                {
                                    do
                                    {
                                        Console.WriteLine("Not A Valid Action.");
                                        auto = Console.ReadLine();
                                    } while (auto != "1" && auto != "2" && auto != "3" && auto != "4" && auto != "5" && auto != "6" && auto != "7" && auto != "8" && auto != "9");
                                }
                                if (auto == "1")
                                {
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    auto = "";
                                }
                                if (auto == "2")
                                {
                                    Console.ForegroundColor = ConsoleColor.White;
                                    auto = "";
                                }
                                if (auto == "3")
                                {
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                }
                                if (auto == "4")
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                }
                                if (auto == "5")
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                }
                                if (auto == "6")
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                }
                                if (auto == "7")
                                {
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                }
                                if (auto == "8")
                                {
                                    Console.WriteLine("[1] Magenta  [2] Cyan   [3] DarkGray");
                                    Console.WriteLine("[4] DarkRed    [5] DarkYellow  [6] DarkGreen");
                                    Console.WriteLine("[7] DarkBlue   [8] Next    [9] Back");
                                    auto = Console.ReadLine();

                                    if (auto != "1" && auto != "2" && auto != "3" && auto != "4" && auto != "5" && auto != "6" && auto != "7" && auto != "8" && auto != "9")
                                    {
                                        do
                                        {
                                            Console.WriteLine("Not A Valid Action.");
                                            auto = Console.ReadLine();
                                        } while (auto != "1" && auto != "2" && auto != "3" && auto != "4" && auto != "5" && auto != "6" && auto != "7" && auto != "8" && auto != "9");
                                    }
                                    if (auto == "1")
                                    {
                                        Console.ForegroundColor = ConsoleColor.Magenta;
                                        auto = "";
                                    }
                                    if (auto == "2")
                                    {
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        auto = "";
                                    }
                                    if (auto == "3")
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkGray;
                                    }
                                    if (auto == "4")
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                    }
                                    if (auto == "5")
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    }
                                    if (auto == "6")
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    }
                                    if (auto == "7")
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                                    }
                                    if (auto == "8")
                                    {
                                        Console.WriteLine("[1] DarkMagenta  [2] DarkCyan  [3] Back");
                                        auto = Console.ReadLine();

                                        if (auto != "1" && auto != "2" && auto != "3")
                                        {
                                            do
                                            {
                                                Console.WriteLine("Not A Valid Action.");
                                                auto = Console.ReadLine();
                                            } while (auto != "1" && auto != "2" && auto != "3");
                                        }
                                        if (auto == "1")
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                            auto = "";
                                        }
                                        if (auto == "2")
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                                            auto = "";
                                        }
                                        if (auto == "3")
                                        {
                                            break;
                                        }
                                    }
                                    if (auto == "9")
                                    {
                                        break;
                                    }
                                }
                                if (auto == "9")
                                {
                                    break;
                                }
                            }
                            if (auto == "2")
                            {
                                Console.WriteLine("What Color Do You Want For Background Color?");
                                Console.WriteLine("");
                                Console.WriteLine("[1] Black  [2] White   [3] Gray");
                                Console.WriteLine("[4] Red    [5] Yellow  [6] Green");
                                Console.WriteLine("[7] Blue   [8] Next    [9] Back");
                                auto = Console.ReadLine();

                                if (auto != "1" && auto != "2" && auto != "3" && auto != "4" && auto != "5" && auto != "6" && auto != "7" && auto != "8" && auto != "9")
                                {
                                    do
                                    {
                                        Console.WriteLine("Not A Valid Action.");
                                        auto = Console.ReadLine();
                                    } while (auto != "1" && auto != "2" && auto != "3" && auto != "4" && auto != "5" && auto != "6" && auto != "7" && auto != "8" && auto != "9");
                                }
                                if (auto == "1")
                                {
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    auto = "";
                                }
                                if (auto == "2")
                                {
                                    Console.BackgroundColor = ConsoleColor.White;
                                    auto = "";
                                }
                                if (auto == "3")
                                {
                                    Console.BackgroundColor = ConsoleColor.Gray;
                                }
                                if (auto == "4")
                                {
                                    Console.BackgroundColor = ConsoleColor.Red;
                                }
                                if (auto == "5")
                                {
                                    Console.BackgroundColor = ConsoleColor.Yellow;
                                }
                                if (auto == "6")
                                {
                                    Console.BackgroundColor = ConsoleColor.Green;
                                }
                                if (auto == "7")
                                {
                                    Console.BackgroundColor = ConsoleColor.Blue;
                                }
                                if (auto == "8")
                                {
                                    Console.WriteLine("[1] Magenta  [2] Cyan   [3] DarkGray");
                                    Console.WriteLine("[4] DarkRed    [5] DarkYellow  [6] DarkGreen");
                                    Console.WriteLine("[7] DarkBlue   [8] Next    [9] Back");
                                    auto = Console.ReadLine();

                                    if (auto != "1" && auto != "2" && auto != "3" && auto != "4" && auto != "5" && auto != "6" && auto != "7" && auto != "8" && auto != "9")
                                    {
                                        do
                                        {
                                            Console.WriteLine("Not A Valid Action.");
                                            auto = Console.ReadLine();
                                        } while (auto != "1" && auto != "2" && auto != "3" && auto != "4" && auto != "5" && auto != "6" && auto != "7" && auto != "8" && auto != "9");
                                    }
                                    if (auto == "1")
                                    {
                                        Console.BackgroundColor = ConsoleColor.Magenta;
                                        auto = "";
                                    }
                                    if (auto == "2")
                                    {
                                        Console.BackgroundColor = ConsoleColor.Cyan;
                                        auto = "";
                                    }
                                    if (auto == "3")
                                    {
                                        Console.BackgroundColor = ConsoleColor.DarkGray;
                                    }
                                    if (auto == "4")
                                    {
                                        Console.BackgroundColor = ConsoleColor.DarkRed;
                                    }
                                    if (auto == "5")
                                    {
                                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                                    }
                                    if (auto == "6")
                                    {
                                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                                    }
                                    if (auto == "7")
                                    {
                                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                                    }
                                    if (auto == "8")
                                    {
                                        Console.WriteLine("[1] DarkMagenta  [2] DarkCyan  [3] Back");
                                        auto = Console.ReadLine();

                                        if (auto != "1" && auto != "2" && auto != "3")
                                        {
                                            do
                                            {
                                                Console.WriteLine("Not A Valid Action.");
                                                auto = Console.ReadLine();
                                            } while (auto != "1" && auto != "2" && auto != "3");
                                        }
                                        if (auto == "1")
                                        {
                                            Console.BackgroundColor = ConsoleColor.DarkMagenta;
                                            auto = "";
                                        }
                                        if (auto == "2")
                                        {
                                            Console.BackgroundColor = ConsoleColor.DarkCyan;
                                            auto = "";
                                        }
                                        if (auto == "3")
                                        {
                                            break;
                                        }
                                    }
                                    if (auto == "9")
                                    {
                                        break;
                                    }
                                }
                                if (auto == "9")
                                {
                                    break;
                                }
                            }
                        }
                        if (auto == "1")
                        {
                            Console.WriteLine("Turn [1]On or [2]Off?");
                            Console.WriteLine("[3] Back");
                            auto = Console.ReadLine();
                            if (auto != "1" && auto != "2" && auto != "3")
                            {
                                do
                                {
                                    Console.WriteLine("Not A Valid Action.");
                                    auto = Console.ReadLine();
                                } while (auto != "1" && auto != "2" && auto != "3");
                            }
                            if (auto == "1")
                            {
                                autoPickUp = true;
                                Console.WriteLine("Auto Pick Up Turned On.");
                            }
                            if (auto == "2")
                            {
                                autoPickUp = false;
                                Console.WriteLine("Auto Pick Up Turned Off.");
                            }
                            if (auto == "3")
                            {
                                break;
                            }
                        }
                        command = Console.ReadLine();
                    } while (command == "options");
                }
                else if (command == "inventory")
                {
                    do
                    {
                        Inventory();
                        command = Console.ReadLine();
                    } while (command == "inventory");
                }
                else if (command == "tutorial")
                {
                    do
                    {
                        Console.WriteLine("PlaceHolder");
                        command = Console.ReadLine();
                    } while (command == "tutorial");
                }
                // Tell if the game started or not
                else if (command == "start" && player.gameStarted == false)
                {
                    do
                    {
                        player.gameStarted = true;
                        StartGame();
                        command = Console.ReadLine();
                    } while (command == "start" && player.gameStarted == false);
                }

                else if (command == "start" && player.gameStarted == true)
                {
                    do
                    {
                        Console.WriteLine("You already started!");
                        command = Console.ReadLine();
                    } while (command == "start" && player.gameStarted == true);
                }
                //attack command
                else if (command == "1" && player.gameStarted == true)
                {
                    player.playerMiss = gen.Next(100);

                    if (goblin.monsterActive == true)
                    {
                        if (player.playerMiss <= player.missChance)
                        {
                            Console.WriteLine(player.playerName + " Missed.");
                            goblin.monsterHealth = goblin.monsterHealth - 0;
                        }
                        else

                            goblin.monsterHealth = goblin.monsterHealth - player.playerAttack;
                        goblin.MonsterDeath();
                    }
                    if (rat.monsterActive == true)
                    {
                        if (player.playerMiss <= player.missChance)
                        {
                            Console.WriteLine(player.playerName + " Missed.");
                            rat.monsterHealth = rat.monsterHealth - 0;
                        }
                        else

                            rat.monsterHealth = rat.monsterHealth - player.playerAttack;
                        rat.MonsterDeath();
                    }
                    if (dino.monsterActive == true)
                    {
                        if (player.playerMiss <= player.missChance)
                        {
                            Console.WriteLine(player.playerName + " Missed.");
                            dino.monsterHealth = dino.monsterHealth - 0;
                        }
                        else

                            dino.monsterHealth = dino.monsterHealth - player.playerAttack;
                        dino.MonsterDeath();
                    }
                    MobAttack();
                    StartGame();

                    command = Console.ReadLine();
                }

                else if (command == "2" && player.gameStarted == true)
                {
                    player.playerMiss = gen.Next(100);

                    if (player.playerMiss <= player.defenceChance)
                    {
                        Console.WriteLine("Defend Failed.");
                        player.playerDefend = false;
                    }
                    else
                    {
                        player.playerDefend = true;
                    }
                    MobAttack();
                    StartGame();

                    command = Console.ReadLine();
                }

                else if (command == "look" && player.gameStarted == true)
                {
                    StartGame();
                    command = Console.ReadLine();
                }
                // Developer commands
                else if (command == "devend")
                {
                    genRed = gen.Next(101);

                    do
                    {
                        if (genRed <= 50)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                        Console.Write("You've Been Eatin By A Grue.");
                        Console.ReadKey();
                        break;
                    } while (command == "devend");
                }
                // Clears text
                else if (command == "clear")
                {
                    do
                    {
                        Console.Clear();
                        command = Console.ReadLine();
                    } while (command == "clear");
                }
                // displays users skill points
                else if (command == "skills" || command == player.playerName)
                {
                    Console.WriteLine("        " + player.playerName + ": " + "Level:" + player.playerLevel);
                    Console.WriteLine("Health:" + player.playerHealth + "/" + player.maxPlayerHealth + " Attack:" + player.playerAttack + " Defence:" + player.playerDefence);
                    Console.WriteLine("Strength:" + player.playerStrength + " Luck:" + player.playerLuck + " Wisdom:" + player.playerWisdom);
                    Console.WriteLine("Intelligence:" + player.playerIntelligence + " Skill Points:" + player.skillPoints);
                    Console.WriteLine("        " + "EXP:" + player.playerEXP + "/" + player.neededEXP);
                    command = Console.ReadLine();
                }
                // for the start of the game, setting all skill points
                else if (command == "setsp" && player.gameStarted == false)
                {
                    player.negative = true;

                    if (a == true)
                    {
                        Console.WriteLine("How many points for Health?");
                        someint = Console.ReadLine();

                        do
                        {
                            if (!(int.TryParse(someint, out output)))
                            {
                                Console.WriteLine("Try again.");
                                Console.WriteLine("How many skill points?");
                                someint = Console.ReadLine();
                            }
                        } while (!(int.TryParse(someint, out output)));

                        if (int.TryParse(someint, out output))
                        {
                            player.health = true;

                            if (player.maxPlayerHealth > 10)
                            {
                                player.skillPoints = (player.skillPoints + player.maxPlayerHealth) - 10;
                                player.maxPlayerHealth = 10;

                                player.playerHealth = 10;
                            }
                            player.SetSkills(output, player.maxPlayerHealth, player.skillPoints);
                            a = false;
                            b = true;
                        }
                    }
                    if (b == true)
                    {
                        Console.WriteLine("How many points for Attack?");
                        someint = Console.ReadLine();
                        do
                        {
                            if (!(int.TryParse(someint, out output)))
                            {
                                Console.WriteLine("Try again.");
                                Console.WriteLine("How many skill points?");
                                someint = Console.ReadLine();
                            }
                        } while (!(int.TryParse(someint, out output)));

                        if (int.TryParse(someint, out output))
                        {
                            player.attack = true;

                            if (player.playerAttack > 1)
                            {
                                player.skillPoints = (player.skillPoints + player.playerAttack) - 1;
                                player.playerAttack = 1;
                            }
                            player.SetSkills(output, player.playerAttack, player.skillPoints);
                            b = false;
                            c = true;
                        }
                    }
                    if (c == true)
                    {
                        Console.WriteLine("How many points for Defence?");
                        someint = Console.ReadLine();
                        do
                        {
                            if (!(int.TryParse(someint, out output)))
                            {
                                Console.WriteLine("Try again.");
                                Console.WriteLine("How many skill points?");
                                someint = Console.ReadLine();
                            }
                        } while (!(int.TryParse(someint, out output)));

                        if (int.TryParse(someint, out output))
                        {
                            player.defence = true;

                            if (player.playerDefence > 0)
                            {
                                player.skillPoints = player.skillPoints + player.playerDefence;
                                player.playerDefence = 0;
                            }
                            player.SetSkills(output, player.playerDefence, player.skillPoints);
                            c = false;
                            d = true;
                        }
                    }
                    if (d == true)
                    {
                        Console.WriteLine("How many points for Strength?");
                        someint = Console.ReadLine();
                        do
                        {
                            if (!(int.TryParse(someint, out output)))
                            {
                                Console.WriteLine("Try again.");
                                Console.WriteLine("How many skill points?");
                                someint = Console.ReadLine();
                            }
                        } while (!(int.TryParse(someint, out output)));

                        if (int.TryParse(someint, out output))
                        {
                            player.strength = true;

                            if (player.playerStrength > 0)
                            {
                                player.skillPoints = player.skillPoints + player.playerStrength;
                                player.playerStrength = 0;
                            }
                            player.SetSkills(output, player.playerStrength, player.skillPoints);
                            d = false;
                            e = true;
                        }
                    }
                    if (e == true)
                    {
                        Console.WriteLine("How many points for Luck?");
                        someint = Console.ReadLine();
                        do
                        {
                            if (!(int.TryParse(someint, out output)))
                            {
                                Console.WriteLine("Try again.");
                                Console.WriteLine("How many skill points?");
                                someint = Console.ReadLine();
                            }
                        } while (!(int.TryParse(someint, out output)));

                        if (int.TryParse(someint, out output))
                        {
                            player.luck = true;

                            if (player.playerLuck > 0)
                            {
                                player.skillPoints = player.skillPoints + player.playerLuck;
                                player.playerLuck = 0;
                            }
                            player.SetSkills(output, player.playerLuck, player.skillPoints);
                            e = false;
                            f = true;
                        }
                    }
                    if (f == true)
                    {
                        Console.WriteLine("How many points for Wisdom?");
                        someint = Console.ReadLine();
                        do
                        {
                            if (!(int.TryParse(someint, out output)))
                            {
                                Console.WriteLine("Try again.");
                                Console.WriteLine("How many skill points?");
                                someint = Console.ReadLine();
                            }
                        } while (!(int.TryParse(someint, out output)));

                        if (int.TryParse(someint, out output))
                        {
                            player.wisdom = true;

                            if (player.playerWisdom > 0)
                            {
                                player.skillPoints = player.skillPoints + player.playerWisdom;
                                player.playerWisdom = 0;
                            }
                            player.SetSkills(output, player.playerWisdom, player.skillPoints);
                            f = false;
                            g = true;
                        }
                    }
                    if (g == true)
                    {
                        Console.WriteLine("How many points for Intelligence?");
                        someint = Console.ReadLine();
                        do
                        {
                            if (!(int.TryParse(someint, out output)))
                            {
                                Console.WriteLine("Try again.");
                                Console.WriteLine("How many skill points?");
                                someint = Console.ReadLine();
                            }
                        } while (!(int.TryParse(someint, out output)));

                        if (int.TryParse(someint, out output))
                        {
                            player.intelligence = true;

                            if (player.playerIntelligence > 0)
                            {
                                player.skillPoints = player.skillPoints + player.playerIntelligence;
                                player.playerIntelligence = 0;
                            }
                            player.SetSkills(output, player.playerIntelligence, player.skillPoints);
                            g = false;
                        }
                    }
                    a = true;
                    player.negative = false;
                    command = Console.ReadLine();
                }
                // for adding to a skill
                else if (command == "givesp")
                {
                    Console.WriteLine("What skill will you add points to?");
                    givesp = Console.ReadLine();

                    if (givesp == "health")
                    {
                        Console.WriteLine("How many skill points?");
                        someint = Console.ReadLine();
                        do
                        {
                            if (!(int.TryParse(someint, out output)))
                            {
                                Console.WriteLine("Try again.");
                                Console.WriteLine("How many skill points?");
                                someint = Console.ReadLine();
                            }
                        } while (!(int.TryParse(someint, out output)));
                        if (int.TryParse(someint, out output))
                        {
                            player.health = true;
                            player.SetSkills(output, player.maxPlayerHealth, player.skillPoints);
                            command = Console.ReadLine();
                        }
                    }
                    else if (givesp == "attack")
                    {
                        Console.WriteLine("How many skill points?");
                        someint = Console.ReadLine();
                        do
                        {
                            if (!(int.TryParse(someint, out output)))
                            {
                                Console.WriteLine("Try again.");
                                Console.WriteLine("How many skill points?");
                                someint = Console.ReadLine();
                            }
                        } while (!(int.TryParse(someint, out output)));
                        if (int.TryParse(someint, out output))
                        {
                            player.attack = true;
                            player.SetSkills(output, player.playerAttack, player.skillPoints);
                            command = Console.ReadLine();
                        }
                    }
                    else if (givesp == "defence")
                    {
                        Console.WriteLine("How many skill points?");
                        someint = Console.ReadLine();
                        do
                        {
                            if (!(int.TryParse(someint, out output)))
                            {
                                Console.WriteLine("Try again.");
                                Console.WriteLine("How many skill points?");
                                someint = Console.ReadLine();
                            }
                        } while (!(int.TryParse(someint, out output)));
                        if (int.TryParse(someint, out output))
                        {
                            player.defence = true;
                            player.SetSkills(output, player.playerDefence, player.skillPoints);
                            command = Console.ReadLine();
                        }
                    }

                    else if (givesp == "strength")
                    {
                        Console.WriteLine("How many skill points?");
                        someint = Console.ReadLine();
                        do
                        {
                            if (!(int.TryParse(someint, out output)))
                            {
                                Console.WriteLine("Try again.");
                                Console.WriteLine("How many skill points?");
                                someint = Console.ReadLine();
                            }
                        } while (!(int.TryParse(someint, out output)));
                        if (int.TryParse(someint, out output))
                        {
                            player.strength = true;
                            player.SetSkills(output, player.playerStrength, player.skillPoints);
                            command = Console.ReadLine();
                        }
                    }

                    else if (givesp == "luck")
                    {
                        Console.WriteLine("How many skill points?");
                        someint = Console.ReadLine();
                        do
                        {
                            if (!(int.TryParse(someint, out output)))
                            {
                                Console.WriteLine("Try again.");
                                Console.WriteLine("How many skill points?");
                                someint = Console.ReadLine();
                            }
                        } while (!(int.TryParse(someint, out output)));
                        if (int.TryParse(someint, out output))
                        {
                            player.luck = true;
                            player.SetSkills(output, player.playerLuck, player.skillPoints);
                            command = Console.ReadLine();
                        }
                    }

                    else if (givesp == "wisdom")
                    {
                        Console.WriteLine("How many skill points?");
                        someint = Console.ReadLine();
                        do
                        {
                            if (!(int.TryParse(someint, out output)))
                            {
                                Console.WriteLine("Try again.");
                                Console.WriteLine("How many skill points?");
                                someint = Console.ReadLine();
                            }
                        } while (!(int.TryParse(someint, out output)));
                        if (int.TryParse(someint, out output))
                        {
                            player.wisdom = true;
                            player.SetSkills(output, player.playerWisdom, player.skillPoints);
                            command = Console.ReadLine();
                        }
                    }

                    else if (givesp == "intelligence")
                    {
                        Console.WriteLine("How many skill points?");
                        someint = Console.ReadLine();
                        do
                        {
                            if (!(int.TryParse(someint, out output)))
                            {
                                Console.WriteLine("Try again.");
                                Console.WriteLine("How many skill points?");
                                someint = Console.ReadLine();
                            }
                        } while (!(int.TryParse(someint, out output)));
                        if (int.TryParse(someint, out output))
                        {
                            player.intelligence = true;
                            player.SetSkills(output, player.playerIntelligence, player.skillPoints);
                            command = Console.ReadLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Not A Valid Action.");
                        command = Console.ReadLine();
                    }
                }

                else
                {
                    Console.WriteLine("Not A Valid Action.");
                    command = Console.ReadLine();
                }


            } while (commandLoop == true);

            Console.Write("You've Been Eatin By A Grue. (ERROR)");
            Console.Read();
            Console.ReadKey();

        }
    }
}