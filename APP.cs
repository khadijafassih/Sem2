using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EZInput;
using System.Data;
using System.Xml.Linq;
using System.Diagnostics.Eventing.Reader;

namespace APPLICATION
{
    internal class Program
    {
        static void loginHeader() // login menu header printing
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("                                                                                                                                                                        ");
            Console.WriteLine("                                                                                                                                                                        ");
            Console.WriteLine("*                                                                         LOGIN MENU                                                                                   *");
            Console.WriteLine("                                                                                                                                                                        ");
            Console.WriteLine("*-----------------------------------------------------------((((((((((((((----------))))))))))))))---------------------------------------------------------------------*");
        }
        static void header() // function for header
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("************************************************************************************************************************************************************************");
            Console.WriteLine("*----------------------------------------------------------------------------------------------------------------------------------------------------------------------*");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("                _        _                     _               _ _                                                                               _                  ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("               /_\\  _ __| |_    __ _ _ __   __| |   __ _  __ _| | | ___ _ __ _   _   _ __ ___   __ _ _ __   __ _  __ _  ___ _ __ ___   ___ _ __ | |_                ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("              //_ \\| '__| __|  / _` | '_ \\ / _` |  / _` |/ _` | | |/ _ | '__| | | | | '_ ` _ \\ / _` | '_ \\ / _` |/ _` |/ _ | '_ ` _ \\ / _ | '_ \\| __|               ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("             /  _  | |  | |_  | (_| | | | | (_| | | (_| | (_| | | |  __| |  | |_| | | | | | | | (_| | | | | (_| | (_| |  __| | | | | |  __| | | | |                 ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("             \\_/ \\_|_|   \\__|  \\__,_|_| |_|\\__,_|  \\__, |\\__,_|_|_|\\___|_|   \\__, | |_| |_| |_|\\__,_|_| |_|\\__,_|\\__, |\\___|_| |_| |_|\\___|_| |_|\\__|");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("                                                    |___/                     |___/                               |___/                                               ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("*----------------------------------------------------------------------------------------------------------------------------------------------------------------------*");
            Console.WriteLine("************************************************************************************************************************************************************************");
        }
        static void ClearInputBuffer()
        {
            while (Console.KeyAvailable)
            {
                Console.ReadKey(true); // Read and discard remaining characters
            }
        }
        static bool IsNumeric(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            foreach (char c in input)
            {
                if (!char.IsDigit(c) || char.IsWhiteSpace(c))
                {
                    return false;
                }
            }
            return true;
        }
        static int loginMenu()
        {
            Console.WriteLine("1. Sign Up");
            Console.WriteLine("2. Sign In");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");

            string input = Console.ReadLine();

            if (IsNumeric(input))
            {
                if (int.TryParse(input, out int choice))
                {
                    
                    return choice;
                }
            }
            
            return -1;
        }
        static void clearScreen()
        {
            Console.WriteLine("Press any key to continue: ");
            Console.Read();
            Console.Clear();
        }
        static bool isValidUsername(string username)
        {
            if (username.Length < 6)
            {
                return false;
            }

            for (int i = 0; i < username.Length; i++)
            {
                if (!char.IsLetterOrDigit(username[i]))
                {
                    return false;
                }
            }
            return true;
        }
        static bool isValidPassword(string password)
        {
            bool hasUppercase = false;
            bool hasLowercase = false;
            bool hasNumber = false;
            if (password.Length < 8)
            {
                return false;
            }
            for (int i = 0; i < password.Length; i++)
            {
                if (Char.IsUpper(password[i]))
                {
                    hasUppercase = true;
                }
                else if (Char.IsLower(password[i]))
                {
                    hasLowercase = true;
                }
                else if (Char.IsDigit(password[i]))
                {
                    hasNumber = true;
                }
            }
            return hasUppercase && hasLowercase && hasNumber;
        }
        static string signIn(string name, string password, string[] usernames, string[] passwords, string[] roles, int usersCount)
        {
            for (int i = 0; i < usersCount; i++)
            {
                if (usernames[i] == name && passwords[i] == password)
                {
                    string role = roles[i];
                    return roles[i];
                }
            }
            return "Sign In failed. Invalid username or password.";
        }

        static bool signUp(string name, string password, string role, string[] usernames, string[] passwords, string[] roles, ref int usersCount, int userLimit)
        {
            bool isPresent = false;

            for (int i = 0; i < usersCount; i++)
            {
                if (usernames[i] == name && passwords[i] == password)
                {
                    isPresent = true;
                    break;
                }
            }

            if (isPresent == true)
            {
                return false;
            }
            else if (usersCount < userLimit)
            {
                usernames[usersCount] = name;
                passwords[usersCount] = password;
                roles[usersCount] = role; // Use the provided role parameter
                usersCount++;
                return true;
            }
            else
            {
                return false;
            }
        }
        static void ManagerHeader() // manager menu header printing
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("                                                                                                                                                                        ");
            Console.WriteLine("                                                                                                                                                                        ");
            Console.WriteLine("*                                                                        MANAGER MENU                                                                                  *");
            Console.WriteLine("                                                                                                                                                                        ");
            Console.WriteLine("*-----------------------------------------------------------((((((((((((((----------))))))))))))))---------------------------------------------------------------------*");
        }
        static int Managermenu()
        {
            Console.WriteLine("Select one of the following options:");
            Console.WriteLine(" 1. Access all items in the catalog.");
            Console.WriteLine(" 2. Remove item.");
            Console.WriteLine(" 3. Add item.");
            Console.WriteLine(" 4. All users data.");
            Console.WriteLine(" 5. Discount application.");
            Console.WriteLine(" 6. Pre-bookings Record.");
            Console.WriteLine(" 7. Display User Feedback");
            Console.WriteLine(" 8. Search a Record");
            Console.WriteLine(" 9. Exit");
            Console.Write(" Your option: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int option))
            {
                return option;
               
            }
            
            return -1;
        }

        static void accessCatalog(string[] catalog, int[] catalogPrices, ref int catalogSize)
        {
            Console.WriteLine("Catalog Items:");
            Console.WriteLine("{0,-10}{1,-20}{2,-20}", "Item ID", "Item Name", "Price");
            Console.WriteLine("---------------------------------------------------");
            for (int i = 0; i < catalogSize; ++i)
            {
                Console.WriteLine("{0,-10}{1,-20}{2,15}{3}", i + 1, catalog[i], "$", catalogPrices[i]);
            }
            Console.WriteLine();
        }

        static void removeItem(int index, string[] catalog, int[] catalogPrices, ref int catalogSize)
        {
            if (index >= 1 && index <= catalogSize)
            {
                for (int i = index - 1; i < catalogSize - 1; ++i)
                {
                    catalog[i] = catalog[i + 1];
                    catalogPrices[i] = catalogPrices[i + 1];
                }
                catalogSize--;
                Console.WriteLine("Item removed successfully.");
            }
            else
            {
                Console.WriteLine("Invalid index.");
            }
        }

        static void addItem(string[] catalog, int[] catalogPrices, ref int catalogSize)
        {
            if (catalogSize < 8)
            {
                Console.Write("Enter item name: ");
                Console.ReadLine();
                catalog[catalogSize] = Console.ReadLine();
                Console.Write("Enter item price: $");
                catalogPrices[catalogSize] = Convert.ToInt32(Console.ReadLine());
                catalogSize++;
                Console.WriteLine("Item added successfully.");
            }
            else
            {
                Console.WriteLine("Catalog is full. Cannot add more items.");
            }
        }
        static void displayUserData(string[] usernames, int userCount)
        {
            Console.WriteLine("User Data:");
            Console.WriteLine("{0,-10}{1,-20}", "User ID", "Username");
            Console.WriteLine("---------------------------------------");
            for (int i = 0; i < userCount; ++i)
            {
                Console.WriteLine("{0,-10}{1,-45}", i + 1, usernames[i]);
            }
            Console.WriteLine();
        }

        static void applyDiscount(int[] Paintingsprices, ref int catalogSize, double discountPercentage)
        {
            if (discountPercentage >= 0 && discountPercentage <= 100)
            {
                for (int i = 0; i < catalogSize; ++i)
                {
                    Paintingsprices[i] = (int)(Paintingsprices[i] * (1.0 - discountPercentage / 100.0));
                }
                Console.WriteLine("Discount applied.");
            }
            else
            {
                Console.WriteLine("Invalid discount percentage. Please enter a value between 0 and 100.");
            }
        }

        static void displayBookingsRecord(string[] catalog, int[] preBookings, ref int catalogSize)
        {
            Console.WriteLine("Bookings Record:");
            Console.WriteLine("{0,-10}{1,-20}{2,-20}", "Item ID", "Item Name", "Quantity");
            Console.WriteLine("-------------------------------------------");
            for (int i = 0; i < catalogSize; ++i)
            {
                if (preBookings[i] > 0)
                {
                    Console.WriteLine("{0,-10}{1,-20}{2,8}", i + 1, catalog[i], preBookings[i]);
                }
            }
            Console.WriteLine();
        }
        static void seeCustomerFeedback(string[] feedbacks, int feedbackCount)
        {
            if (feedbackCount == 0)
            {
                Console.WriteLine("No feedbacks available.");
                return;
            }
            Console.WriteLine("Customer Feedbacks:");
            for (int i = 0; i < feedbackCount; ++i)
            {
                Console.WriteLine("Feedback " + (i + 1) + ":");
                Console.WriteLine(feedbacks[i]);
                Console.WriteLine("-------------------------");
            }
        }

        static int searchPainting(string[] catalog, int[] catalogPrices, ref int catalogSize)
        {
            string searchTerm;
            Console.Write("Enter the name of the painting to search for: ");
            Console.ReadLine();
            searchTerm = Console.ReadLine();
            for (int i = 0; i < catalogSize; i++)
            {
                if (searchTerm == catalog[i])
                {
                    return i;
                }
            }

            return -1;
        }

        static void ManagerInterfaceFunctionality(ref int catalogSize, string[] catalog, ref int userCount, int[] Paintingsprices, int[] preBookings, string[] usernames, int[] wishlist, int[] orderHistory, string[] exhibitionNames, string[] exhibitionDates, string[] exhibitionTimes, string[] specialGuests, ref int exhibitionSize, string[] feedbacks, ref int feedbackCount)
        {
            while (true)
            {
                Console.Clear();
                header();
                ManagerHeader();
                int option = Managermenu();
                
                {
                    if (option == 1)// Access all items in the catalog.
                    {
                        accessCatalog(catalog, Paintingsprices, ref catalogSize);
                        
                    }
                    else if (option == 2) // Remove item.
                    {
                        accessCatalog(catalog, Paintingsprices, ref catalogSize);
                        int index;
                        Console.WriteLine("Enter the index of the item to remove: ");
                        index = Convert.ToInt32(Console.ReadLine());
                        removeItem(index, catalog, Paintingsprices, ref catalogSize);
                       // saveCatalogToFile(catalog, Paintingsprices, ref catalogSize);
                        break;
                    }
                    else if (option == 3) // Add item.
                    {
                        accessCatalog(catalog, Paintingsprices, ref catalogSize);
                        addItem(catalog, Paintingsprices, ref catalogSize);
                        //saveCatalogToFile(catalog, Paintingsprices, ref catalogSize);
                        break;
                    }

                    else if (option == 4) // All users data.
                    {
                        displayUserData(usernames, userCount);
                        break;
                    }
                    else if (option == 5) // Discount applicaton.
                    {
                        double discountPercentage;
                        Console.WriteLine("Enter the discount percentage: ");
                        discountPercentage = Convert.ToDouble(Console.ReadLine());
                        applyDiscount(Paintingsprices, ref catalogSize, discountPercentage);
                       // saveCatalogToFile(catalog, Paintingsprices, ref catalogSize);
                        break;
                    }
                    else if (option == 6) // Pre-bookings Record.
                    {
                        displayBookingsRecord(catalog, preBookings,ref catalogSize);
                        break;
                    }
                    else if (option == 7) // see Customer feedback.
                    {
                        seeCustomerFeedback(feedbacks, feedbackCount);
                        break;
                    }
                    else if (option == 8) // search and edit a record.
                    {
                        int found = searchPainting(catalog, Paintingsprices, ref catalogSize);
                        if (found != -1)
                        {
                            char choice;
                            Console.WriteLine("1. Delete this record");
                            Console.WriteLine("2. Edit this record");
                            Console.WriteLine("Enter your choice: ");
                            choice = Convert.ToChar(Console.ReadLine());
                            if (choice == '1')
                            {
                                removeItem(found + 1, catalog, Paintingsprices, ref catalogSize);
                            }
                            else if (choice == '2')
                            {
                                Console.WriteLine("Enter the new name: ");
                                catalog[found] = Console.ReadLine();
                                Console.WriteLine("Enter the new price: $");
                                Paintingsprices[found] = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Record updated successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid choice.");
                                continue;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Painting not found.");
                        }
                        break;
                    }
                    else if (option == 9) // Exit.
                    {
                        return;
                    }
                    else
                        Console.WriteLine("Invalid option. Please try again.");
                }
            }
            clearScreen();
            return;
        }
        static void Main()
        {
            int catalogSize = 8;
            string[] catalog = new string[] { "Winters", "StarryNight", "Memory", "Scream", "Guernica", "Lost", "Venus", "Watch" };
            int[] Paintingsprices = new int[] { 860, 1000, 5000, 1200, 1855, 12999, 1999, 6000 };
            //SaveCatalogToFile(catalog, Paintingsprices, catalogSize);
            int[] preBookings = new int[catalogSize];
            const int wishlistSize = 8;
            int[] wishlist = new int[catalogSize];
            const int orderHistorySize = 8;
            int[] orderHistory = new int[orderHistorySize];
            string[] exhibitionNames = new string[10];
            string[] exhibitionDates = new string[10];
            string[] exhibitionTimes = new string[10];
            string[] specialGuests = new string[10];
            int exhibitionSize = 0;
            string[] customerNames = new string[5];
            string[] feedbacks = new string[5];
            int feedbackCount = 0;
            int MAX_PAINTINGS = 20;
            string[] artistNames = new string[MAX_PAINTINGS];
            string[] fanMeetDurations = new string[MAX_PAINTINGS];
            string[] fanMeetDates = new string[MAX_PAINTINGS];
            string[] fanMeetVenues = new string[MAX_PAINTINGS];
            string[] fanMeetAttendees = new string[MAX_PAINTINGS];
            int fanMeetSize = 0;
            const int userLimit = 10;
            string[] usernames = new string[userLimit];
            string[] passwords = new string[userLimit];
            string[] roles = new string[userLimit];
            int userCount = 0;
            int choice = 0;
            // LoadCatalogFromFile(catalog, Paintingsprices, catalogSize);
            // LoadUserDataFromFile(usernames, passwords, roles, ref userCount);
            // ReadExhibitionFromFile(exhibitionNames, exhibitionDates, exhibitionTimes, specialGuests, ref exhibitionSize);
            // ReadFanmeetFromFile(fanMeetDates, fanMeetVenues, fanMeetDurations, fanMeetAttendees, ref fanMeetSize);
            // ReadFeedbackToFile(feedbacks, feedbackCount);
            while (true)
            {
                Console.Clear();
                header();
                loginHeader();
                choice = loginMenu();

                {
                    if (choice == 1)
                    {
                        string name;
                        string password;
                        string role;
                        bool usernameExists;
                        do
                        {
                            usernameExists = false;
                            Console.Write("Please Enter the username: ");
                            name = Console.ReadLine();
                            if (!isValidUsername(name))
                            {
                                Console.WriteLine("Invalid username. Please enter a username that is at least 6 characters long and contains only letters and numbers.");
                            }
                            else
                            {
                                for (int i = 0; i < userCount; i++)
                                {
                                    if (usernames[i] == name)
                                    {
                                        Console.WriteLine("This Username already exists. Please choose a different username.");
                                        usernameExists = true;
                                        break;
                                    }
                                }
                            }
                        } while (usernameExists);

                        do
                        {
                            Console.Write("Please Enter the password: ");
                            password = Console.ReadLine();
                            if (!isValidPassword(password))
                            {
                                Console.WriteLine("Invalid password. Please enter a password that is at least 8 characters long and contains at least one uppercase letter, one lowercase letter, and one number.");
                            }
                            else
                            {
                                bool validInput = false;
                                //string role;

                                do
                                {
                                    Console.Write("Enter your Role (Manager/Customer/Artist): ");
                                    role = Console.ReadLine();

                                    if (role.Equals("Manager", StringComparison.OrdinalIgnoreCase) || role.Equals("Customer", StringComparison.OrdinalIgnoreCase) || role.Equals("Artist", StringComparison.OrdinalIgnoreCase))
                                    {
                                        validInput = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid role entered. Please enter a valid role (Manager/Customer/Artist).\n");
                                    }
                                } while (!validInput);

                                bool isValid = signUp(name, password, role, usernames, passwords, roles, ref userCount, userLimit);

                                if (isValid)
                                {
                                    Console.WriteLine("Sign Up successful!\n");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Sign Up not Successful!!\n");
                                }
                                Console.Read();
                                break;
                            }
                        } while (true);
                        break;
                    }
                    else if (choice == 2)
                    {
                        string name;
                        string password;
                        string role;
                        Console.Write("Enter your Name: ");
                        name = Console.ReadLine();
                        Console.Write("Enter your Password: ");
                        password = Console.ReadLine();
                        role = signIn(name, password, usernames, passwords, roles, userCount);
                        clearScreen();
                        header();
                        if (role == "Manager" || role == "manager")
                        {
                            ManagerHeader();
                            //ManagerInterfaceFunctionality(catalogSize, catalog, userCount, Paintingsprices, preBookings, usernames, wishlist, orderHistory, exhibitionNames, exhibitionDates, exhibitionTimes, specialGuests, exhibitionSize, feedbacks, feedbackCount);
                        }
                        else
                        {
                            Console.WriteLine("Error!! your role, password, or username does not match. Retry!");
                        }

                        break;
                    }
                    else if (choice == 3)
                    {
                        Console.WriteLine("Exiting program.\n");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Please try again.\n");
                    }
                }
                ClearInputBuffer();
            }
            Console.Read();
            return;
        }

    }

}

