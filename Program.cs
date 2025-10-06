namespace BookRecommendationSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the book Recommendation Program");

            bool filesFound = false;
            bool InMainMenu = true;
            bool IsLoggedIn = false;
            string? booksFilePath;
            string? ratingsFilePath;
            StreamReader booksReader = null;
            StreamReader ratingsReader = null;

            //Test Code:
            booksFilePath = "C:\\Users\\Insan\\source\\repos\\BookRecommendationSystem\\BookRecommendationSystem\\Files\\books.txt";
            ratingsFilePath = "C:\\Users\\Insan\\source\\repos\\BookRecommendationSystem\\BookRecommendationSystem\\Files\\ratings.txt";
            Console.WriteLine();
            booksReader = new StreamReader(booksFilePath);
            ratingsReader = new StreamReader(ratingsFilePath);
            int numberOfBooks = BookSystem.CountAndStoreBooks(booksReader);
            Console.WriteLine($"Number of Books: {numberOfBooks}");
            int numberOfMembers = BookSystem.CountAndStoreMembers(ratingsReader);
            Console.WriteLine($"Number of Members: {numberOfMembers}");

            //while (!filesFound)
            //{
            //    Console.Write("Enter books file: ");
            //    booksFilePath = Console.ReadLine();
            //    Console.Write("Enter ratings file: ");
            //    ratingsFilePath = Console.ReadLine();


            //    try
            //    {
            //        booksReader = new StreamReader(booksFilePath);
            //        ratingsReader = new StreamReader(ratingsFilePath);

            //        filesFound = true;
            //    }
            //    catch (FileNotFoundException)
            //    {
            //        Console.WriteLine("One of your file paths is incorrect.");
            //        continue;
            //    }
            //    catch (Exception)
            //    {
            //        Console.WriteLine("An error has occured.");
            //        continue;
            //    }
            //    Console.WriteLine();
            //    int numberOfBooks = BookSystem.CountAndStoreBooks(booksReader);
            //    Console.WriteLine($"Number of Books: {numberOfBooks}");
            //    int numberOfMembers = BookSystem.CountAndStoreMembers(ratingsReader);
            //    Console.WriteLine($"Number of Members: {numberOfMembers}");
            //}


            while (InMainMenu)
            {
                Console.WriteLine("============== MENU ==============");
                Console.WriteLine("= 1. Add a new member            =");
                Console.WriteLine("= 2. Add a new book              =");

                if (!IsLoggedIn)
                {
                    Console.WriteLine("= 3. Login                       =");
                    Console.WriteLine("= 4. Quit                        =");
                    Console.WriteLine("==================================");
                }
                else
                {
                    Console.WriteLine("= 3. Rate book                   =");
                    Console.WriteLine("= 4. View ratings                =");
                    Console.WriteLine("= 5. See recommendations         =");
                    Console.WriteLine("= 6. Logout                      =");
                    Console.WriteLine("==================================");
                }


                    Console.WriteLine();
                Console.Write("Enter menu option: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int selectedNumber))
                {
                }
                else
                {
                    Console.WriteLine("Invalid input, please enter a valid number.");
                }
                Console.WriteLine();
                switch (selectedNumber)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        if (!IsLoggedIn)
                        {
                            Console.Write("Enter member account: ");
                            string input2 = Console.ReadLine();
                            if (int.TryParse(input2, out int accountNumber))
                            {
                            }
                            else
                            {
                                Console.WriteLine("Invalid input, please enter a valid number.");
                            }
                            try
                            {
                                Console.WriteLine();
                                BookSystem.Members[accountNumber - 1].IsLoggedIn = true;
                                IsLoggedIn = true;
                                Console.WriteLine($"{BookSystem.Members[accountNumber - 1].Name}, you are logged in!");
                                Console.WriteLine();

                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Member doesn't exist! Try again");
                                Console.WriteLine();
                            }
                        }

                        break;
                    case 4:
                        break;
                    default:
                        Console.WriteLine("Wrong Number");
                        break;

                }

            }
        }
    }
}
