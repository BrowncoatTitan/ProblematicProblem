using System;
using System.Collections.Generic;
using System.Threading;

namespace ProblematicProblem
{
    class Program
    {
        static Random rng = new Random();
        static bool cont = true;
        static List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };



        static void Main(string[] args)
        {
            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");
            string input1 = (Console.ReadLine());
            if (input1.ToLower() == "yes")
            {
                Console.WriteLine();
                Console.Write("We are going to need your information first! What is your name? ");
                string userName = Console.ReadLine();
                Console.WriteLine();
                Console.Write("What is your age? ");
                bool isAge = int.TryParse(Console.ReadLine(), out int userAge);
                Console.WriteLine();
                Console.Write("Would you like to see the current list of activities? Sure/No thanks: ");
                string input2 = Console.ReadLine();
                if (input2.ToLower() == "sure")
                {
                    foreach (string activity in activities)
                    {
                        Console.Write($"{activity} ");
                        //Thread.Sleep(250);
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.Write("Would you like to add any activities before we generate one? yes/no: ");
                    string input3 = (Console.ReadLine());
                    bool addToList = false;
                    Console.WriteLine();
                    if (input3.ToLower() == "yes") { addToList = true; }
                    while (addToList == true)
                    {
                        {
                            Console.Write("What would you like to add? ");
                            string userAddition = Console.ReadLine();
                            activities.Add(userAddition);
                            foreach (string activity in activities)
                            {
                                Console.Write($"{activity} ");
                                //Thread.Sleep(250);
                            }
                            Console.WriteLine();
                            Console.WriteLine("Would you like to add more? yes/no: ");
                            string input4 = Console.ReadLine();
                            if (input4 == "no") { addToList = false; }
                        }
                    }
                }
                bool chooseActivity = true;
                while (chooseActivity == true)
                {
                    Console.Write("Connecting to the database");
                    for (int i = 0; i < 10; i++)
                    {
                        Console.Write(". ");
                        //Thread.Sleep(500);
                    }
                    Console.WriteLine();
                    Console.Write("Choosing your random activity");
                    for (int i = 0; i < 9; i++)
                    {
                        Console.Write(". ");
                        //Thread.Sleep(500);
                    }
                    Console.WriteLine();
                    int randomNumber = rng.Next(activities.Count);
                    string randomActivity = activities[randomNumber];
                    if (userAge < 21 && randomActivity == "Wine Tasting")
                    {
                        int randomNum = rng.Next(activities.Count);
                        string randomAct = activities[randomNumber];
                        Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                        Console.WriteLine("Pick something else!");
                        activities.Remove(randomActivity);
                    }
                    Console.Write($"Ah got it! {userName}, your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? Keep/Redo: ");
                    Console.WriteLine();
                    string input5 =Console.ReadLine();
                    if (input5.ToLower() == "keep") { chooseActivity = false; }
                }
            }
        }
    }
}