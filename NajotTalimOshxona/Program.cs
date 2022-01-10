using System.Threading.Tasks;
using System;
using NajotTalimOshxona.Repositories.AdminSideRepositories;
using System.Media;


namespace NajotTalimOshxona
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Enterance();
        }

        public static async void Enterance()
        {
            Console.Write("Welcome Sir. Can you Enter your password\n>>> ");
            while (true)
            {
                AdminEnterface adminEnterface = new AdminEnterface();
                bool permission = adminEnterface.Password();

                if (permission is true)
                {
                    SoundPlayer player = new SoundPlayer(@"../../../Media\Sounds\acceptsound.wav");
                    player.PlaySync();
                    Console.Clear();
                    while (true)
                    {
                    label:
                        Console.WriteLine("(1) ShowMenu\t\t(2) AddFood\n(3) ChangeCost\t\t(4) ChangeFoodStatus");
                        Console.Write(">>> ");

                        int choice = 0;

                        if (int.TryParse(Console.ReadLine(), out choice))
                        {
                            #region ShowFood
                            if (choice == 1)
                            {
                                Console.Clear();
                                adminEnterface.Showmenu();
                            }
                            #endregion

                            #region AddFood
                            else if (choice == 2)
                            {
                                try
                                {
                                    bool togo = await adminEnterface.AddFoodAsync();
                                    if (togo is true) goto label;
                                }
                                catch
                                {
                                    SoundPlayer player1 = new SoundPlayer(@"../../../Media\Sounds\wrongbutton.wav");
                                    player1.PlaySync();
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("\n\nAn error occured :(");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("Press any keyboard to continue\n>>> ");
                                    Console.ReadKey();
                                    Console.Clear();
                                }

                            }
                            #endregion

                            #region ChangeCost
                            else if (choice == 3)
                            {
                                try
                                {
                                    bool togo = await adminEnterface.ChangeCostAsync();
                                    if (togo is true) goto label;
                                }
                                catch

                                {
                                    SoundPlayer player1 = new SoundPlayer(@"../../../Media\Sounds\wrongbutton.wav");
                                    player1.PlaySync();
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("\n\nAn error occured :(");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("Press any keyboard to continue\n>>> ");
                                    Console.ReadKey();
                                    Console.Clear();
                                }

                            }

                            #endregion

                            #region ChangeStatus
                            else if (choice == 4)
                            {
                                try
                                {
                                    bool togo = await adminEnterface.ChangeFoodStatus();
                                    if (togo is true) goto label;
                                }
                                catch
                                {
                                    SoundPlayer player1 = new SoundPlayer(@"../../../Media\Sounds\wrongbutton.wav");
                                    player1.PlaySync();
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("\n\nAn error occured :(");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("Press any keyboard to continue\n>>> ");
                                    Console.ReadKey();
                                    Console.Clear();
                                }

                            }
                            #endregion
                        }
                        else
                        {
                            Console.Clear();
                            SoundPlayer player1 = new SoundPlayer(@"../../../Media\Sounds\wrongbutton.wav");
                            player1.PlaySync();
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Incorrect input, Please try again :(\n>>> ");
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                    }
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("Incorrect password please try again :(\n>>> ");
                    SoundPlayer player = new SoundPlayer(@"../../../Media\Sounds\errorsound.wav");
                    player.PlaySync();
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

        }

        
    }
}