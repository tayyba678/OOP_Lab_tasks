
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Business1User;

namespace Business1User
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Logo();
            Console.Clear();
            PrintHeader();
            List<SignUp> usersInfo = new List<SignUp>();
            string path = "C:\\Users\\Hp\\Music\\Semester2nd\\repos\\ConsoleApp5\\ConsoleApp5\\SignUp.txt";
            string choice = "0";
            bool check = UploadList(path, usersInfo);
            if (check)
            {
                Console.WriteLine("Data Loaded Successfully");
            }
            else            
                Console.WriteLine("Data not Loaded");           
            Console.ReadKey();
            do
            {
                Console.Clear();
                choice = AdminMenu();
                Console.Clear();
                if (choice == "1")
                {
                    PrintHeader();
                    LogInLogo();
                    SignUp user = InputwithoutRole();
                    if (user != null)
                    {
                        SignUp info = SignIn(usersInfo, user);
                        if (info == null)
                        {
                            Console.WriteLine("Invalid User");
                        }
                        else if (info.IsAdmin())
                        {
                            Console.WriteLine("Manager Menu");
                        }
                        else
                            Console.WriteLine("No Menu");
                    }
                }
                else if (choice == "2")
                {
                    PrintHeader();
                    SignUpLogo();
                    SignUp user = InputwithRole();
                    if (user != null)
                    {
                        FileHandlingUp(path, user);
                        StoreList(usersInfo, user);
                    }
                }
            }

            while (choice != "3");
            Console.ReadKey();
        }
        static string AdminMenu()
        {
            Console.Clear();
            PrintHeader();
            Welcome();
            string option;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(45, 17);
            Console.WriteLine("1. Sign In");

            Console.SetCursorPosition(45, 18);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("2. Sign Up");

            Console.SetCursorPosition(45, 19);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("3. Exit");

            Console.SetCursorPosition(49, 20);
            Console.WriteLine("Select your Option (only press 1 or 2 or 3): ");
            option = Console.ReadLine();
            return option;
        }
        static SignUp InputwithoutRole()
            {
                    string names, passwords;
                    Console.SetCursorPosition(45, 17);
                    Console.Write("Enter your name: ");
                    names = Console.ReadLine();
                    Console.SetCursorPosition(45, 18);
                    Console.Write("Enter Password: ");
                    passwords = Console.ReadLine();
            if(names!=null&&passwords!=null)
            {
                SignUp user=new SignUp(names,passwords);
                return user;
            }
            return null;
        }
        static SignUp SignIn(List<SignUp> userInfo,SignUp user)
        {
            foreach (SignUp userstored in userInfo)
            {
                if (user.name == userstored.name && user.password == userstored.password)
                {
                    return userstored;
                }
            }
            return null;
        }
        static bool UploadList(string path, List<SignUp> usersInfo)
        {
            if (File.Exists(path))
            {
                StreamReader SignUpfile = new StreamReader(path);
                string record;
                while ((record = SignUpfile.ReadLine()) != null)
                {
                    string name = StoreData(record, 1);
                    string password = StoreData(record, 2);
                    string role = StoreData(record, 3);
                    SignUp user = new SignUp(name, password, role);
                    StoreList(usersInfo,user);
                }
                SignUpfile.Close();
                return true;
            }
            else
            {
                Console.WriteLine("Not exists.");
                return false;
            }
        }
        static void StoreList(List<SignUp> users, SignUp user)
        {
            users.Add(user);
        }
        static void LogInLogo()
        {
            Console.SetCursorPosition(45, 30);
            Console.WriteLine("   _____ _                ____        ");
            Console.SetCursorPosition(45, 31);
            Console.WriteLine("  / ___/(_)___ _____     /  _/___     ");
            Console.SetCursorPosition(45, 32);
            Console.WriteLine("  \\__ \\/ / __ `/ __ \\    / // __ \\   ");
            Console.SetCursorPosition(45, 33);
            Console.WriteLine(" ___/ / / /_/ / / / /  _/ // / / /     ");
            Console.SetCursorPosition(45, 34);
            Console.WriteLine("/____/_/\\__, /_/ /_/  /___/_/ /_/      ");
            Console.SetCursorPosition(45, 35);
            Console.WriteLine("       /____/                          ");
            Console.SetCursorPosition(45, 12);
        }
        static string StoreData(string record, int list)
        {
            int comma = 1;
            string items = "";
            for (int x = 0; x < record.Length; x++)
            {
                if (record[x] == ',')
                {
                    comma++;
                }
                else if (comma == list)
                {
                    items = items + record[x];
                }
            }
            return items;
        }
        static SignUp InputwithRole()
        {
            Console.Clear();
            PrintHeader();
            Welcome();
            string name, password, role;
            Console.SetCursorPosition(45, 17);
            Console.Write("Enter your name: ");
            name = Console.ReadLine();
            Console.SetCursorPosition(45, 18);
            Console.Write("Enter Password: ");
            password = Console.ReadLine();
            Console.SetCursorPosition(45, 20);
            Console.Write("Enter your Role: ");
            role = Console.ReadLine();
            if (name != null && password != null && role != null)
            {
                SignUp s2 = new SignUp(name, password, role);
                return s2;
            }
            return null;

        }
        static void FileHandlingUp(string path, SignUp user)
        {
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(user.name + "," + user.password + "," + user.role);
            file.Flush();
            file.Close();
        }
        static void SignUpLogo()
        {
            Console.SetCursorPosition(45, 30);
            Console.WriteLine("   _____ _                __  __    ");
            Console.SetCursorPosition(45, 31);
            Console.WriteLine("  / ___/(_)___ _____     / / / /___ ");
            Console.SetCursorPosition(45, 32);
            Console.WriteLine("  \\__ \\/ / __ `/ __ \\   / / / / __ \\");
            Console.SetCursorPosition(45, 33);
            Console.WriteLine(" ___/ / / /_/ / / / /  / /_/ / /_/ /");
            Console.SetCursorPosition(45, 34);
            Console.WriteLine("/____/_/\\__, /_/ /_/   \\____/ .___/ ");
            Console.SetCursorPosition(45, 35);
            Console.WriteLine("       /____/              /_/      ");
        }
        static void PrintHeader()
        {

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("                               _   _                               ____                                                ");
            Console.WriteLine("                              | | | |_   _ _ __ ___   __ _ _ __   |  _ \\ ___  ___  ___  _   _ _ __ ___ ___             ");
            Console.WriteLine("                              | |_| | | | | '_ ` _ \\ / _` | '_ \\  | |_) / _ \\/ __|/ _ \\| | | | '__/ __/ _ \\       ");
            Console.WriteLine("                              |  _  | |_| | | | | | | (_| | | | | |  _ <  __/\\__ \\ (_) | |_| | | | (_|  __/          ");
            Console.WriteLine("                              |_| |_|\\__,_|_| |_| |_|\\__,_|_| |_| |_| \\_\\___||___/\\___/ \\__,_|_|  \\___\\___|    ");

            Console.WriteLine("                    __   __                                                  _     ____            _                          ");
            Console.WriteLine("                   |  \\/  | __ _ _ __   __ _  __ _  ___ _ __ ___   ___ _ __ | |_  / ___| _   _ ___| |_ ___ _ __ ___          ");
            Console.WriteLine("                   | |\\/| |/ _` | '_ \\ / _` |/ _` | / _\\  '_ ` _ \\ / _\\ '_ \\| __| \\___ \\| | | / __| __/ _ \\ '_ ` _ \\");
            Console.WriteLine("                   | |  | | (_| | | | | (_| | (_| |  __/ | | | | |  __/ | | | |_   ___) | |_| \\__ \\ ||  __/ | | | | |       ");
            Console.WriteLine("                   |_|  |_|\\___ |_| |_|\\__,_|\\__  |\\___|_| |_| |_|\\___|_| |_|\\__| |____/ \\__, |___/\\__\\___|_| |_| |_|");
            Console.WriteLine("                                             |___/                                       |___/                                ");

        }
        static void Welcome()
        {

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(45, 30);
            Console.WriteLine("  _       __     __                         ");
            Console.SetCursorPosition(45, 31);
            Console.WriteLine(" | |     / /__  / /________  ____ ___  ___ ");
            Console.SetCursorPosition(45, 32);
            Console.WriteLine(" | | /| / / _ \\/ / ___/ __ \\/ __ `__ \\/ _ ");
            Console.SetCursorPosition(45, 33);
            Console.WriteLine(" | |/ |/ /  __/ / /__/ /_/ / / / / / /  __/");
            Console.SetCursorPosition(45, 34);
            Console.WriteLine(" |__/|__/\\___/_/\\___/\\____/_/ /_/ /_/\\___/ ");
        }
        static void Logo()
        {
            Console.Clear();
            PrintHeader();
            Welcome();
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(35, 17);
            Console.WriteLine("*********************************************************");
            Console.SetCursorPosition(35, 18);
            Console.WriteLine("****                      @@            /%           ****");
            Console.SetCursorPosition(35, 19);
            Console.WriteLine("***                    |@@@@\\          /%             ***");
            Console.SetCursorPosition(35, 20);
            Console.WriteLine("***                   _|@@@@\\\\__oooooo/%__            ***");
            Console.SetCursorPosition(35, 21);
            Console.WriteLine("**                      |@@  |      ||                 **");
            Console.SetCursorPosition(35, 22);
            Console.WriteLine("***                     | @@ |      ||                ***");
            Console.SetCursorPosition(35, 23);
            Console.WriteLine("****                    O  @@       ||               ****");
            Console.SetCursorPosition(35, 24);
            Console.WriteLine("*********************************************************");
            Thread.Sleep(2000);
        }
    }
}



