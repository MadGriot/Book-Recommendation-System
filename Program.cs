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
            int accountNumber = -1;
            string? booksFilePath;
            string? ratingsFilePath;
            StreamReader booksReader = null;
            StreamReader ratingsReader = null;

            //Test Code:
            //booksFilePath = "C:\\Users\\Insan\\source\\repos\\BookRecommendationSystem\\BookRecommendationSystem\\Files\\books.txt";
            //ratingsFilePath = "C:\\Users\\Insan\\source\\repos\\BookRecommendationSystem\\BookRecommendationSystem\\Files\\ratings.txt";
            //Console.WriteLine();
            //booksReader = new StreamReader(booksFilePath);
            //ratingsReader = new StreamReader(ratingsFilePath);
            //int numberOfBooks = BookSystem.CountAndStoreBooks(booksReader);
            //Console.WriteLine($"Number of Books: {numberOfBooks}");
            //int numberOfMembers = BookSystem.CountAndStoreMembers(ratingsReader);
            //Console.WriteLine($"Number of Members: {numberOfMembers}");

            while (!filesFound)
            {
                Console.Write("Enter books file path: ");
                booksFilePath = Console.ReadLine();
                Console.Write("Enter ratings file path: ");
                ratingsFilePath = Console.ReadLine();


                try
                {
                    booksReader = new StreamReader(booksFilePath);
                    ratingsReader = new StreamReader(ratingsFilePath);

                    filesFound = true;
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("One of your file paths is incorrect.");
                    continue;
                }
                catch (Exception)
                {
                    Console.WriteLine("An error has occured.");
                    continue;
                }
                Console.WriteLine();
                int numberOfBooks = BookSystem.CountAndStoreBooks(booksReader);
                Console.WriteLine($"Number of Books: {numberOfBooks}");
                int numberOfMembers = BookSystem.CountAndStoreMembers(ratingsReader);
                Console.WriteLine($"Number of Members: {numberOfMembers}");
            }


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
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Invalid input, please enter a valid number.");
                }
                switch (selectedNumber)
                {
                    case 1:
                        Console.Write("Enter the name of the new member: ");
                        string memberName = Console.ReadLine();
                        Member member = new Member(memberName, BookSystem.Members.Count);
                        BookSystem.AddNewMember(member);
                        Console.WriteLine($"{member.Name} (account #: {member.AccountNumber + 1}) was added.");
                        break;
                    case 2:
                        Console.Write("Enter the author of the new book: ");
                        string bookAuthor = Console.ReadLine();
                        Console.Write("Enter the title of the new book: ");
                        string bookName = Console.ReadLine();
                        Console.Write("Enter the year (or range of years) of the new book: ");
                        string bookYear = Console.ReadLine();
                        Book book = new Book(BookSystem.Books.Count + 1, bookAuthor, bookName, bookYear);
                        BookSystem.AddNewBook(book);
                        break;
                    case 3:
                        if (!IsLoggedIn)
                        {
                            Console.Write("Enter member account number: ");
                            string input2 = Console.ReadLine();
                            if (int.TryParse(input2, out accountNumber))
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
                        else
                        {
                            Console.Write("Enter the ISBN for the book you'd like to rate: ");
                            string input3 = Console.ReadLine();
                            if (int.TryParse(input3, out int bookISBN))
                            {

                            }
                            else
                            {
                                Console.WriteLine("Invalid input, please enter a valid number.");
                            }
                            Console.Write("Enter your rating: ");
                            string input4 = Console.ReadLine();
                            if (int.TryParse(input4, out int bookRating))
                            {

                            }
                            else
                            {
                                Console.WriteLine("Invalid input, please enter a valid number.");
                            }
                            BookSystem.RateBook(bookISBN, accountNumber - 1, bookRating);
                        }
                        break;
                    case 4:
                        if (!IsLoggedIn)
                        {
                            InMainMenu = false;
                        }
                        else
                        {
                            BookSystem.ViewRatings(accountNumber - 1);
                        }
                            break;
                    case 5:
                        if (IsLoggedIn)
                        {
                            BookSystem.BookRecommendations(accountNumber - 1);
                        }
                        break;
                    case 6:
                        if (IsLoggedIn)
                        {
                            try
                            {
                                Console.WriteLine();
                                IsLoggedIn = false;
                                Console.WriteLine($"{BookSystem.Members[accountNumber - 1].Name}, you are logged out!");
                                Console.WriteLine();
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("An Error has occured");
                            }

                        }
                        break;
                    default:
                        Console.WriteLine("Wrong Number");
                        break;

                }

            }
        }
    }
}
