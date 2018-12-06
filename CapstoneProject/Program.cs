using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinchAPI;
using static System.Net.Mime.MediaTypeNames;

namespace CapstoneProject
{
    class Program
    {
        public static object DisplayGetMagicSource { get; private set; }

        static void Main(string[] args)
        {
            //************************************
            //Title: Final Capstone Project
            //Application Type: Console App
            //Description: Text Based Adventure Game
            //Author: Christos Piliafas
            //Date Created: December 1st, 2018
            //Last Modified: December 6th, 2018
            //************************************
            
            //
            // list variables here
            //
            string userName;
            string magicType;
            string magicSource;
            string userSpecies;
            string companion;
            int powerLevel;
            Finch edi = new Finch();
 
            //
            // instantiate list of allies
            //
            List<string> allies = new List<string>();
            allies.Add("Barik the Barbarian");
            allies.Add("Vivian the Mage");
            allies.Add("Gary the Golem");
            allies.Add("Alice the Rogue");
            

            //
            // methods
            //
            DisplayInitializeFinch(edi);
            DisplayOpeningScreen();
            userName = DisplayGetUserName();
            powerLevel = DisplayGetAgeAndMagicPower();
            magicType = DisplayGetMagicType();
            magicSource = DisplayGetSourceofMagic(magicType);
            userSpecies = DisplayGetSpecies();
            companion = DisplayGetCompanion(userName, userSpecies, magicType, powerLevel, magicSource);
            DisplayPhase1(userSpecies, companion, powerLevel, magicType, edi);
            DisplayPhase2(companion, edi);
            DisplayPhase3(edi);
            DisplayFinalPhase(powerLevel, companion, userName, userSpecies, magicType, edi);
            DisplayClosingScreen(edi);
            //DisplayGameOver(edi);
            //DisplayWin(edi);
        }

        static void DisplayWin(Finch edi)
        {
            edi.setLED(0, 255, 0);
            edi.noteOn(150);
            edi.wait(3000);
            edi.setLED(0, 0, 0);
            edi.noteOff();
            Console.WriteLine("You win!");
            Console.ReadKey();
        }

