using NajotTalimOshxona.Extensions;
using NajotTalimOshxona.IRepositories;
using System;
using System.Media;
using System.Threading.Tasks;

namespace NajotTalimOshxona.Repositories.AdminSideRepositories
{
    internal class AdminEnterface: IAdminEnterface
    {
        public bool Password()
        {
            string code = MyExtensionsPack.HidePass();
            bool permission = MyExtensionsPack.HashCode(code);
            return permission;

        }

        public void Showmenu()
        {
            AdminRepository adminRepository = new AdminRepository();
            adminRepository.ShowMenu();
        }

        public async Task<bool> AddFoodAsync()
        {
        mark:
            AdminRepository adminRepository = new AdminRepository();
            Console.Clear();
            Console.Write("(0) Main menu\nYangi taom nomini kiriting\n>>> ");

            string foodName = Console.ReadLine();
            if (foodName == "0")
            {
                Console.Clear();
                return true;
            }
            Console.WriteLine("\n");

        mark1:
            Console.Clear();
            Console.Write($"(1) Orqaga\t(0) Main menu\n{foodName} ni narxini kiriting\n>>> ");

            double foodCost = double.Parse(Console.ReadLine());
            if (foodCost == 1)
            {
                Console.Clear();
                goto mark;
            }
            else if (foodCost == 0)
            {
                Console.Clear();
                return true;
            }
            Console.WriteLine("\n");

        mark2:
            Console.Clear();
            Console.Write($"(1) Orqaga\t(0) Main menu\n{ foodName}ni fotolinkni bering\n>>> ");

            string photoLink = Console.ReadLine();
            if (photoLink == "1")
            {
                Console.Clear();
                goto mark1;
            }
            else if (photoLink == "0")
            {
                Console.Clear();
                return true;
            }
            Console.WriteLine("\n");

            Console.Clear();
            Console.Write($"(1) Orqaga\t(0) Main menu\n{foodName} ga description bering\n>>> ");

            string description = Console.ReadLine();
            if (description == "1")
            {
                Console.Clear();
                goto mark2;
            }
            else if (description == "0")
            {
                Console.Clear();
                return true;
            }

            adminRepository.AddFood(foodName, foodCost, photoLink, description);

            Console.Clear();
            SoundPlayer player2 = new SoundPlayer(@"../../../Media\Sounds\bomb.wav");
            player2.PlaySync();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Databasega saqlandi :)");
            Program.CallFunction();
            Console.ForegroundColor = ConsoleColor.White;

            return true;
        }

        public async Task<bool> ChangeCostAsync()
        {
        mark:
            AdminRepository adminRepository = new AdminRepository();
            Console.Clear();
            Console.Write("(0) Main menu\nTaom nomini kiriting\n>>> ");

            string foodName = Console.ReadLine();
            if (foodName == "0")
            {
                Console.Clear();
                return true; ;
            }
            Console.WriteLine("\n");

            Console.Clear();
            Console.Write($"(1) Orqaga\t(0) Main menu\n{foodName} ni yangi narxini kiriting\n>>> ");
            double foodCost = double.Parse(Console.ReadLine());

            if (foodCost == 1)
            {
                Console.Clear();
                goto mark;
            }
            else if (foodCost == 0)
            {
                Console.Clear();
                return true;
            }

            adminRepository.ChangeCost(foodName, foodCost);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"{foodName}ni narxi o'zgardi:)");
            Console.ForegroundColor = ConsoleColor.White;
            SoundPlayer player2 = new SoundPlayer(@"../../../Media\Sounds\bomb.wav");
            player2.PlaySync();
            Program.CallFunction();

            return true;
        }

        public async Task<bool> ChangeFoodStatus()
        {
            AdminRepository adminRepository = new AdminRepository();
            Console.Clear();
            Console.Write($"(0) Main menu\nTaom nomini kiriting\n>>> ");

            string foodName = Console.ReadLine();
            if (foodName == "0")
            {
                Console.Clear();
                return true;
            }
            Console.Write("(1) Status True\t(2) Status False\t(0) Main menu\n>>> ");
            int choice = 0;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                if (choice == 1)
                {
                    adminRepository.ChangeFoodStatus(foodName);
                    Console.Clear();

                    SoundPlayer player2 = new(@"../../../Media\Sounds\bomb.wav");
                    player2.PlaySync();
                    Program.CallFunction();

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"{foodName} Status True :)");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (choice == 2)
                {
                    adminRepository.ChangeFoodStatus(foodName, false);
                    Console.Clear();
                    SoundPlayer player2 = new SoundPlayer(@"../../../Media\Sounds\bomb.wav");

                    Program.CallFunction();


                    player2.PlaySync();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"{foodName} Status False :)");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (choice == 0)
                {
                    Console.Clear();
                    return true;
                }

            }
            return true;
        }
    }
}
