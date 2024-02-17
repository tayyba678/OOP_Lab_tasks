using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAppWeek1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int arrSize = 100;
            string[] userName = new string[arrSize];
            string[] userPassword = new string[arrSize];
            string[] userRole = new string[arrSize];
            int emCount = 0;
            string[] employeeName = new string[arrSize];
            string[] employeeId = new string[arrSize];
            string[] employeeDepartment = new string[arrSize];
            string[] employeeSalary = new string[arrSize];
            const int arraySize = 6;
            string[] managerName = new string[arraySize];
            string[] managerId = new string[arraySize];
            string[] managerSalary = new string[arraySize];
            int managerCount = 0;
            int userCount = 0;
            int loginOption = 0;

            Logo();
            Console.Clear();

            while (loginOption != 3)
            {
                loginOption = LoginPage();

                if (loginOption == 1)
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    string name;
                    string password;
                    string role;

                    PrintHeader();
                    LogIn();

                    Console.SetCursorPosition(45, 15);
                    Console.Write("Enter your Name: ");
                    name = Console.ReadLine();

                    Console.SetCursorPosition(45, 17);
                    Console.Write("Enter your Password: ");
                    password = Console.ReadLine();

                    role = SignIn(name, password, userName, userPassword, userRole, userCount);

                    if (role == "manager" || role == "Manager")
                        Manager(role, ref emCount, employeeName, employeeId, employeeSalary, employeeDepartment, managerName, managerId, managerSalary,ref managerCount);
                    else if (role == "boss" || role == "Boss")
                        Boss(role, ref emCount, employeeName, employeeId, employeeSalary, employeeDepartment, managerName, managerId, managerSalary,ref managerCount);
                    else if (role == "employee" || role == "Employee")
                        EmployeeFunction(role, ref emCount, employeeName, employeeId, employeeSalary, employeeDepartment, managerName, managerId, managerSalary,ref managerCount);
                    else
                    {
                        Console.WriteLine("User not found. Please try again.");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
                else if (loginOption == 2)
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    string name="";
                    string password;
                    string role="";
                    bool invalidInput = true;

                    PrintHeader();
                    SignUp();

                    while (invalidInput == true)
                    {
                        Console.SetCursorPosition(45, 15);
                        Console.Write("1. User name: ");
                        name = Console.ReadLine();

                        if (!(IsValidName(name)))
                        {
                            Console.WriteLine("Invalid input. Please enter only letters.");
                            Console.ReadKey();
                            invalidInput = false;
                        }

                        Console.Clear();

                        if (!(invalidInput))
                        {
                            PrintHeader();
                            SignUp();
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            invalidInput = true;
                        }
                        else
                        {
                            PrintHeader();
                            SignUp();
                            Console.SetCursorPosition(45, 15);
                            Console.Write("1. User name: ");
                            Console.Write(name);
                            invalidInput = false;
                        }
                    }

                    Console.SetCursorPosition(45, 16);
                    bool length = true;
                    Console.Write("2. User Password: ");
                    password = Console.ReadLine();

                    while (length == true)
                    {
                        if (password.Length < 8)
                        {
                            Console.Clear();
                            Console.SetCursorPosition(48, 17);
                            Console.Write("Password should be at least 8 characters. Enter again: ");
                            password = Console.ReadLine();
                            length = true;
                        }
                        else
                        {
                            length = false;
                        }
                    }

                    bool invalidInputRole = true;

                    while (invalidInputRole)
                    {
                        Console.SetCursorPosition(45, 18);
                        Console.Write("3. Role (Boss, Manager, Employee): ");
                        role = Console.ReadLine();

                        if (role != "boss" && role != "Boss" && role != "manager" && role != "Manager" && role != "Employee" && role != "employee")
                        {
                            Console.SetCursorPosition(45, 19);
                            Console.WriteLine("Invalid input.");
                            Console.ReadLine();
                            invalidInputRole = true;
                        }
                        else
                        {
                            invalidInputRole = false;
                        }
                    }

                    bool isValid = SignUpMe(name, password, role, userName, userPassword, userRole, ref userCount, arrSize);

                    if (isValid)
                    {
                        Console.WriteLine("Signed Up Successfully");
                    }

                    if (!isValid)
                    {
                        Console.WriteLine("Warning! Signed Up not Successfully");
                    }

                    Console.ReadKey();
                    Console.Clear();
                }
            }

            
        }
        static void PrintHeader()
        {
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
            Console.WriteLine();
        }

        static void Welcome()
        {
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

        static bool IsValidName(string s)
        {
            foreach (char c in s)
            {
                if (!char.IsLetter(c))
                {
                    return false;
                }
            }
            return true;
        }

        static bool IsValidInteger(string s)
        {
            foreach (char c in s)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        static int LoginPage()
        {
            string op;
            PrintHeader();
            Welcome();
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            int option;
            bool invalidInput = false;

            while (true)
            {
                Console.SetCursorPosition(45, 15);
                Console.WriteLine("1. Sign In");
                Console.SetCursorPosition(45, 16);
                Console.WriteLine("2. Sign Up");
                Console.SetCursorPosition(45, 17);
                Console.WriteLine("3. Exit");
                Console.SetCursorPosition(49, 18);
                Console.Write("Select your Option (only press 1 or 2 or 3): ");
                op = Console.ReadLine();

                if (IsValidInteger(op) && op.Length == 1)
                {
                    option = int.Parse(op);
                    if (option >= 1 && option <= 3)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid option (1, 2, or 3).");
                        Console.ReadLine();
                        invalidInput = true;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid option (1, 2, or 3).");
                    Console.ReadLine();
                    invalidInput = true;
                }
                Console.Clear();

                if (invalidInput)
                {
                    PrintHeader();
                    Welcome();
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    invalidInput = false;
                }
            }

            return option;
        }

        static void LogIn()
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

        static int Manager(string roll, ref int employeeCount, string[] employeeName, string[] employeeId, string[] employeeSalary, string[] employeeDepartment, string[] managerName, string[] managerId, string[] managerSalary, ref int managerCount)
        {

            const int ArraySize = 6;
            const int ArrSize = 100;
            string[] YearsWorked = new string[ArrSize];
            string NamE, Id, Dp;
            const string Filename = "employees.txt";
            int select1;
            Console.Clear();
            PrintHeader();
            ManagerLogo();

            while (true)
            {
                select1 = ManagerMenu();

                switch (select1)
                {
                    case 1:
                        Console.Clear();
                        PrintHeader();
                        ManagerLogo();
                        bool invalidInput = true;

                        while (invalidInput)
                        {
                            Console.WriteLine("Enter Employee Name: ");
                            NamE = Console.ReadLine();

                            if (!IsValidName(NamE))
                            {
                                Console.WriteLine("Invalid input. Please enter only letters.");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.Clear();
                                PrintHeader();
                                ManagerLogo();

                                Console.WriteLine($"Enter Employee Name: {NamE}");
                                Console.WriteLine("Enter Employee Id: ");
                                Id = Console.ReadLine();
                                string m = Id;

                                while (m.Length < 4)
                                {
                                    m = CheckLength(Id);
                                }

                                Console.WriteLine("Enter Employee Department: ");
                                Dp = Console.ReadLine();

                                float salar = SalaryE();
                                string sal = salar.ToString();

                                AddEmployee(NamE, m, Dp, sal, employeeName, employeeId, employeeDepartment, employeeSalary, ref employeeCount, ArrSize, Filename);

                                Console.ReadKey();
                                Console.Clear();
                                invalidInput = false; // Break the loop after required input
                            }
                        }
                        break;

                    case 2:
                        Console.Clear();
                        PrintHeader();
                        ManagerLogo();
                        employeeCount = 0;
                        DisplayEmployee(employeeName, employeeId, employeeDepartment, employeeSalary, ref employeeCount, Filename);
                        Console.Clear();
                        break;

                    case 3:
                        Console.Clear();
                        PrintHeader();
                        ManagerLogo();
                        EmployeeInfo(employeeId, employeeDepartment, employeeCount);
                        Console.Clear();
                        break;

                    case 4:
                        Console.Clear();
                        PrintHeader();
                        ManagerLogo();
                        AverageSalary(Filename);
                        Console.Clear();
                        break;

                    case 5:
                        Console.Clear();
                        PrintHeader();
                        ManagerLogo();
                        IncreaseSalary(employeeId, employeeSalary, employeeCount);
                        Console.Clear();
                        break;

                    case 6:
                        Console.Clear();
                        PrintHeader();
                        ManagerLogo();
                        Console.WriteLine("Enter Employee Id to check ");
                        string idd = Console.ReadLine();
                        CheckTaskByManager(Filename, idd);
                        Console.Clear();
                        break;

                    case 7:
                        Console.Clear();
                        PrintHeader();
                        ManagerLogo();
                        FireEmployee(employeeId, employeeName, employeeDepartment, employeeSalary,ref employeeCount, Filename);
                        Console.Clear();
                        break;

                    case 8:
                        Console.Clear();
                        PrintHeader();
                        ManagerLogo();
                        ExitLogin(ref employeeCount, employeeName, employeeId, employeeSalary, employeeDepartment, ArrSize, managerName, managerId, managerSalary, ref managerCount, ArraySize);
                        Console.Clear();
                        break;

                    default:
                        break;
                }

                if (select1 == 9)
                    break;
            }

            return 0;
        }

        static int ManagerMenu()
        {
            Console.Clear();
            int select1;
            bool isValidInput = false;
            PrintHeader();

            do
            {
                ManagerLogo();
                Console.SetCursorPosition(40, 19);
                Console.WriteLine("1. Add Employee");
                Console.SetCursorPosition(40, 20);
                Console.WriteLine("2. Display All Employees");
                Console.SetCursorPosition(40, 21);
                Console.WriteLine("3. Employees Working Info");
                Console.SetCursorPosition(40, 22);
                Console.WriteLine("4. Calculate Average Salary");
                Console.SetCursorPosition(40, 23);
                Console.WriteLine("5. Increase Salary");
                Console.SetCursorPosition(40, 24);
                Console.WriteLine("6. Check tasks");
                Console.SetCursorPosition(40, 25);
                Console.WriteLine("7. Fire Employee");
                Console.SetCursorPosition(40, 26);
                Console.WriteLine("8. Exit");
                Console.SetCursorPosition(40, 27);
                Console.WriteLine("Enter your choice(1-8): ");
                bool success = int.TryParse(Console.ReadLine(), out select1);

                if (!success)
                {
                    Console.Clear();
                    PrintHeader();
                    ManagerLogo();
                    Console.WriteLine("Invalid input. Please enter a valid option (1-8).");
                    Console.ReadKey();
                }
                else if (select1 < 1 || select1 > 8)
                {
                    Console.Clear();
                    PrintHeader();
                    ManagerLogo();
                    Console.WriteLine("Invalid input. Please enter a valid option (1-8).");
                    Console.ReadKey();
                }
                else
                {
                    isValidInput = true;
                }

            } while (!isValidInput);

            return select1;
        }
        static float SalaryE()
        {
            string salary;
            bool valid = false;

            while (!valid)
            {
                Console.WriteLine("Enter Salary: ");
                salary = Console.ReadLine();

                if (IsValidInteger(salary))
                {
                    valid = true;
                    int salar = int.Parse(salary);
                    return salar;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a positive integer.");
                }
            }
            return 0;
        }


        static void ManagerLogo()
        {
            Console.SetCursorPosition(8, 12);
            Console.WriteLine("     __  ___                  ______          ");
            Console.SetCursorPosition(8, 13);
            Console.WriteLine("    /  |/  /___ _____  ____ _/ ____/__  _____");
            Console.SetCursorPosition(8, 14);
            Console.WriteLine("   / /|_/ / __ `/ __ \\/ __ `/ / __/ _ \\/ ___/");
            Console.SetCursorPosition(8, 15);
            Console.WriteLine("  / /  / / /_/ / / / / /_/ / /_/ /  __/ /    ");
            Console.SetCursorPosition(8, 16);
            Console.WriteLine(" /_/  /_/\\__,_/_/ /_/\\__,_/\\____/\\___/_/     ");
        }

        static void SignUp()
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

       static bool SignUpMe(string name, string password, string role, string[] userName, string[] userPassword, string[] userRole, ref int usersCount, int arrSize)
        {
            if (!IsValidName(name) || password.Length < 8 || !(role.Equals("boss", StringComparison.OrdinalIgnoreCase) || role.Equals("manager", StringComparison.OrdinalIgnoreCase) || role.Equals("employee", StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Invalid input. Please check your data.");
                return false;
            }

            using (StreamWriter userFile = new StreamWriter("users.txt", true))
            {
                userFile.WriteLine($"{name} {password} {role}");
            }

            return true;
        }
        static string SignIn(string name, string password, string[] userName, string[] userPassword, string[] userRole, int userCount)
        {
            using (StreamReader userFile = new StreamReader("users.txt"))
            {
                string line;

                while ((line = userFile.ReadLine()) != null)
                {
                    string[] parts = line.Split(' ');

                    if (parts.Length == 3 && parts[0] == name && parts[1] == password)
                    {
                        return parts[2];
                    }
                }
            }

            return "";
        }

        static void Boss(string roll, ref int employeeCount, string[] employeeName, string[] employeeId, string[] employeeSalary, string[] employeeDepartment, string[] managerName, string[] managerId, string[] managerSalary, ref int managerCount)
        {
            const int arraySize = 6;
            const int arrSize = 100;
            string[] yearsWorked = new string[arrSize];
            string namE, id, dp, salary;
            const string filename = "employees.txt";
            int select2 = 0;

            Console.Clear();
            PrintHeader();
            BossLogo();

            while (select2 != 10)
            {
                select2 = BossMenu();

                if (select2 == 1)
                {
                    Console.Clear();
                    PrintHeader();
                    BossLogo();

                    bool invalidInput = true;

                    while (invalidInput)
                    {
                        Console.WriteLine("Enter Manager Name: ");
                        namE = Console.ReadLine();
                        Console.ReadLine(); // Ignore newline character

                        if (!IsValidName(namE))
                        {
                            Console.WriteLine("Invalid input. Please enter only letters.");
                            Console.ReadLine(); // Pause
                        }
                        else
                        {
                            Console.Clear();
                            PrintHeader();
                            ManagerLogo();
                            Console.ForegroundColor = ConsoleColor.Yellow;

                            Console.WriteLine("Enter Manager Name: " + namE);
                            Console.WriteLine("Enter Manager Id: ");
                            id = Console.ReadLine();
                            string l = id;

                            if (id.Length < 4)
                            {
                                l = CheckLength(id);
                            }

                            float salar = SalaryE();
                            string sal = salar.ToString();

                            AddManager(namE, l, sal, managerName, managerId, managerSalary, ref managerCount, arraySize);

                            Console.ReadLine(); // Pause
                            Console.Clear();
                            invalidInput = false;
                        }
                    }
                }
                else if (select2 == 2)
                {
                    Console.Clear();
                    PrintHeader();
                    BossLogo();
                    DisplayManager(managerName, managerId, managerCount);
                    Console.Clear();
                }
                if (select2 == 3)
                {
                    Console.Clear();
                    PrintHeader();
                    BossLogo();
                    bool invalidInput = true;
                    while (invalidInput)
                    {
                        Console.WriteLine("Enter Employee Name: ");
                        namE = Console.ReadLine();
                        Console.ReadLine(); // Ignore newline character
                        if (!IsValidName(namE))
                        {
                            Console.WriteLine("Invalid input. Please enter only letters.");
                            Console.ReadLine(); // Pause
                        }
                        else
                        {
                            Console.Clear();
                            PrintHeader();
                            ManagerLogo();
                            Console.ForegroundColor = ConsoleColor.Yellow;

                            Console.WriteLine("Enter Employee Name: " + namE);
                            Console.WriteLine("Enter Employee Id: ");
                            id = Console.ReadLine();
                            string l = id;
                            if (id.Length < 4)
                            {
                                l = CheckLength(id);
                            }
                            Console.WriteLine("Enter Employee Department: ");
                            dp = Console.ReadLine();

                            float salar = SalaryE();
                            string sal = salar.ToString();

                            AddEmployee(namE, l, dp, sal, employeeName, employeeId, employeeDepartment, employeeSalary, ref employeeCount, arrSize, filename);

                            Console.ReadLine(); // Pause
                            Console.Clear();
                            invalidInput = false;
                        }
                    }
                }
                else if (select2 == 4)
                {
                    Console.Clear();
                    PrintHeader();
                    BossLogo();
                    employeeCount = 0;
                    DisplayEmployee(employeeName, employeeId, employeeDepartment, employeeSalary, ref employeeCount, filename);
                    Console.Clear();
                }
                else if (select2 == 5)
                {
                    Console.Clear();
                    PrintHeader();
                    BossLogo();
                    TotalSalary(employeeSalary, employeeCount);
                    Console.Clear();
                }
                else if (select2 == 6)
                {
                    Console.Clear();
                    PrintHeader();
                    BossLogo();
                    AverageSalary(filename);
                    Console.Clear();
                }
                else if (select2 == 7)
                {
                    Console.Clear();
                    PrintHeader();
                    BossLogo();
                    GiveBonus(employeeId, employeeSalary, employeeName,employeeCount);
                    Console.Clear();
                }
                else if (select2 == 8)
                {
                    Console.Clear();
                    PrintHeader();
                    BossLogo();
                    FireManager(managerId, managerName, managerSalary, ref managerCount);
                    Console.Clear();
                }
                else if (select2 == 9)
                {
                    Console.Clear();
                    PrintHeader();
                    BossLogo();

                    FireEmployee(employeeId, employeeName, employeeDepartment, employeeSalary, ref employeeCount, filename);
                }
                else if (select2 == 10)
                {
                    Console.Clear();
                    PrintHeader();
                    BossLogo();
                    ExitLogin(ref employeeCount, employeeName, employeeId, employeeSalary, employeeDepartment, arrSize, managerName, managerId, managerSalary, ref managerCount, arraySize);
                    Console.Clear();
                }
            }
        }
        static int BossMenu()
        {
            int select2;
            bool isValidInput = false;

            do
            {
                PrintHeader();
                BossLogo();

                Console.SetCursorPosition(40, 18);
                Console.WriteLine("1. Add Manager");
                Console.SetCursorPosition(40, 19);
                Console.WriteLine("2. View Added Manager");
                Console.SetCursorPosition(40, 20);
                Console.WriteLine("3. Add Employees");
                Console.SetCursorPosition(40, 21);
                Console.WriteLine("4. View Employees");
                Console.SetCursorPosition(40, 22);
                Console.WriteLine("5. View Total Salary Of Employees");
                Console.SetCursorPosition(40, 23);
                Console.WriteLine("6. View Average Salary Of Employees");
                Console.SetCursorPosition(40, 24);
                Console.WriteLine("7. Give Bonus");
                Console.SetCursorPosition(40, 25);
                Console.WriteLine("8. Fire Manager");
                Console.SetCursorPosition(40, 26);
                Console.WriteLine("9. Fire Employees");
                Console.SetCursorPosition(40, 27);
                Console.WriteLine("10. Exit");
                Console.SetCursorPosition(40, 28);
                Console.Write("Enter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out select2))
                {
                    Console.Clear();
                    isValidInput = false;
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else if (select2 < 1 || select2 > 11)
                {
                    Console.Clear();
                    isValidInput = false;
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 11.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    isValidInput = true;
                }
            } while (!isValidInput);

            return select2;
        }
        static string CheckLength(string id)
        {
            Console.WriteLine("Id should contain at least 4 characters. Write again: ");
            Console.ReadLine(); // Clear the input buffer
            id = Console.ReadLine();
            return id;
        }

        static int EmployeeFunction(string roll, ref int employeeCount, string[] employeeName, string[] employeeId, string[] employeeSalary, string[] employeeDepartment, string[] managerName, string[] managerId, string[] managerSalary, ref int managerCount)
        {
            const int arraySize = 6;
            bool a;
            const int arrSize = 100;
            string[] yearsWorkeds = new string[arrSize];
            string namEs, ids, dps, salarys;
            int select3 = 0;

            Console.Clear();
            PrintHeader();
            EmployeeLogo();

            while (select3 != 5)
            {
                select3 = EmployeeMenu();

                if (select3 == 1)
                {
                    Console.Clear();
                    PrintHeader();
                    EmployeeLogo();
                    CheckStatus(employeeName, employeeId, employeeCount);
                    Console.Clear();
                }
                else if (select3 == 2)
                {
                    Console.Clear();
                    PrintHeader();
                    EmployeeLogo();
                    string id;
                    Console.WriteLine("Enter id to check Salary: ");
                    id = Console.ReadLine();
                    DisplaySalary(employeeId, employeeSalary, employeeCount, id);
                    Console.Clear();
                }
                else if (select3 == 3)
                {
                    Console.Clear();
                    PrintHeader();
                    EmployeeLogo();
                    string empid;
                    Console.WriteLine("Enter Employee ID: ");
                    empid = Console.ReadLine();
                    a = UploadTask("employees.txt", empid);

                    if (a)
                    {
                        Console.WriteLine("Upload task function executed successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Upload task function encountered an error.");
                    }

                    Console.Clear();
                }
                else if (select3 == 4)
                {
                    Console.Clear();
                    PrintHeader();
                    EmployeeLogo();
                    string id;
                    Console.WriteLine("Enter id to check Bonus: ");
                    id = Console.ReadLine();
                    CalculateAndDisplayBonus(employeeId, employeeSalary, employeeCount, id);
                    Console.Clear();
                }
                else if (select3 == 5)
                {
                    Console.Clear();
                    PrintHeader();
                    EmployeeLogo();
                    ExitLogin(ref employeeCount, employeeName, employeeId, employeeSalary, employeeDepartment, arrSize, managerName, managerId, managerSalary, ref managerCount, arraySize);
                    Console.Clear();
                }
            }

            return 0;
        }

        static int EmployeeMenu()
        {
            Console.Clear();
            int select3;
            bool isValidInput = false;

            PrintHeader();

            do
            {
                EmployeeLogo();
                Console.SetCursorPosition(40, 19);
                Console.WriteLine("1. Check Status ");
                Console.SetCursorPosition(40, 20);
                Console.WriteLine("2. View Salary Status ");
                Console.SetCursorPosition(40, 21);
                Console.WriteLine("3. Update Work ");
                Console.SetCursorPosition(40, 22);
                Console.WriteLine("4. View Bonus ");
                Console.SetCursorPosition(40, 23);
                Console.WriteLine("5. Exit ");
                Console.SetCursorPosition(40, 24);
                Console.WriteLine("Enter your choice: ");
                select3 = int.Parse(Console.ReadLine());

                if (select3 < 1 || select3 > 5)
                {
                    Console.ReadLine(); // Pause
                }
                else
                {
                    isValidInput = true;
                }
            } while (!isValidInput);

            return select3;
        }
        static void CheckStatus(string[] employeeName, string[] employeeId, int studentCount)
        {
            string name, id;

            Console.WriteLine("Enter Your Name: ");
            Console.ReadLine(); // Clear the input buffer
            name = Console.ReadLine();

            Console.WriteLine("Enter Your Employee ID: ");
            id = Console.ReadLine();

            bool employeeFound = false;

            for (int i = 0; i < studentCount; ++i)
            {
                if (employeeName[i] == name && employeeId[i] == id)
                {
                    Console.WriteLine("\nEmployee Status: Hired");
                    employeeFound = true;
                    break;
                }
            }

            if (!employeeFound)
            {
                Console.WriteLine("\nEmployee Status: Not Hired");
            }

            Console.ReadLine(); // Pause
        }

        static void DisplaySalary(string[] employeeId, string[] employeeSalary, int employeeCount, string id)
        {
            bool employeeFound = false;

            for (int i = 0; i < employeeCount; ++i)
            {
                if (employeeId[i] == id)
                {
                    Console.WriteLine($"Employee ID: {id}");
                    Console.WriteLine($"Salary: {employeeSalary[i]}");
                    employeeFound = true;
                    break;
                }
            }
            if (!employeeFound)
            {
                Console.WriteLine($"Employee with ID {id} not found.");
            }

            Console.ReadLine(); // Pause
        }
        static void CalculateAndDisplayBonus(string[] employeeId, string[] employeeSalary, int employeeCount, string id)
        {
            bool employeeFound = false;

            for (int i = 0; i < employeeCount; ++i)
            {
                if (employeeId[i] == id)
                {
                    Console.WriteLine($"Employee ID: {id}");

                    float salary = float.Parse(employeeSalary[i]);
                    float bonus = 0;

                    if (salary > 50000)
                    {
                        bonus = 0.1f * salary; // 10% bonus if salary is greater than 50000
                        Console.WriteLine($"Bonus: {bonus}");
                        Console.WriteLine($"Original Salary: {salary}");
                        Console.WriteLine($"Salary with Bonus: {salary + bonus}");
                    }
                    else
                    {
                        Console.WriteLine($"No Bonus. Original Salary: {salary}");
                    }

                    employeeFound = true;
                    break;
                }
            }

            if (!employeeFound)
            {
                Console.WriteLine($"Employee with ID {id} not found.");
            }

            Console.ReadLine(); // Pause
        }
        static void BossLogo()
        {
            Console.SetCursorPosition(8, 12);
            Console.WriteLine("    ____                    ");
            Console.SetCursorPosition(8, 13);
            Console.WriteLine("   / __ )____  __________   ");
            Console.SetCursorPosition(8, 14);
            Console.WriteLine("  / __  / __ \\/ ___/ ___/  ");
            Console.SetCursorPosition(8, 15);
            Console.WriteLine(" / /_/ / /_/ (__  |__  )    ");
            Console.SetCursorPosition(8, 16);
            Console.WriteLine("/_____/\\____/____/____/    ");
        }

        static bool AddManager(string name, string id, string salary, string[] managerName, string[] managerId, string[] managerSalary, ref int managerCount, int arraySize)
        {
            for (int index = 0; index < managerCount; index++)
            {
                if (managerId[index] == id)
                {
                    Console.WriteLine($"Employee with ID {id} already exists.");
                    return false;
                }
            }

            if (managerCount < arraySize)
            {
                managerName[managerCount] = name;
                managerId[managerCount] = id;
                managerSalary[managerCount] = salary;
                managerCount++;

                Console.WriteLine($"Manager added successfully. Total manager: {managerCount}");
                return true;
            }
            else
            {
                Console.WriteLine("Manager is not added. Capacity is full.");
                return false;
            }
        }

        static void DisplayManager(string[] managerName, string[] managerId, int managerCount)
        {
            if (managerCount > 0)
            {
                for (int x = 0; x < managerCount; x++)
                {
                    Console.WriteLine($"Manager Name: {managerName[x]}");
                    Console.WriteLine($"Manager Id: {managerId[x]}");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No Manager to display.");
            }

            Console.ReadLine(); // Pause
        }
        static bool AddEmployee(string name, string id, string department, string salary, string[] employeeName, string[] employeeId, string[] employeeDepartment, string[] employeeSalary, ref int studentCount, int arrSize, string filename)
        {
            for (int index = 0; index < studentCount; index++)
            {
                if (employeeId[index] == id)
                {
                    Console.WriteLine($"Employee with ID {id} already exists.");
                    return false;
                }
            }
            using (StreamReader fileIn = new StreamReader(filename))
            {
                string existingId;
                while ((existingId = fileIn.ReadLine()) != null)
                {
                    if (existingId == id)
                    {
                        Console.WriteLine($"Employee with ID {id} already exists in the file.");
                        return false;
                    }
                }
            }
            if (studentCount < arrSize)
            {
                employeeName[studentCount] = name;
                employeeId[studentCount] = id;
                employeeDepartment[studentCount] = department;
                employeeSalary[studentCount] = salary;
                studentCount++;
            }
            else
            {
                Console.WriteLine("Employee is not added. Array is full.");
                return false;
            }

            // Append the employee information to the file
            using (StreamWriter fileOut = new StreamWriter(filename, true))
            {
                fileOut.WriteLine($"{name} {id} {department} {salary}");
                Console.WriteLine("Employee added successfully.");
            }

            return true;
        }
        static void DisplayEmployee(string[] employeeName, string[] employeeId, string[] employeeDepartment, string[] employeeSalary, ref int studentCount, string filename)
        {
            if (File.Exists(filename))
            {
                using (StreamReader fileIn = new StreamReader(filename))
                {
                    string line;

                    while ((line = fileIn.ReadLine()) != null && studentCount < 100)
                    {
                        string[] employeeInfo = line.Split(' ');

                        employeeName[studentCount] = employeeInfo[0];
                        employeeId[studentCount] = employeeInfo[1];
                        employeeDepartment[studentCount] = employeeInfo[2];
                        employeeSalary[studentCount] = employeeInfo[3];

                        Console.WriteLine($"Employee Name: {employeeName[studentCount]}");
                        Console.WriteLine($"Employee Id: {employeeId[studentCount]}");
                        Console.WriteLine($"Employee Department: {employeeDepartment[studentCount]}");
                        Console.WriteLine($"Employee Salary: {employeeSalary[studentCount]}");
                        Console.WriteLine();

                        studentCount++;
                    }
                }
            }
            else
            {
                Console.WriteLine($"File {filename} does not exist.");
            }

            Console.ReadLine(); // Pause
        }

        static void EmployeeInfo(string[] employeeId, string[] employeeDepartment, int studentCount)
        {
            string[] yearsWorked = new string[100];
            string id;
            bool found = false;

            Console.WriteLine("Enter Employee ID: ");
            id = Console.ReadLine();

            for (int i = 0; i < studentCount; ++i)
            {
                if (employeeId[i] == id)
                {
                    Console.WriteLine($"\nEmployee Department: {employeeDepartment[i]}");
                    Console.WriteLine("Enter number of years: ");
                    yearsWorked[i] = Console.ReadLine();
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine($"Employee with ID {id} not found.");
            }

            Console.ReadLine(); // Pause
        }

        static bool IsNumeric(string str)
        {
            foreach (char c in str)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        static void AverageSalary(string filename)
        {
            if (File.Exists(filename))
            {
                using (StreamReader fileIn = new StreamReader(filename))
                {
                    int employeeCount = 0;
                    double totalSalary = 0.0;
                    string line;

                    while ((line = fileIn.ReadLine()) != null)
                    {
                        string[] employeeInfo = line.Split(' ');
                        totalSalary += double.Parse(employeeInfo[3]); // Convert salary from string to double
                        employeeCount++;
                    }

                    if (employeeCount > 0)
                    {
                        double averageSalary = totalSalary / employeeCount;
                        Console.WriteLine($"Average Salary for all employees: {averageSalary}");
                    }
                    else
                    {
                        Console.WriteLine("Unable to calculate average salary. No employees found.");
                    }
                }
            }
            else
            {
                Console.WriteLine($"File {filename} does not exist.");
            }

            Console.ReadLine(); // Pause
        }
        static void IncreaseSalary(string[] employeeId, string[] employeeSalary, int studentCount)
        {
            string targetId;
            int increasePercentage;
            bool employeeFound = false;

            Console.WriteLine("Enter Employee ID to check and increase salary: ");
            targetId = Console.ReadLine();

            for (int i = 0; i < studentCount; i++)
            {
                if (employeeId[i] == targetId)
                {
                    employeeFound = true;
                    string salaryString = employeeSalary[i];

                    if (IsNumeric(salaryString))
                    {
                        float currentSalary = float.Parse(salaryString);

                        Console.WriteLine($"Employee ID: {employeeId[i]}");
                        Console.WriteLine($"Current Salary: {currentSalary}");

                        Console.WriteLine("Enter the percentage increase for salary: ");
                        increasePercentage = int.Parse(Console.ReadLine());

                        int joiningYear;
                        do
                        {
                            Console.WriteLine("Enter the joining year (four digits): ");
                        } while (!int.TryParse(Console.ReadLine(), out joiningYear) || joiningYear < 1000 || joiningYear > 9999);

                        int yearsWorked = 2023 - joiningYear;

                        if (yearsWorked >= 5)
                        {
                            float increaseAmount = (currentSalary * increasePercentage) / 100;
                            float newSalary = currentSalary + increaseAmount;
                            employeeSalary[i] = newSalary.ToString();

                            Console.WriteLine($"Salary increased to: {newSalary}");
                        }
                        else
                        {
                            Console.WriteLine("No salary increase as the employee has not worked for the required number of years.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Invalid salary format for employee: {employeeId[i]}");
                    }
                }
            }

            if (!employeeFound)
            {
                Console.WriteLine($"Employee with ID {targetId} not found.");
            }

            Console.ReadLine();
        }

        static bool UploadTask(string filename, string employeeId)
        {
            bool found = false;
            if (File.Exists(filename))
            {
                string[] lines = File.ReadAllLines(filename);

                foreach (string line in lines)
                {
                    string[] fields = line.Split(',');

                    if (fields.Length >= 3)
                    {
                        string id = fields[0].Trim();
                        string name = fields[1].Trim();
                        string dp = fields[2].Trim();

                        if (id == employeeId)
                        {
                            found = true;

                            Console.WriteLine($"Employee Name: {name}");
                            Console.WriteLine($"Employee ID: {id}");
                            Console.WriteLine($"Employee Department: {dp}");
                            Console.WriteLine("Task uploaded successfully.");
                            break; 
                        }
                    }
                }

                if (!found)
                {
                    Console.WriteLine($"Employee with ID {employeeId} not found.");
                    return false;
                }
            }
            else
            {
                Console.WriteLine($"File not found: {filename}");
                return false;
            }

            Console.ReadLine();
            return true;
        }
    
        static void ExitProgram()
        {
            Console.WriteLine("Have a nice day ");
            Console.ReadKey();
        }

        static void CheckTaskByManager(string filename, string employeeId)
        {
            bool found = false;
            string name, id, dp, salary, workStatus;

            using (System.IO.StreamReader fileIn = new System.IO.StreamReader(filename))
            {
                while (fileIn.Peek() >= 0)
                {
                    string[] employeeInfo = fileIn.ReadLine().Split(' ');

                    name = employeeInfo[0];
                    id = employeeInfo[1];
                    dp = employeeInfo[2];
                    salary = employeeInfo[3];
                    workStatus = employeeInfo[4];

                    if (id == employeeId)
                    {
                        found = true;
                        Console.WriteLine($"Employee Name: {name}");
                        Console.WriteLine($"Employee ID: {id}");
                        Console.WriteLine($"Employee Department: {dp}");

                        if (workStatus == "uploaded")
                        {
                            Console.WriteLine("Work Status: Work has been uploaded.");

                            // Check if the task is done
                            Console.WriteLine("Is the task done? (yes/no): ");
                            string taskStatus = Console.ReadLine();

                            if (taskStatus.ToLower() == "yes")
                            {
                                Console.WriteLine("Bonus: Employee is eligible for a bonus!");
                            }
                            else
                            {
                                Console.WriteLine("Task is not done.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Work Status: Work not uploaded.");
                        }

                        break; // Employee found, exit the loop
                    }
                }
            }

            if (!found)
            {
                Console.WriteLine($"Employee with ID {employeeId} not found.");
            }

            Console.ReadLine();
        }

        static void TotalSalary(string[] employeeSalary, int studentCount)
        {
            float sum = 0;
            for (int l = 0; l < studentCount; l++)
            {
                string salaryString = employeeSalary[l];
                if (IsNumeric(salaryString))
                {
                    sum += float.Parse(employeeSalary[l]);
                }
                else
                {
                    Console.WriteLine($"Invalid salary format for employee {l}: {salaryString}");
                }
            }

            if (studentCount > 0)
            {
                float total = sum;
                Console.WriteLine($"Total Salary: {total}");
            }
            else
            {
                Console.WriteLine("No employees to calculate Total salary.");
            }

            Console.ReadLine();
        }
        static void GiveBonus(string[] employeeId, string[] employeeSalary, string[] employeeName, int studentCount)
        {
            string taskCompleted;
            string id;

            Console.WriteLine("Enter Employee ID to check and give bonus: ");
            id = Console.ReadLine();

            bool employeeFound = false;

            for (int i = 0; i < studentCount; i++)
            {
                if (employeeId[i] == id)
                {
                    employeeFound = true;
                    Console.WriteLine($"Is Employee {employeeName[i]} completed tasks (1 for Yes and 0 for No): ");
                    taskCompleted = Console.ReadLine();
                    int taskCom;

                    if (int.TryParse(taskCompleted, out taskCom))
                    {
                        if (taskCom == 1)
                        {
                            // Bonus for completing tasks
                            if (IsNumeric(employeeSalary[i]))
                            {
                                float currentSalary = float.Parse(employeeSalary[i]);
                                float bonusAmount = 0.1f * currentSalary; // 10% bonus
                                float newSalary = currentSalary + bonusAmount;
                                employeeSalary[i] = newSalary.ToString();
                                Console.WriteLine($"Bonus given successfully. New salary: {newSalary}");
                            }
                        }
                        else if (taskCom == 0)
                        {
                            Console.WriteLine("No bonus given as the employee has not completed tasks.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid input for task completion. Please enter 1 for Yes or 0 for No.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Invalid input for task completion. Please enter a numeric value (1 or 0).");
                    }
                }
            }

            if (!employeeFound)
            {
                Console.WriteLine($"Employee with ID {id} not found.");
            }

            Console.ReadLine();
        }

        static void ExitLogin(ref int employeeCount, string[] employeeName, string[] employeeId, string[] employeeSalary, string[] employeeDepartment, int arrSize, string[] managerName, string[] managerId, string[] managerSalary, ref int managerCount, int arraySize)
        {
            Console.WriteLine("Thanks for visiting. ");
            Console.ReadKey();

            const int arrasize = 100;
            string[] userName = new string[arrasize];
            string[] userPassword = new string[arrasize];
            string[] userRole = new string[arrasize];
            int loginOption = 0;
            int userCount = 0;

            Console.Clear();

            while (loginOption != 3)
            {
                loginOption = LoginPage();

                if (loginOption == 1)
                {
                    Console.Clear();
                    string name;
                    string password;
                    string role;

                    PrintHeader();
                    LogIn();

                    Console.SetCursorPosition(45, 15);
                    Console.WriteLine("Enter your Name: ");
                    name = Console.ReadLine();

                    Console.SetCursorPosition(45, 17);
                    Console.WriteLine("Enter your Password: ");
                    password = Console.ReadLine();

                    role = SignIn(name, password, userName, userPassword, userRole, userCount);

                    if (role == "manager" || role == "Manager")
                        Manager(role, ref employeeCount, employeeName, employeeId, employeeSalary, employeeDepartment, managerName, managerId, managerSalary, ref managerCount);
                    else if (role == "boss" || role == "Boss")
                        Boss(role, ref employeeCount, employeeName, employeeId, employeeSalary, employeeDepartment, managerName, managerId, managerSalary, ref managerCount);
                    else if (role == "employee" || role == "Employee")
                        EmployeeFunction(role, ref employeeCount, employeeName, employeeId, employeeSalary, employeeDepartment, managerName, managerId, managerSalary, ref managerCount);
                    else
                    {
                        Console.WriteLine("User not found. Please try again.");
                        Console.ReadLine();
                        Console.Clear();
                    }
                }
                else if (loginOption == 2)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    string name = "";
                    string password;    
                    string role = "";
                    bool invalidInput = true;

                    PrintHeader();
                    SignUp();

                    while (invalidInput == true)
                    {
                        Console.SetCursorPosition(45, 15);
                        Console.WriteLine("1. User name: ");
                        name = Console.ReadLine();

                        if (!IsValidName(name))
                        {
                            Console.WriteLine("Invalid input. Please enter only characters.");
                            Console.ReadLine();
                            invalidInput = false;
                        }

                        Console.Clear();

                        if (!invalidInput)
                        {
                            PrintHeader();
                            SignUp();
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.ForegroundColor = ConsoleColor.Black;
                            invalidInput = true;
                        }
                        else
                        {
                            PrintHeader();
                            SignUp();
                            Console.SetCursorPosition(45, 15);
                            Console.WriteLine("1. User name: ");
                            Console.WriteLine(name);
                            invalidInput = false;
                        }
                    }

                    Console.SetCursorPosition(45, 16);
                    bool length = true;
                    Console.WriteLine("2. User Password: ");
                    password = Console.ReadLine();

                    while (length == true)
                    {
                        if (password.Length < 8)
                        {
                            Console.SetCursorPosition(48, 17);
                            Console.WriteLine("Password should be at least 8 characters. Enter again: ");
                            password = Console.ReadLine();
                            length = true;
                        }
                        else
                        {
                            length = false;
                        }
                    }

                    bool invalidInputRole = true;

                    while (invalidInputRole)
                    {
                        Console.SetCursorPosition(45, 18);
                        Console.WriteLine("3. Role (Boss, Manager, Employee): ");
                        role = Console.ReadLine();

                        if (role != "boss" && role != "Boss" && role != "manager" && role != "Manager" && role != "Employee" && role != "employee")
                        {
                            Console.SetCursorPosition(45, 19);
                            Console.WriteLine("Invalid input.");
                            Console.ReadLine();
                            invalidInputRole = true;
                        }
                        else
                        {
                            invalidInputRole = false;
                        }
                    }

                    bool isValid = SignUpMe(name, password, role, userName, userPassword, userRole, ref userCount, arrSize);

                    if (isValid)
                    {
                        Console.WriteLine("Signed Up Successfully");
                    }

                    if (!isValid)
                    {
                        Console.WriteLine("Warning! Signed Up not Successfully");
                    }

                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
        static void FireManager(string[] managerId, string[] managerName, string[] managerSalary, ref int managerCount)
        {
            string idToRemove;

            Console.WriteLine("Enter the ID of the manager to be fired: ");
            idToRemove = Console.ReadLine();

            bool managerFound = false;

            for (int i = 0; i < managerCount; i++)
            {
                if (managerId[i] == idToRemove)
                {
                    for (int j = i; j < managerCount - 1; j++)
                    {
                        managerId[j] = managerId[j + 1];
                        managerName[j] = managerName[j + 1];
                        managerSalary[j] = managerSalary[j + 1];
                    }
                    managerCount--;

                    Console.WriteLine($"Manager with ID {idToRemove} has been fired.");
                    managerFound = true;
                    break;
                }
            }

            if (!managerFound)
            {
                Console.WriteLine($"Manager with ID {idToRemove} not found.");
            }

            Console.ReadLine();
        }

        static void FireEmployee(string[] employeeId, string[] employeeName, string[] employeeDepartment, string[] employeeSalary, ref int studentCount, string filename)
        {
            string idToRemove;

            Console.WriteLine("Enter the ID of the employee to be fired: ");
            idToRemove = Console.ReadLine();

            for (int i = 0; i < studentCount; ++i)
            {
                if (employeeId[i] == idToRemove)
                {
                    for (int j = i; j < studentCount - 1; ++j)
                    {
                        employeeId[j] = employeeId[j + 1];
                        employeeName[j] = employeeName[j + 1];
                        employeeDepartment[j] = employeeDepartment[j + 1];
                        employeeSalary[j] = employeeSalary[j + 1];
                    }
                    --studentCount;

                    using (StreamWriter tempFile = new StreamWriter("temp.txt"))
                    {
                        for (int k = 0; k < studentCount; ++k)
                        {
                            tempFile.WriteLine($"{employeeId[k]} {employeeName[k]} {employeeDepartment[k]} {employeeSalary[k]}");
                        }
                    }

                    File.Delete(filename);
                    File.Move("temp.txt", filename);

                    Console.WriteLine($"Employee with ID {idToRemove} has been fired.");
                    return;
                }
            }

            Console.WriteLine($"Employee with ID {idToRemove} not found.");
        }

        static void EmployeeLogo()
        {
            Console.SetCursorPosition(8, 13);
            Console.WriteLine("    ________  _______  __    ______  ______________");
            Console.SetCursorPosition(8, 14);
            Console.WriteLine("   / ____/  |/  / __ \\/ /   / __ \\ \\/ / ____/ ____/");
            Console.SetCursorPosition(8, 15);
            Console.WriteLine("  / __/ / /\\_/ / /_/ / /   / / / /\\  / __/ / __/");
            Console.SetCursorPosition(8, 16);
            Console.WriteLine(" / /___/ /  / / ____/ /___/ /_/ / / / /___/ /___");
            Console.SetCursorPosition(8, 17);
            Console.WriteLine("/_____/_/  /_/_/   /_____/\\____/ /_/_____/_____/");
        }

        static void Logo()
        {
            Console.Clear();
            PrintHeader();
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Welcome();
            Console.SetCursorPosition(35, 14);
            Console.WriteLine("*********************************************************");
            Console.SetCursorPosition(35, 15);
            Console.WriteLine("****                      @@            /%           ****");
            Console.SetCursorPosition(35, 16);
            Console.WriteLine("***                    |@@@@\\          /%             ***");
            Console.SetCursorPosition(35, 17);
            Console.WriteLine("***                   _|@@@@\\\\__oooooo/%__            ***");
            Console.SetCursorPosition(35, 18);
            Console.WriteLine("**                      |@@  |      ||                 **");
            Console.SetCursorPosition(35, 19);
            Console.WriteLine("***                     | @@ |      ||                ***");
            Console.SetCursorPosition(35, 20);
            Console.WriteLine("****                    O  @@       ||               ****");
            Console.SetCursorPosition(35, 21);
            Console.WriteLine("*********************************************************");
            System.Threading.Thread.Sleep(2000);
        }
    }
}