        static void DisplayFinalPhase(int powerLevel, string companion, string userName, string userSpecies, string magicType, Finch edi)
        {
            string ally;
            //
            //
            // begin final level
            Console.Clear();
            Console.WriteLine("\t\t Final Level");
            Console.WriteLine();

            Console.WriteLine("You travel to the gates of your kingdom, where you run into 4 of your friends who have fought alongside you in the past.");
            Console.WriteLine("Unfortunately, the evil sorcerer turned three of them into chickens. Leaving them unable to fight.");
            Console.WriteLine("You can only bring one ally to the final battle, choose your ally.");
            Console.WriteLine();
            Console.WriteLine("\tA) Barik the Barbarian");
            Console.WriteLine("\tB) Vivian the Mage");
            Console.WriteLine("\tC) Gary the Golem");
            Console.WriteLine("\tD) Alice the Rogue");
            Console.WriteLine();
            Console.Write("Please enter choice (Barik, Vivian, Gary, Alice).");

            ally = Console.ReadLine();

            switch (ally)
            {
                case "Barik":
                case "barik":
                    Console.WriteLine();
                    Console.WriteLine("You choose Barik.");
                    Console.WriteLine("Barik is an ogre who goes way back with you in the day. He fights with an axe. And despite his size, was able to luckily avoid the evil sorcerer.");
                    Console.WriteLine("You two head off into battle.");
                    Console.ReadKey();
                    break;
                case "Vivian":
                case "vivian":
                    Console.WriteLine();
                    Console.WriteLine("You choose Vivian.");
                    Console.WriteLine("Vivian is another mage who used to go to the same wizarding school as you, and you became her study buddy.");
                    Console.WriteLine("She reflected the sorcerer's magic and avoided the humiliating curse. But turned a tree into a chicken in the process.");
                    Console.WriteLine("You two head off into battle.");
                    Console.ReadKey();
                    break;
                case "Gary":
                case "gary":
                    Console.WriteLine();
                    Console.WriteLine("You choose Gary.");
                    Console.WriteLine("Gary is a grumpy stone golem with an embarassing first name. His stone body prevented the sorcerer's evil curse.");
                    Console.WriteLine("You two head off into battle.");
                    Console.ReadKey();
                    break;
                case "Alice":
                case "alice":
                    Console.WriteLine();
                    Console.WriteLine("You choose Alice.");
                    Console.WriteLine("Alice is an elf thief who wields daggers. You once caught her trying to steal from you but somehow ended up as friends when you saw potential for good in her.");
                    Console.WriteLine("Her quick speed made her able to evade the sorcerer's magic.");
                    Console.WriteLine("You two head off into battle.");
                    Console.ReadKey();
                    break;
                default:
                    break;
            }
            if (powerLevel >= 90)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine($"You, your {companion}, and {ally} were able to overpower the sorcerer and defeat him once and for all.");
                Console.WriteLine("All the destruction magically disappeared when the sorcerer died. And everything returned to normal.");
                Console.WriteLine($"Everyone then knew the legend of {userName} the {userSpecies} who used their {magicType} to defeat the sorcerer.");
                Console.WriteLine($"You, your {companion}, your friend {ally} will be remembered forever as the protectors of your kingdom.");
                DisplayWin(edi);
                DisplayClosingScreen(edi);
            }
            else if (powerLevel < 90)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("You were overpowered by the sorcerer and died.");
                Console.WriteLine("Your kingdom was destroyed and everything became terrible.");
                DisplayGameOver(edi);
                DisplayClosingScreen(edi);
            }
            Console.ReadKey();
        }

        static void DisplayPhase3(Finch edi)
        {
            string menuChoice;
            //
            //
            // begin level 3
            Console.Clear();
            Console.WriteLine("\t\t Level 3");
            Console.WriteLine();
            Console.WriteLine("After escaping the castle, you head off into the marketplace to check on the villagers.");
            Console.WriteLine("You hear a cry for help coming from one of the 5 nearby buildings that are all on fire.");
            Console.WriteLine("You're not sure which building you hear the cry from, but you need to be fast and select only one.");
            Console.WriteLine();
            Console.WriteLine("\tA) Bakery");
            Console.WriteLine("\tB) Armory");
            Console.WriteLine("\tC) Schoolhouse");
            Console.WriteLine("\tD) The Tavern");
            Console.WriteLine("\tE) The Library");
            Console.WriteLine();
            Console.Write("Please enter choice (A, B, C, D, E).");

            menuChoice = Console.ReadLine();

            switch (menuChoice)
            {
                case "A":
                case "a":
                    Console.WriteLine();
                    Console.WriteLine("There was nobody in the bakery, everyone already escaped!");
                    Console.WriteLine("Unfortunately, whoever needed your help wasn't able to escape.");
                    DisplayGameOver(edi);
                    DisplayClosingScreen(edi);
                    break;
                case "B":
                case "b":
                    Console.WriteLine();
                    Console.WriteLine("The armory is empty!");
                    Console.WriteLine("Whoever needed your help wasn't able to escape.");
                    DisplayGameOver(edi);
                    DisplayClosingScreen(edi);
                    break;
                case "C":
                case "c":
                    Console.WriteLine();
                    Console.WriteLine("Fortunately, the schoolhouse is empty.");
                    Console.WriteLine("Unfortunately, whoever needed your help is dead.");
                    DisplayGameOver(edi);
                    DisplayClosingScreen(edi);
                    break;
                case "D":
                case "d":
                    Console.WriteLine();
                    Console.WriteLine("Inside the tavern, you find a helpless old lady trapped under debri.");
                    Console.WriteLine("You lift up the debri and find out that she isn't injured, but is having trouble breathing.");
                    Console.WriteLine("You lift her up and bring her outside the tavern safely, and leave her to the medics.");
                    Console.WriteLine("You look on ahead and discover a bunch of mayhem going on near the gate.");
                    Console.WriteLine("You head off to finish this once and for all!");
                    Console.ReadKey();
                    break;
                case "E":
                case "e":
                    Console.WriteLine();
                    Console.WriteLine("The library was closed today, nobody was even there to begin with.");
                    Console.WriteLine("Sadly, whoever needed your help, it's too late for them now.");
                    DisplayGameOver(edi);
                    DisplayClosingScreen(edi);
                    break;
                default:
                    break;
            }
        }

        static void DisplayPhase2(string companion, Finch edi)
        {
            string answer;
            //
            //
            // begin level 2
            Console.Clear();
            Console.WriteLine("\t\t Level 2");
            Console.WriteLine();
            Console.WriteLine("You travel downstairs, but discover the door to outside the castle is locked!");
            Console.WriteLine("You look around and find a witch, she cackles loudly and tells you that you can't escape, and that the key is hidden.");
            Console.WriteLine("What do you do?");
            Console.Write("ATTACK, SEND, RUN");
            answer = Console.ReadLine();

            if (answer == "attack")
            {
                Console.WriteLine();
                Console.WriteLine("You try to strike her, but she already predicted your attack and knocked you out. By the time you woke up, the kingdom is destroyed and everything is ruined.");
                Console.ReadKey();
                DisplayGameOver(edi);
                DisplayClosingScreen(edi);
            }
            else if (answer == "send")
            {
                Console.WriteLine();
                Console.WriteLine($"You send out your {companion} and they get the key off the witch, startling her.");
                Console.WriteLine($"With the distraction, you are able to take out the witch and get the key back from your {companion}.");
                Console.WriteLine("With that, you unlock the door and head into the village to save your people!");
                Console.ReadKey();
            }
            else if (answer == "run")
            {
                Console.WriteLine();
                Console.WriteLine("You run away, back into your room like a coward. What kind of warrior are you?");
                Console.WriteLine("Unsurprisingly, the sorcerer takes over and destroys everything.");
                Console.ReadKey();
                DisplayGameOver(edi);
                DisplayClosingScreen(edi);
            }


        }

        static void DisplayGameOver(Finch edi)
        {
            edi.setLED(255, 0, 0);
            edi.noteOn(255);
            edi.wait(3000);
            edi.setLED(0, 0, 0);
            edi.noteOff();
            Console.WriteLine("Game over.");
            Console.WriteLine("We await your return, warrior.");
            Console.ReadKey();
        }

        static void DisplayPhase1(string userSpecies, string companion, int powerLevel, string magicType, Finch edi)
        {
            //
            //
            // begin level 1
            Console.Clear();
            Console.WriteLine("\t\t Level 1");
            Console.WriteLine();
            Console.WriteLine($"You are a {userSpecies} from a fantasy kingdom. You are one of the most powerful warriors in the kingdom.");
            Console.WriteLine("But, one day, a dark sorcerer began releasing monsters and demons into the kingdom in order to take over!");
            Console.WriteLine($"You grab your {companion} and prepare yourself to protect your kingdom!");

            Console.WriteLine();
            Console.WriteLine("You encounter a demon with a hood wielding daggers within your castle. He's small and pretty thin, but very fast and agile.");
            Console.WriteLine("Press any key to determine your fate.");
            Console.ReadKey();

            if (powerLevel >= 60)
            {
                Console.WriteLine();
                Console.WriteLine($"You slay the demon with your {magicType} magic due to your high power level and spare your valuable antiques from destruction in the process. But that's not the end of it.");
                Console.WriteLine("Continue onwards by pressing any key.");
                Console.ReadKey();
            }
            else if (powerLevel < 60)
            {
                Console.WriteLine("You fell to the small demon, and unfortunately the sorcerer was able to take over with the magic warrior dead.");
                DisplayGameOver(edi);
                DisplayClosingScreen(edi);
            }
        }

        static void DisplayClosingScreen(Finch edi)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tThank you for using my app.");
            Console.WriteLine();
            Console.WriteLine("\tPress any key to exit, have a nice day.");
            Console.ReadKey();
            edi.disConnect();
            Environment.Exit(0);
        }

        static string DisplayGetCompanion(string userName, string userSpecies, string magicType, int powerLevel, string magicSource)
        {
            string companion;
            //
            // figure out companion
            //
            Console.WriteLine();
            Console.WriteLine("Would you like to have a small dragon or a griffin as your companion?");
            companion = Console.ReadLine();
            Console.ReadKey();
            if (companion == "dragon")
            {
                Console.WriteLine($"In short, your name is {userName}, you are a {userSpecies}, you dabble in {magicType} as your magic type, and your power level is {powerLevel}, you use a {magicSource}, and your pet companion is a dragon. Awesome! You're set for an adventure!");
            }
            else if (companion == "griffin")
            {
                Console.WriteLine($"In short, your name is {userName}, you are a {userSpecies}, you dabble in {magicType} as your magic type, and your power level is {powerLevel}, you use a {magicSource}, and your pet companion is a griffin. Awesome! You're set for an adventure!");
            }
            else
            {
                Console.WriteLine("Please re-enter answer.");
            }
            Console.ReadKey();

            return companion;
        }

        static string DisplayGetSpecies()
        {
            string userSpecies;
            //
            // figure out species
            //

            Console.WriteLine();
            Console.WriteLine("Would you like to be an elf, orc, or dwarf?");
            userSpecies = Console.ReadLine();
            Console.ReadKey();


            Console.WriteLine();
            Console.WriteLine($"Okay, so you are a {userSpecies}.");
            Console.ReadKey();

            return userSpecies;
        }

        static string DisplayGetSourceofMagic(string magicType)
        {
            string magicSource;
            

            // get magic source
            Console.WriteLine();
            Console.WriteLine("Would you like to use your magic by a staff, a book, or your own hands?");
            magicSource = Console.ReadLine();
            Console.ReadKey();
            if (magicSource == "staff")
            {
                Console.WriteLine("Looks like you use a staff to use " + magicType + " magic.");
            }
            else if (magicSource == "book")
            {
                Console.WriteLine("Looks like you use a book to use " + magicType + " magic.");
            }
            else if (magicSource == "hands")
            {
                Console.WriteLine("Looks like you use your own hands to use " + magicType + " magic.");
            }

            return magicSource;
        }

        static void DisplayInitializeFinch(Finch edi)
        {
            if (edi.connect())
            {
                Console.WriteLine("Finch is connected. Press any key to begin.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Finch is not connected, you won't get the full experience unfortunately. You can still continue anyway.");
                Console.ReadKey();
            }
        }

        static string DisplayGetMagicType()
        {
            string magicType;
            //
            // figure out favorite magic type
            //
            Console.WriteLine();
            Console.Write("What is your type of magic would you like to use?");
            magicType = Console.ReadLine();
            Console.ReadKey();
            Console.WriteLine("Okay, so you will be a master of " + magicType + ".");

            Console.ReadKey();

            return magicType;
        }

        static int DisplayGetAgeAndMagicPower()
        {
            string userResponse;
            int userAge;
            string userResponse2;
            int powerLevel;

            //
            // get user age
            //
            Console.WriteLine();
            Console.Write("What is your age?");
            userResponse = Console.ReadLine();
            userAge = int.Parse(userResponse);
            Console.WriteLine();
            Console.Write("Based on your age, your magic power is equal to " + userAge * 5 + ".");

            //
            // get user magic power number
            //
            Console.WriteLine();
            Console.Write("What was your magic power number? (Look back at the previous question)");
            userResponse2 = Console.ReadLine();
            powerLevel = int.Parse(userResponse2);

            // 
            // continue
            //
            Console.ReadKey();
            return powerLevel;
        }

        static string DisplayGetUserName()
        {
            string userName;

            //
            // get user name
            //
            Console.Write("What is your name, warrior?");
            userName = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine($"{userName}, great to meet you.");
            Console.ReadKey();

            return userName;
        }

        static void DisplayOpeningScreen()
        {
            Console.WriteLine();
            Console.WriteLine("Welcome to the Capstone Project Fantasy Adventure game! Here, you will go on an adventure through a strange world, have fun and good luck on your adventure!");
            Console.WriteLine();
            Console.WriteLine("\tPress any key to continue to your character creation page.");
            Console.ReadKey();

        }
    }
}

