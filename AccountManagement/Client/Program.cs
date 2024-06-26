using TournaManagementData;
using TournaManagementModels;
using System;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool active = true;
            while (active)
            {
                {

                    Console.WriteLine("ENZO's MLBB Tournament Registration");
                    Console.WriteLine("What's up?");
                    Console.WriteLine("1.Registration");
                    Console.WriteLine("2.Un - Register");
                    Console.WriteLine("3.Joined Players");


                    Console.WriteLine("Enter the number:");
                    string number = Console.ReadLine();

                    if (number == "1")
                    {
                        Console.WriteLine("What is the IGN?");
                        string name = Console.ReadLine();



                        Console.WriteLine("What is the MLBB ID?");
                        string clWeight = Console.ReadLine();
                        SqlDbData.AddUser(name, clWeight);

                        Console.WriteLine("Okay, thankyou goodluck");

                    }

                    else if (number == "2")
                    {

                        Console.WriteLine("Okay, what's the registered IGN?");
                        string name = Console.ReadLine();
                        SqlDbData.DeleteUser(name);

                        Console.WriteLine("Okay! Betterluck next time!");

                    }
                    else if (number == "3")
                    {
                        Console.WriteLine("Okay, heres the details");
                        Console.WriteLine("");
                        GetUsers();

                    }

                else
                {
                    Console.WriteLine("ERROR");
                }


            }
        }


        }

        public static void GetUsers()
        {
            List<User> usersFromDB = SqlDbData.GetUsers();

            foreach (var item in usersFromDB)
            {
                Console.WriteLine(item.ign);
                Console.WriteLine(item.mlbbid);
            }
        }
    }
}
